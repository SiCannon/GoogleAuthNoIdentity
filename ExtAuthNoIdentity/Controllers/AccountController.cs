using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult ExternalLogin(string returnUrl = null)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties()
            {
                RedirectUri = redirectUrl,
                IsPersistent = true
            };
            return Challenge(properties, "Google");
        }

        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            return new RedirectResult(returnUrl);
        }
    }
}