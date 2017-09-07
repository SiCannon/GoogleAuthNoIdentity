using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExtAuthNoIdentity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = HttpContext.User;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secure()
        {
            return View();
        }
    }
}
