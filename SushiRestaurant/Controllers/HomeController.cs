/*using ECommerceSysCore.Models;
using ECommerceSysCore.Models.DTO;
using ECommerceSysCore.Repository;
using ECommerceSysCore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Diagnostics;

namespace ECommerceSysCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SushiRestaurantContext context;
        private readonly ProductRepository productRepository = null;

        public HomeController(ILogger<HomeController> logger, SushiRestaurantContext context)
        {
            _logger = logger;
            this.context = context;
            productRepository = new ProductRepository(context);
        }

        public IActionResult Index()
        {

            var listBestSeller = productRepository.getTop6BestSeller();
            var listNewest = productRepository.getTop6Newest();
            HomeDTO product_Reservation = new HomeDTO();
            product_Reservation.BestSellerProducts = listBestSeller;
            product_Reservation.NewestProducts = listNewest;
            product_Reservation.Reservation = new Reservation();
            var userData = AccountUtils.GetUserData(User);
            if (userData != null)
            {
                Reservation r = new Reservation();
                r.CustomerName = userData.UserName;
                r.Email = userData.Email;
                product_Reservation.Reservation = r;
            }

            //var data = productRepository.getTop5BestSeller();
            return View(product_Reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reservation([Bind(Prefix = "Reservation")] Reservation pr)
        {
            var userData = AccountUtils.GetUserData(User);
            //if (userData != null)
            //{
            //var listBestSeller = objModel.Products.SqlQuery("with R as(select p.ProductID, sum(o.Quantity) SL from Product p, OrderDetail o where p.ProductID = o.ProductID group by p.ProductID) select top 5 p.* from R, Product p where R.ProductID = p.ProductID order by R.SL desc").ToList();
            //pr.ListProduct = listBestSeller;
            //List<SelectListItem> numOfGuests = new List<SelectListItem>();
            //numOfGuests.Add(new SelectListItem { Text = "Number Of Guests", Value = "0", Selected = true });
            //numOfGuests.Add(new SelectListItem { Text = "1", Value = "1" });
            //numOfGuests.Add(new SelectListItem { Text = "2", Value = "2" });
            //numOfGuests.Add(new SelectListItem { Text = "3", Value = "3" });
            //numOfGuests.Add(new SelectListItem { Text = "4", Value = "4" });
            //ViewBag.numOfGuests = numOfGuests;

            //List<SelectListItem> timeReservation = new List<SelectListItem>();
            //timeReservation.Add(new SelectListItem { Text = "Time", Value = "Time", Selected = true });
            //timeReservation.Add(new SelectListItem { Text = "Breakfast", Value = "Breakfast" });
            //timeReservation.Add(new SelectListItem { Text = "Lunch", Value = "Lunch" });
            //timeReservation.Add(new SelectListItem { Text = "Dinner", Value = "Dinner" });
            //ViewBag.timeReservation = timeReservation;
            if (ModelState.IsValid)
            {
                if (pr.ReservationDate < DateTime.Today)
                {
                    TempData["error"] = "Reservation Fail!!! The reservation date must be greater than the current date!";
                    ModelState.AddModelError("Reservation.ReservationDate", "The reservation date must be greater than the current date!");
                }
                else if (pr.Time == null)
                {
                    TempData["error"] = "Reservation Fail!!! Please choose the time!";
                    ModelState.AddModelError("Reservation.Time", "Please choose the time!");
                }
                else if (pr.ReservationDate == DateTime.Today && pr.Time <= DateTime.Now.TimeOfDay)
                {
                    TempData["error"] = "Reservation Fail!!! Please select a future date and time.";
                    ModelState.AddModelError("Reservation.Time", "Please select a future date and time.");
                }
                else if (pr.Location == null)
                {
                    TempData["error"] = "Reservation Fail!!! Please select location.";
                    ModelState.AddModelError("Reservation.Location", "Please select location.");
                }
                else
                {

                    pr.UserId = userData != null ? userData.UserId : null;
                    pr.Status = true;
                    context.Reservations.Add(pr);
                    context.SaveChanges();
                    TempData["success"] = "Reservation successfully!!!";
                    return RedirectToAction("Index");
                }
            }
            var listBestSeller = productRepository.getTop6BestSeller();
            var listNewest = productRepository.getTop6Newest();
            HomeDTO product_Reservation = new HomeDTO();
            product_Reservation.BestSellerProducts = listBestSeller;
            product_Reservation.NewestProducts = listNewest;
            product_Reservation.Reservation = new Reservation();
            return View("Index", product_Reservation);
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
*/




