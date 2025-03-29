using ECommerceSysCore.Models;
using ECommerceSysCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace ECommerceSysCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReservationController : Controller
    {
        private readonly SushiRestaurantContext context;
        private readonly ReservationRepository reservationRepository = null;
        public ReservationController(SushiRestaurantContext context)
        {
            this.context = context;
            reservationRepository = new ReservationRepository(context);
        }
        public IActionResult Index(int page = 1)
        {
            var pageNumber = page;
            var pageSize = 10;
            var lstRes = reservationRepository.getAll().OrderByDescending(p => p.ReservationId).ToPagedList(pageNumber, pageSize);
            return View(lstRes);
        }

        public IActionResult Detail(int id)
        {
            var lstRes = reservationRepository.getById(id);
            return View(lstRes);
        }

        public IActionResult Cancel(int id)
        {
            var result = reservationRepository.getById(id);
            result.Status = false;
            context.SaveChanges();
            TempData["success"] = "Cancel successfull!";
            return RedirectToAction("Index");
        }
    }
}
