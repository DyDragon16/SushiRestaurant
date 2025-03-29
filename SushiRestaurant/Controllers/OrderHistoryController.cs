using ECommerceSysCore.Models;
using ECommerceSysCore.Repository;
using ECommerceSysCore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Principal;
using X.PagedList;

namespace ECommerceSysCore.Controllers
{
    [Authorize]
    public class OrderHistoryController : Controller
    {
        private readonly SushiRestaurantContext context;
        public OrderHistoryController(SushiRestaurantContext context)
        {
            this.context = context;
        }
        public IActionResult Index(int page = 1)
        {
            var pageNumber = page;
            var pageSize = 6;
            var userData = AccountUtils.GetUserData(User);
            if (userData == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var lstOrder = context.Orders.OrderByDescending(n => n.OrderDate)
                .Where(n => n.UserId == userData.UserId)
                .ToList()
                .ToPagedList(pageNumber, pageSize);
            return View(lstOrder);
        }


        public IActionResult Detail(int? id)
        {
            var order = context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Product).FirstOrDefault(o => o.OrderId == id);
            return View(order);
        }
    }
}