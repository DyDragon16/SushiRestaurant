using ECommerceSysCore.Libraries;
using ECommerceSysCore.Models;
using ECommerceSysCore.Models.DTO;
using ECommerceSysCore.Repository;
using ECommerceSysCore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSysCore.Controllers
{
    [Authorize]
    public class CheckOutController : Controller
    {
        private readonly SushiRestaurantContext context;
        private readonly IVnPayService vnPayService;
        private readonly ProductRepository productRepository = null;
        public CheckOutController(SushiRestaurantContext context, IVnPayService vnPayService)
        {
            this.context = context;
            productRepository = new ProductRepository(context);
            this.vnPayService = vnPayService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Item> cart = SessionUtils.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
            }
            ViewBag.Cart = cart;
            ViewBag.Total = string.Format("{0:0.00}",cart.Sum(x => x.Quantity * x.Product.Price));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Order order)
        {
            List<Item> cart = SessionUtils.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (ModelState.IsValid)
            {
               /* var userData = AccountUtils.GetUserData(User);
                if (userData != null)
                {
                    order.UserId = userData.UserId;
                }
                else
                {
                    // Handle the case where userData is null
                   
                }*/
                order.UserId = AccountUtils.GetUserData(User)?.UserId;
                order.TotalPrice = cart.Sum(x => x.Quantity * x.Product.Price);
                order.OrderDate = DateTime.Now;
                order.TypeOrder = "Online";
                order.Status = true; //delete or not

                if (order.PaymentMethod == "COD")
                {
                    order.PaymentProcess = "Processing";
                    context.Orders.Add(order);
                    context.SaveChanges();

                    foreach (var item in cart)
                    {
                        OrderDetail orderDetail = new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = item.Product.ProductId,
                            Quantity = item.Quantity,
                            UnitPrice = item.Quantity * item.Product.Price
                        };
                        context.OrderDetails.Add(orderDetail);
                        context.SaveChanges();

                        Product p = productRepository.getById(item.Product.ProductId);
                        p.Quantity -= item.Quantity;
                        context.Update(p);
                        context.SaveChanges();
                    }
                    HttpContext.Session.Remove("cart");
                }
                else if (order.PaymentMethod == "VNPay")
                {
                    order.PaymentProcess = "Completed";
                    PaymentInformationModel model = new PaymentInformationModel()
                    {
                        Order = order
                    };
                    var url = vnPayService.CreatePaymentUrl(model, HttpContext);
                    return Redirect(url);
                }
                TempData["success"] = "Order successful!";
                return RedirectToAction("Index");
            }

            if (cart == null)
            {
                cart = new List<Item>();
            }
            ViewBag.Cart = cart;
            ViewBag.Total = string.Format("{0:0.00}", cart.Sum(x => x.Quantity * x.Product.Price));
            return View(order);
        }

        public IActionResult PaymentCallback(Order order)
        {
            var response = vnPayService.PaymentExecute(Request.Query);
            if (response.VnPayResponseCode == "00")
            {
                order.UserId = AccountUtils.GetUserData(User).UserId;
                List<Item> cart = SessionUtils.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                order.TotalPrice = cart.Sum(x => x.Quantity * x.Product.Price);
                order.OrderDate = DateTime.Now;
                order.TypeOrder = "Online";
                order.Status = true; //delete or not
                order.PaymentProcess = "Completed";
                order.PaymentMethod = "VNPay";
                context.Orders.Add(order);
                context.SaveChanges();

                foreach (var item in cart)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = item.Product.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Quantity * item.Product.Price
                    };
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();

                    Product p = productRepository.getById(item.Product.ProductId);
                    p.Quantity -= item.Quantity;
                    context.Update(p);
                    context.SaveChanges();
                }
                HttpContext.Session.Remove("cart");
                TempData["success"] = "Order successfull!";
            }
            else
            {
                TempData["error"] = "Order fail!";
            }
            return RedirectToAction("Index");
        }
    }
}
