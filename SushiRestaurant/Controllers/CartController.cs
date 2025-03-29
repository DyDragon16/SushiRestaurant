using ECommerceSysCore.Models;
using ECommerceSysCore.Models.DTO;
using ECommerceSysCore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSysCore.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		private readonly SushiRestaurantContext context;
		public CartController(SushiRestaurantContext context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			var shoppingCart = SessionUtils.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
			if (shoppingCart == null)
				shoppingCart = new List<Item>();
			return View(shoppingCart);
		}
		public IActionResult Add(int id = 0)
		{
			var p = context.Products.Find(id);
			List<Item> cart = SessionUtils.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
			if (cart == null) //chua có sp trong giỏ
			{
				cart = new List<Item>();  ///tao new list
				cart.Add(new Item { Product = p, Quantity = 1 }); //them sp chưa có vào giỏ
			}
			else //có sp trong giỏ
			{
				Item existingItem = cart.FirstOrDefault(i => i.Product.ProductId == id);
				if (existingItem != null) // Nếu sản phẩm id{?} đã có trong giỏ hàng
				{
					if (existingItem.Quantity < existingItem.Product.Quantity)
					{
						existingItem.Quantity += 1; // Tăng số lượng sản phẩm lên
					}
				}
				else
				{
					cart.Add(new Item { Product = p, Quantity = 1 }); //them sp thuôc id ? chưa có vào giỏ
				}
			}
			SessionUtils.SetObjectAsJson(HttpContext.Session, "cart", cart);
			return RedirectToAction("Index", "Menu");
		}
        public IActionResult Ad(int id = 0)
        {
            List<Item> cart = SessionUtils.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            Item existingItem = cart.FirstOrDefault(i => i.Product.ProductId == id);
            if (existingItem.Quantity < existingItem.Product.Quantity)
            {
                existingItem.Quantity += 1; // Tăng số lượng sản phẩm lên
            }
            else
            {
                cart.Remove(existingItem);
            }
            SessionUtils.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        public IActionResult Sub(int id = 0)
		{
			List<Item> cart = SessionUtils.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
			Item existingItem = cart.FirstOrDefault(i => i.Product.ProductId == id);
			if (existingItem.Quantity > 1)
			{
				existingItem.Quantity -= 1; // Giam số lượng sản phẩm lên
			}
			else
			{
				cart.Remove(existingItem);
			}
			SessionUtils.SetObjectAsJson(HttpContext.Session, "cart", cart);
			return RedirectToAction("Index");
		}
		public IActionResult Remove(int id = 0)
		{
			List<Item> cart = SessionUtils.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
			Item existingItem = cart.FirstOrDefault(i => i.Product.ProductId == id);
cart.Remove(existingItem);
			SessionUtils.SetObjectAsJson(HttpContext.Session, "cart", cart);
			return RedirectToAction("Index");
		}
	}
}