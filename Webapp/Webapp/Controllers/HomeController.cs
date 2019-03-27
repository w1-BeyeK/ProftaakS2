using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Webapp.Converters;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly PatientRepository patientRepository;
        private readonly DoctorRepository doctorRepository;

        private readonly PatientViewModelConverter patientConverter;

        private readonly UserManager<BaseAccount> userManager;
        private readonly SignInManager<BaseAccount> signInManager;

        public HomeController(
                UserManager<BaseAccount> userManager,
                SignInManager<BaseAccount> signInManager,
                PatientRepository patientRepository,
                DoctorRepository doctorRepository
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;

            this.patientConverter = new PatientViewModelConverter();
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
                    if (HttpContext.User.IsInRole("admin"))
                    {
                        return RedirectToAction("about");
                    }
                    else
                    {
                        return RedirectToAction("index", "profile");
                    }
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
