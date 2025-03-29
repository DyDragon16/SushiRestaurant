using ECommerceSysCore.Models;
using ECommerceSysCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ECommerceSysCore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class OrderController : Controller
	{
		private readonly SushiRestaurantContext context;
        private readonly OrderRepository orderRepository = null;
        private readonly OrderDetailRepository orderDetailRepository = null;
        public OrderController(SushiRestaurantContext context)
		{
			this.context = context;
            orderRepository = new OrderRepository(context);
            orderDetailRepository = new OrderDetailRepository(context);
        }
		public IActionResult Index(int page = 1)
		{
            var pageNumber = page;
            var pageSize = 10;
            var lstOrder = orderRepository.getAll().OrderByDescending(p => p.OrderId).ToPagedList(pageNumber, pageSize);
            return View(lstOrder);
		}

        public IActionResult Detail(int id)
        {
            var result = context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Product).FirstOrDefault(o => o.OrderId == id);
            return View(result);
        }

        public IActionResult PaymentConfirm(int id)
        {
            var result = orderRepository.getById(id);
            result.PaymentProcess = "Completed";
            context.SaveChanges();
            TempData["success"] = "Payment Confirm successfull!";
            return RedirectToAction("Index");
        }

        public IActionResult Cancel(int id)
        {
            var result = orderRepository.getById(id);
            result.Status = false;
            context.SaveChanges();
            TempData["success"] = "Cancel successfull!";
            return RedirectToAction("Index");
        }
    }
}
