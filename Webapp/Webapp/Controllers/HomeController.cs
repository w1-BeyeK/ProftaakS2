using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<BaseAccount> userManager;
        private readonly SignInManager<BaseAccount> signInManager;

        public HomeController(
                UserManager<BaseAccount> userManager,
                SignInManager<BaseAccount> signInManager
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "patient")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<IActionResult> Test()
        {
            var x = userManager.PasswordHasher.HashPassword(new Patient(5, "test", "Test1234!"), "Test123!");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("about");
                }
                else
                {
                    return View();
                }
            }
            return View();

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
