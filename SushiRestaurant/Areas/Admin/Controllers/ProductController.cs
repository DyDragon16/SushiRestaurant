using ECommerceSysCore.Models;
using ECommerceSysCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using X.PagedList;

namespace ECommerceSysCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Staff")]
    public class ProductController : Controller
    {
        private readonly SushiRestaurantContext context;
        private readonly ProductRepository productRepository = null;
        private readonly CategoryRepositoy categoryRepositoy = null;
        public ProductController(SushiRestaurantContext context)
        {
            this.context = context;
            productRepository = new ProductRepository(context);
            categoryRepositoy = new CategoryRepositoy(context);
        }
        public IActionResult Index(int page = 1)
        {
            var pageNumber = page;
            var pageSize = 10;
            var products = productRepository.getAll().OrderByDescending(p => p.ProductId).ToPagedList(pageNumber, pageSize);
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product objProduct, IFormFile? uploadPhoto)
        {
            if (ModelState.IsValid)
            {
                //Xử lý với ảnh upload
                if (uploadPhoto != null && uploadPhoto.Length > 0)
                {
                    var fileName = Path.GetFileName(uploadPhoto.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadPhoto.CopyToAsync(stream);
                    }
                    objProduct.Image = fileName;
                }
                objProduct.Status = true;
                context.Products.Add(objProduct);
                context.SaveChanges();
                TempData["success"] = "Add successfull!";
                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = new SelectList(context.Categories, "CategoryId", "CategoryName");
            return View(objProduct);
        }

        public IActionResult Detail(int id = 0)
        {
            var p = productRepository.getById(id);
            return View(p);
        }

        [HttpGet]
        public IActionResult Edit(int id = 0)
        {
            var p = productRepository.getById(id);
            ViewBag.CategoryList = new SelectList(context.Categories, "CategoryId", "CategoryName");
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product objProduct, IFormFile? uploadPhoto)
        {
            if (ModelState.IsValid)
            {
                //Xử lý với ảnh upload
                if (uploadPhoto != null && uploadPhoto.Length > 0)
                {
                    var fileName = Path.GetFileName(uploadPhoto.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadPhoto.CopyToAsync(stream);
                    }
                    objProduct.Image = fileName;
                }
                objProduct.Status = true;
                context.Products.Update(objProduct);
                context.SaveChanges();
                TempData["success"] = "Update successfull!";
                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = new SelectList(context.Categories, "CategoryId", "CategoryName");
            return View(objProduct);
        }

        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            var p = productRepository.getById(id);
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Product objPro)
        {
            var objProduct = productRepository.getById(id);
            objProduct.Status = false;
            context.Products.Update(objProduct);
            context.SaveChanges();
            TempData["success"] = "Delete successfull!";
            return RedirectToAction("Index");
        }
    }
}
