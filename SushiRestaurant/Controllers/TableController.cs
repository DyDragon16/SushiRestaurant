using Microsoft.AspNetCore.Mvc;

namespace ECommerceSysCore.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
