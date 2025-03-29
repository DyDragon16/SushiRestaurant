using Microsoft.AspNetCore.Mvc;

namespace ECommerceSysCore.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
