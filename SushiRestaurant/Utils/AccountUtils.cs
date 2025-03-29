using ECommerceSysCore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ECommerceSysCore.Utils
{
    public static class AccountUtils
    {
        /// <summary>
        /// Tạo Pricipal dựa trên thông tin của người dùng
        /// </summary>
        /// <returns></returns>
        public static ClaimsPrincipal CreatePrincipal(List<Claim> Claims)
        {
            var claimIdentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            return claimPrincipal;
        }
        public static Account? GetUserData(ClaimsPrincipal principal)
        {
            try
            {
                if (principal == null || principal.Identity == null || !principal.Identity.IsAuthenticated)
                    return null;

                var userData = new Account();
                userData.UserId = int.Parse(principal.FindFirstValue(nameof(userData.UserId)));
                userData.UserName = principal.FindFirstValue(nameof(userData.UserName)) ?? "";
                userData.Password = principal.FindFirstValue(nameof(userData.Password)) ?? "";
                userData.Email = principal.FindFirstValue(nameof(userData.Email)) ?? "";
                userData.RoleId = int.Parse(principal.FindFirstValue(nameof(userData.RoleId)));
                Role r = new Role()
                {
                    RoleId = (int)userData.RoleId,
                    RoleName = principal.FindFirst(ClaimTypes.Role)?.Value
                };
                userData.Role = r;
                return userData;
            }
            catch
            {
                return null;
            }
        }


    }
}