using ECommerceSysCore.Models;
using ECommerceSysCore.Models.DTO;
using ECommerceSysCore.Repository;
using ECommerceSysCore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace ECommerceSysCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SushiRestaurantContext context;
        private readonly ProductRepository productRepository = null;

        public HomeController(ILogger<HomeController> logger, SushiRestaurantContext context)
        {
            _logger = logger;
            this.context = context;
            productRepository = new ProductRepository(context);
        }

        public IActionResult Index()
        {

            var listBestSeller = productRepository.getTop6BestSeller();
            var listNewest = productRepository.getTop6Newest();
            HomeDTO product_Reservation = new HomeDTO();
            product_Reservation.BestSellerProducts = listBestSeller;
            product_Reservation.NewestProducts = listNewest;
            product_Reservation.Reservation = new Reservation();
            var userData = AccountUtils.GetUserData(User);
            if (userData != null)
            {
                Reservation r = new Reservation();
                r.CustomerName = userData.UserName;
                r.Email = userData.Email;
                product_Reservation.Reservation = r;
            }

            //var data = productRepository.getTop5BestSeller();
            return View(product_Reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reservation([Bind(Prefix = "Reservation")] Reservation pr)
        {
            var userData = AccountUtils.GetUserData(User);
            //if (userData != null)
            //{
            //var listBestSeller = objModel.Products.SqlQuery("with R as(select p.ProductID, sum(o.Quantity) SL from Product p, OrderDetail o where p.ProductID = o.ProductID group by p.ProductID) select top 5 p.* from R, Product p where R.ProductID = p.ProductID order by R.SL desc").ToList();
            //pr.ListProduct = listBestSeller;
            //List<SelectListItem> numOfGuests = new List<SelectListItem>();
            //numOfGuests.Add(new SelectListItem { Text = "Number Of Guests", Value = "0", Selected = true });
            //numOfGuests.Add(new SelectListItem { Text = "1", Value = "1" });
            //numOfGuests.Add(new SelectListItem { Text = "2", Value = "2" });
            //numOfGuests.Add(new SelectListItem { Text = "3", Value = "3" });
            //numOfGuests.Add(new SelectListItem { Text = "4", Value = "4" });
            //ViewBag.numOfGuests = numOfGuests;

            //List<SelectListItem> timeReservation = new List<SelectListItem>();
            //timeReservation.Add(new SelectListItem { Text = "Time", Value = "Time", Selected = true });
            //timeReservation.Add(new SelectListItem { Text = "Breakfast", Value = "Breakfast" });
            //timeReservation.Add(new SelectListItem { Text = "Lunch", Value = "Lunch" });
            //timeReservation.Add(new SelectListItem { Text = "Dinner", Value = "Dinner" });
            //ViewBag.timeReservation = timeReservation;
            if (ModelState.IsValid)
            {
                if (pr.ReservationDate < DateTime.Today)
                {
                    TempData["error"] = "Đặt bàn thất bại!!! Ngày đặt bàn phải lớn hơn ngày giờ hiện tại!";
                    ModelState.AddModelError("Reservation.ReservationDate", "The reservation date must be greater than the current date!");
                }
                else if (pr.Time == null)
                {
                    TempData["error"] = "Reservation Fail!!! Please choose the time!";
                    ModelState.AddModelError("Reservation.Time", "Please choose the time!");
                }
                else if (pr.ReservationDate == DateTime.Today && pr.Time <= DateTime.Now.TimeOfDay)
                {
                    TempData["error"] = "Reservation Fail!!! Please select a future date and time.";
                    ModelState.AddModelError("Reservation.Time", "Please select a future date and time.");
                }
                else if (pr.Location == null)
                {
                    TempData["error"] = "Reservation Fail!!! Please select location.";
                    ModelState.AddModelError("Reservation.Location", "Please select location.");
                }
                else
                {

                    pr.UserId = userData != null ? userData.UserId : null;
                    pr.Status = true;
                    context.Reservations.Add(pr);
                    context.SaveChanges();
                    TempData["success"] = "Đặt bàn thành công!!!";
                    try
                    {
						/*                        using (MailMessage message = new MailMessage("sushia.contactus@gmail.com", pr.Email))
                                                {
                                                    message.Subject = "Reservation Confirmation";
                                                    message.Body = $"Dear {pr.CustomerName},\n\nYour reservation for {pr.ReservationDate} at {pr.Time} has been successfully made.";
                                                    message.IsBodyHtml = false;
                                                    using (SmtpClient smtp = new SmtpClient())
                                                    {
                                                        smtp.Host = "smtp.gmail.com";
                                                        smtp.EnableSsl = true;
                                                        NetworkCredential networkCredential = new NetworkCredential("sushia.contactus@gmail.com", "fzqp zrjf zbuy ufzh");
                                                        smtp.UseDefaultCredentials = false;
                                                        smtp.Credentials = networkCredential;
                                                        smtp.Port = 587;
                                                        smtp.Send(message);
                                                    }
                                                }*/
						using (MailMessage message = new MailMessage("sushia.contactus@gmail.com", pr.Email))
						{
							message.Subject = "Xác Nhận Đặt Chỗ";

							// Define the HTML body of the email
							message.Body = $@"
                             <html>
                             <head>
                                 <style>
                                     @font-face {{
                                         font-family: 'Open Sans';
                                         font-style: normal;
                                         font-weight: 400;
                                         src: local('Open Sans Regular'), local('OpenSans-Regular'), url(https://fonts.gstatic.com/s/opensans/v20/mem8YaGs126MiZpBA-U1UpcaXcl0Aw.ttf) format('truetype');
                                     }}
                                     body {{
                                         font-family: 'Open Sans', Arial, sans-serif;
                                         background-color: #f4f4f4;
                                         margin: 0;
                                         padding: 0;
                                         -webkit-font-smoothing: antialiased;
                                         -moz-osx-font-smoothing: grayscale;
                                     }}
                                     .container {{
                                         background-color: #ffffff;
                                         width: 100%;
                                         max-width: 660px;
                                         margin: 0 auto;
                                         padding: 20px;
                                         box-shadow: 0 0 10px rgba(0,0,0,0.1);
                                         border-radius: 10px;
                                     }}
                                     .header {{
                                         text-align: center;
                                         background-color: #FF6F61;
                                         color: #ffffff;
                                         padding: 20px;
                                         border-radius: 10px 10px 0 0;
                                         position: relative;
                                     }}
                                     .header img {{
                                         max-width: 100px; /* Adjust the width based on the logo size */
                                         border-radius: 50%;
                                         margin-bottom: 10px;
                                     }}
                                     .header h1 {{
                                         margin: 10px 0;
                                     }}
                                     .content {{
                                         padding: 20px;
                                         color: #666666;
                                     }}
                                     .content p {{
                                         margin: 10px 0;
                                         line-height: 1.5;
                                     }}
                                     .reservation-details {{
                                         background-color: #f9f9f9;
                                         padding: 15px;
                                         border-radius: 5px;
                                         margin: 20px 0;
                                     }}
                                     .reservation-details h3 {{
                                         margin-top: 0;
                                     }}
                                     .button {{
                                         display: inline-block;
                                         margin: 20px 0;
                                         padding: 10px 20px;
                                         color: #ffffff;
                                         background-color: #FF6F61;
                                         border-radius: 5px;
                                         text-decoration: none;
                                         transition: background-color 0.3s ease;
                                         font-weight: bold;
                                     }}
                                     .button:hover {{
                                         background-color: #e55d53;
                                     }}
                                     .footer {{
                                         text-align: center;
                                         color: #888888;
                                         font-size: 12px;
                                         padding: 20px;
                                         background-color: #f4f4f4;
                                         border-radius: 0 0 10px 10px;
                                     }}
                                     .map {{
                                         width: 100%;
                                         height: 200px;
                                         border: none;
                                         margin-top: 20px;
                                         border-radius: 5px;
                                     }}
                                 </style>
                             </head>
                             <body>
                                 <div class='container'>
                                     <div class='header'>
                                         <img src='.../assets/img/sushi-logo.png' alt='Sushia Logo'>
                                         <h1>Chúc Mừng! Đặt Chỗ Thành Công</h1>
                                     </div>
                                     <div class='content'>
                                         <p>Xin chào {pr.CustomerName},</p>
                                         <p>Cảm ơn bạn đã đặt chỗ tại Sushia. Chi tiết đặt chỗ của bạn như sau:</p>
                                         <div class='reservation-details'>
                                             <h3>Chi Tiết Đặt Chỗ</h3>
                                             <p><strong>Ngày:</strong> {pr.ReservationDate}</p>
                                             <p><strong>Thời gian:</strong> {pr.Time}</p>
                                             <p><strong>Số khách:</strong> {pr.NumOfGuests}</p>
                                             <p><strong>Địa điểm:</strong> {pr.Location}</p>
                                             <p><strong>Yêu cầu đặc biệt:</strong> {pr.Message}</p>
                                         </div>
                                         <p>Nơi đặt chỗ tại:</p>
                                         <p>
                                             Sushia Restaurant<br>
                                             Quận 9, TP. Thủ Đức<br>
                                             Điện thoại: (123) 456-7890
                                         </p>
                                         <div class='map'>
                                             <iframe 
                                                 src='https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.427642206537!2d106.78279807516923!3d10.855042689298537!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317527c3debb5aad%3A0x5fb58956eb4194d0!2zxJDhuqFpIEjhu41jIEh1dGVjaCBLaHUgRQ!5e0!3m2!1svi!2s!4v1716563846121!5m2!1svi!2s'
                                                 class='map'
                                                 allowfullscreen=''
                                                 loading='lazy'
                                                 referrerpolicy='no-referrer-when-downgrade'>
                                             </iframe>
                                         </div>
                                         <a class='button' href='https://www.sushiarestaurant.com'>Xem Chi Tiết Tại Website</a>
                                         <p>Chúng tôi rất mong được đón tiếp bạn!</p>
                                     </div>
                                     <div class='footer'>
                                         <p>&copy; 2024 Sushia. Mọi quyền được bảo lưu.</p>
                                     </div>
                                 </div>
                             </body>
                             </html>";
							message.IsBodyHtml = true;

							using (SmtpClient smtp = new SmtpClient())
							{
								smtp.Host = "smtp.gmail.com";
								smtp.EnableSsl = true;
								NetworkCredential networkCredential = new NetworkCredential("sushia.contactus@gmail.com", "fzqp zrjf zbuy ufzh");
								smtp.UseDefaultCredentials = false;
								smtp.Credentials = networkCredential;
								smtp.Port = 587;
								smtp.Send(message);
							}
						}
					}
                    catch (Exception ex)
                    {
                        // Xử lý lỗi gửi mail (nếu cần)
                        _logger.LogError($"Error sending email: {ex.Message}");
                    }
                    return RedirectToAction("Index");
                }
            }

            var listBestSeller = productRepository.getTop6BestSeller();
            var listNewest = productRepository.getTop6Newest();
            HomeDTO product_Reservation = new HomeDTO();
            product_Reservation.BestSellerProducts = listBestSeller;
            product_Reservation.NewestProducts = listNewest;
            product_Reservation.Reservation = new Reservation();
            return View("Index", product_Reservation);
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}