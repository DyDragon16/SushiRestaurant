using ECommerceSysCore.Models;
using ECommerceSysCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Globalization;
using X.PagedList;

namespace ECommerceSysCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Staff")]
    public class DashboardController : Controller
    {
        private readonly SushiRestaurantContext context;
        private readonly ReservationRepository reservationRepository = null;
        public DashboardController(SushiRestaurantContext context)
        {
            this.context = context;
            reservationRepository = new ReservationRepository(context);
        }
        public IActionResult Index()
        {
             // Lấy ngày hiện tại
                DateTime currentDate = DateTime.Today;

            //// Tính toán ngày bắt đầu của tuần hiện tại (ngày đầu tiên của tuần, chẳng hạn ngày thứ Hai)
            //DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek + 1);
            //ViewBag.StartDate = startOfWeek;
            // Lấy ngày hiện tại và tuần hiện tại
            int currentWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int currentYear = currentDate.Year;


			DateTime firstDayOfWeek = FirstDateOfWeekISO8601(currentYear, currentWeek);
			ViewBag.StartDate = firstDayOfWeek;

			// Tạo chuỗi đại diện cho tuần hiện tại
			string currentWeekString = $"{currentYear}-W{currentWeek.ToString("00")}";
            ViewBag.CurrentWeek = currentWeekString;

            var lstRes = reservationRepository.getAllWithoutCancel();

            var countReservation = context.Reservations.Where(p => p.Status == true).ToList().Count;
            ViewBag.countReservation = countReservation;
            var itemSolid = context.OrderDetails.Include(c => c.Order).Where(p => p.Order.Status == true).Sum(r => r.Quantity);
            ViewBag.itemSolid = itemSolid;
            var countProduct = context.Products.Where(p => p.Status == true).ToList().Count;
            ViewBag.countProduct = countProduct;
            var totalEarning = context.Orders.Where(o => o.Status == true).Sum(r => r.TotalPrice);
            ViewBag.totalEarning = totalEarning;

            return View(lstRes);
        }

        [HttpPost]
        public IActionResult Search(string week)
        {
            // Get the year and week number from the string
            int year = int.Parse(week.Substring(0, 4));
            int weekNumber = int.Parse(week.Substring(6));

            // Calculate the first day of the week
            DateTime firstDayOfWeek = FirstDateOfWeekISO8601(year, weekNumber);
            ViewBag.StartDate = firstDayOfWeek;
            ViewBag.CurrentWeek = week;
            var lstRes = reservationRepository.getAllWithoutCancel();
            var countReservation = context.Reservations.Where(p => p.Status == true).ToList().Count;
            ViewBag.countReservation = countReservation;
            var itemSolid = context.OrderDetails.Include(c => c.Order).Where(p => p.Order.Status == true).Sum(r => r.Quantity);
            ViewBag.itemSolid = itemSolid;
            var countProduct = context.Products.Where(p => p.Status == true).ToList().Count;
            ViewBag.countProduct = countProduct;
            var totalEarning = context.Orders.Where(o => o.Status == true).Sum(r => r.TotalPrice);
            ViewBag.totalEarning = totalEarning;
            return View("Index", lstRes);
        }

        // Function to calculate the first day of the week based on ISO 8601 week numbering system
        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Calculate the first Thursday of the year
            DateTime firstThursday = jan1.AddDays(daysOffset);

            // Calculate the week number for the first Thursday
            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            int weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            // Calculate the date of the first day of the week
            DateTime firstDayOfWeek = firstThursday.AddDays(weekNum * 7);

            return firstDayOfWeek.AddDays(-3);
        }
    }
}
