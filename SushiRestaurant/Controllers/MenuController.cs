using ECommerceSysCore.Models;
using ECommerceSysCore.Models.DTO;
using ECommerceSysCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using X.PagedList;

namespace ECommerceSysCore.Controllers
{
    public class MenuController : Controller
    {
        private readonly SushiRestaurantContext context;
        private readonly ProductRepository productRepository = null;
        private readonly CategoryRepositoy categoryRepositoy = null;
        public MenuController(SushiRestaurantContext context)
        {
            this.context = context;
            productRepository = new ProductRepository(context);
            categoryRepositoy = new CategoryRepositoy(context);
        }
        public IActionResult Index(int page = 1, int categoryId = 0, string txtSearch = "")
        {
            var pageNumber = page;
            var pageSize = 12;
            txtSearch = txtSearch ?? "";

            var productLst = productRepository.getAllByCategoryAndName(categoryId, txtSearch).ToPagedList(pageNumber, pageSize);
            var categoryLst = categoryRepositoy.getAllWithProducts();

            Category all = new Category()
            {
                CategoryId = 0,
                CategoryName = "All",
                Image = "all.jpg"
            };
            categoryLst.Insert(0,all);
            MenuDTO menu = new MenuDTO()
            {
                txtSearch = txtSearch,
                categoryId = categoryId,
                productLst = productLst,
                categoryLst = categoryLst
            };
            ViewBag.NewestProduct = productRepository.getTop6Newest().Take(3);
            return View(menu);
        }

        public IActionResult Detail(int id)
        {
            var product = productRepository.getById(id);
            ViewBag.RelatedProducts = productRepository.getAllByCategoryId(product.CategoryId).Take(6);
            return View(product);
        }
    }
}
