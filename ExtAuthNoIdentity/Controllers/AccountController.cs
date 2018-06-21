using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ExtAuthNoIdentity.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties()
            {
                RedirectUri = redirectUrl,
                IsPersistent = true
            };

            string scheme =
                provider == "g" ? "Google" :
                provider == "ms" ? "Microsoft" :
                throw new Exception($"Provider {provider} not recognized");

            return Challenge(properties, scheme);
        }

        public IActionResult ExternalLoginCallback(string returnUrl)
        {
            var x = HttpContext.User;

            foreach (var c in x.Claims)
            {
                if (c.Type == "Email")
                {
                    string email = c.Value;
                }
            }

            return new RedirectResult(returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl)
        //{
        //    HttpContext.User.


        //    return new RedirectResult(returnUrl);
        //}
    }
}