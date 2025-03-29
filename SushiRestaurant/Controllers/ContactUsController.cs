using ECommerceSysCore.Libraries;
using ECommerceSysCore.Models;
using ECommerceSysCore.Models.DTO;
using ECommerceSysCore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace ECommerceSysCore.Controllers
{
    public class ContactUsController : Controller
	{
		private readonly SushiRestaurantContext context;
		public ContactUsController(SushiRestaurantContext context)
		{
			this.context = context;
		}
		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Index(ContactDTO contact)
		{
			var allAdmin = context.Accounts.Where(a => a.RoleId == 3).ToList();
			foreach (var item in allAdmin)
			{
				using (MailMessage message = new MailMessage("sushia.contactus@gmail.com", item.Email))
				{
					message.Subject = contact.Name + " Contact with us";
					message.Body = contact.Name + " with email " + contact.Email + " send a message: " + contact.Message;
					message.IsBodyHtml = false;
					using (SmtpClient smtp = new SmtpClient())
					{
						smtp.Host = "smtp.gmail.com";
						smtp.EnableSsl = true;
						NetworkCredential network = new NetworkCredential("sushia.contactus@gmail.com", "fzqp zrjf zbuy ufzh");
						smtp.UseDefaultCredentials = false;
						smtp.Credentials = network;
						smtp.Port = 587;
						smtp.Send(message);
					}
				}
			}
			TempData["success"] = "Send successfull!";
			return View("Index");
		}
	}
}
