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
        // Repos
        private readonly PatientRepository patientRepository;
        private readonly DoctorRepository doctorRepository;

        // Converter
        private readonly PatientViewModelConverter patientConverter;

        // Account management
        private readonly UserManager<BaseAccount> userManager;
        private readonly SignInManager<BaseAccount> signInManager;

        /// <summary>
        /// Constructor for homecontroller
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="patientRepository"></param>
        /// <param name="doctorRepository"></param>
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

        /// <summary>
        /// Login view
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Login post
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Check if is valid
            if (ModelState.IsValid)
            {
                if (username != null)
                {
                    // Check login
                    var result = await signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

                    // If success
                    if (result.Succeeded)
                    {
                        // Send to dashboard
                        return RedirectToAction("dashboard");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            // Check if authenticated
            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                // Signout
                await signInManager.SignOutAsync();
            }

            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
