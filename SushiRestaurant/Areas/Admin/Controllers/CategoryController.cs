using ECommerceSysCore.Models;
using ECommerceSysCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace ECommerceSysCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Staff")]
    public class CategoryController : Controller
    {
        private readonly SushiRestaurantContext context;
        private readonly ProductRepository productRepository = null;
        private readonly CategoryRepositoy categoryRepositoy = null;
        public CategoryController(SushiRestaurantContext context)
        {
            this.context = context;
            categoryRepositoy = new CategoryRepositoy(context);
        }
        public IActionResult Index(int page = 1)
		{
			var pageNumber = page;
			var pageSize = 10;
			var lstCategory = categoryRepositoy.getAllWithProducts().OrderByDescending(p => p.CategoryId).ToPagedList(pageNumber, pageSize);
			return View(lstCategory);
        }

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Category category, IFormFile? uploadPhoto)
		{
			if (ModelState.IsValid)
			{
				//Xử lý với ảnh upload
				if (uploadPhoto != null && uploadPhoto.Length > 0)
				{
					var fileName = Path.GetFileName(uploadPhoto.FileName);
					var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/categories", fileName);
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await uploadPhoto.CopyToAsync(stream);
					}
                    category.Image = fileName;
				}
				context.Categories.Add(category);
				context.SaveChanges();
				TempData["success"] = "Add successfull!";
				return RedirectToAction("Index");
			}
			return View(category);
		}

        public IActionResult Detail(int id = 0)
        {
            var p = categoryRepositoy.getById(id);
            return View(p);
        }

        [HttpGet]
        public IActionResult Edit(int id = 0)
        {
            var p = categoryRepositoy.getById(id);
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category, IFormFile? uploadPhoto)
        {
            if (ModelState.IsValid)
            {
                //Xử lý với ảnh upload
                if (uploadPhoto != null && uploadPhoto.Length > 0)
                {
                    var fileName = Path.GetFileName(uploadPhoto.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/categories", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadPhoto.CopyToAsync(stream);
                    }
                    category.Image = fileName;
                }
                context.Categories.Update(category);
                context.SaveChanges();
                TempData["success"] = "Update successfull!";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            var p = categoryRepositoy.getById(id);
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Category category)
        {
            var categoryObj = categoryRepositoy.getById(id);
            context.Categories.Remove(categoryObj);
            context.SaveChanges();
            TempData["success"] = "Delete successfull!";
            return RedirectToAction("Index");
        }
    }
}
