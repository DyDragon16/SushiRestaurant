using ECommerceSysCore.Models;
using ECommerceSysCore.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace ECommerceSysCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly SushiRestaurantContext context;

        public AccountController(SushiRestaurantContext context)
        {
            this.context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Account account)
        {
            //don't need check username
            ModelState.Remove("UserName");
            //validate data
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var user = context.Accounts.Include(r => r.Role).Where(a => a.Email == account.Email && a.Password == account.Password).FirstOrDefault();
                if (user != null)
                {
                    // Thông tin người dùng dưới dạng danh sách các Claim
                    List<Claim> claims = new List<Claim>()
                {
                    new Claim(nameof(user.UserId), user.UserId.ToString()),
                    new Claim(nameof(user.UserName), user.UserName ?? ""),
                    new Claim(nameof(user.Password), user.Password ?? ""),
                    new Claim(nameof(user.RoleId), user.RoleId.ToString()),
                    new Claim(nameof(user.Email), user.Email ?? ""),
                    new Claim(nameof(user.Role.RoleName), user.Role.RoleName ?? ""),
                    new Claim(ClaimTypes.Role, user.Role.RoleName)
                };
                    //Thiết lập phiên đăng nhập cho tài khoản
                    await HttpContext.SignInAsync(AccountUtils.CreatePrincipal(claims));

                    //Redirec về trang chủ sau khi đăng nhập
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Error", "Đăng nhập thất bại");
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Account account)
        {
            //validate data
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var user = context.Accounts.Include(r => r.Role).Where(a => a.Email == account.Email).FirstOrDefault();
                if (user == null)
                {
                    account.RoleId = 1;// default role is user
                    context.Accounts.Add(account);
                    context.SaveChanges();

                    TempData["success"] = "Đăng kí thành công";
                    
                    return RedirectToAction("Login");
                }
                //user already existed -> register fail
                ModelState.AddModelError("Error", "Email này đã được đăng kí");
                return View();
            }
        }

        [HttpGet]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        
       [HttpGet]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result?.Principal != null)
            {
                var emailClaim = result.Principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                var nameClaim = result.Principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

                if (emailClaim != null && nameClaim != null)
                {
                    // Log the claims for debugging purposes
                    Console.WriteLine($"Email: {emailClaim.Value}, Name: {nameClaim.Value}");

                    try
                    {
                        var user = context.Accounts.Include(r => r.Role)
                            .Where(a => a.Email == emailClaim.Value)
                            .Select(a => new 
                            {
                                a.UserId,
                                UserName = a.UserName ?? string.Empty,
                                Password = a.Password ?? string.Empty,
                                a.RoleId,
                                Email = a.Email ?? string.Empty,
                                RoleName = a.Role.RoleName ?? "User"
                            })
                            .FirstOrDefault();

                        if (user != null)
                        {
                            // Log the user data for debugging purposes
                            Console.WriteLine($"User found: {user.UserName}, Role: {user.RoleName}");

                            List<Claim> claims = new List<Claim>()
                            {
                                new Claim(nameof(user.UserId), user.UserId.ToString()),
                                new Claim(nameof(user.UserName), user.UserName),
                                // Do not include password claim for Google authenticated users
                                new Claim(nameof(user.RoleId), user.RoleId.ToString()),
                                new Claim(nameof(user.Email), user.Email),
                                new Claim(nameof(user.RoleName), user.RoleName),
                                new Claim(ClaimTypes.Role, user.RoleName)
                            };

                            await HttpContext.SignInAsync(AccountUtils.CreatePrincipal(claims));
                        }
                        else
                        {
                            // Log for debugging purposes
                            Console.WriteLine($"User not found, creating a new one for Email: {emailClaim.Value}");

                            var newUser = new Account
                            {
                                UserName = nameClaim.Value,
                                Email = emailClaim.Value,
                                RoleId = 1 // Default role
                            };
                            context.Accounts.Add(newUser);
                            context.SaveChanges();

                            List<Claim> claims = new List<Claim>()
                            {
                                new Claim(nameof(newUser.UserId), newUser.UserId.ToString()),
                                new Claim(nameof(newUser.UserName), newUser.UserName),
                                // Do not include password claim for new Google authenticated users
                                new Claim(nameof(newUser.RoleId), newUser.RoleId.ToString()),
                                new Claim(nameof(newUser.Email), newUser.Email),
                                new Claim(nameof(newUser.Role.RoleName), "User"),
                                new Claim(ClaimTypes.Role, "User")
                            };

                            await HttpContext.SignInAsync(AccountUtils.CreatePrincipal(claims));
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log exception details for debugging
                        Console.WriteLine($"Exception occurred: {ex.Message}");
                        Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                        // Handle the exception appropriately (e.g., show an error message to the user)
                        ModelState.AddModelError("Error", "An error occurred while processing your request.");
                        return View("Error");
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }



        public IActionResult AccessDenined()
        {
            return View();
        }
    }
}
