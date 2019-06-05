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
        private readonly TreatmentRepository treatmentRepository;

        // Converter
        private readonly PatientViewModelConverter patientConverter;
        private readonly TreatmentViewModelConverter treatmentConverter;

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
                DoctorRepository doctorRepository,
                TreatmentRepository treatmentRepository
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;
            this.treatmentRepository = treatmentRepository;

            this.patientConverter = new PatientViewModelConverter();
            this.treatmentConverter = new TreatmentViewModelConverter();
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
            if(User.IsInRole("patient"))
            {
                List<Treatment> treatments = treatmentRepository.GetUnconfirmedTreatmentsByPatient(GetUserId());
                List<TreatmentDetailViewModel> Treatments = new List<TreatmentDetailViewModel>(treatmentConverter.ModelsToViewModel(treatments));
                return View(Treatments);
            }
            return View();
        }

       
        [Authorize(Roles = "patient")]
        public IActionResult Accept(long id)
        {
            if (id < 1)
                return BadRequest("Id kan niet 0 zijn.");
            try
            {
                Treatment treatment = treatmentRepository.GetById(id);
                if (treatment.PatientId == GetUserId())
                {
                    treatmentRepository.PatientGiveAccessToDoctor(id, true);
                }
                else
                {
                    return BadRequest("U heeft geen toegang tot deze behandeling.");
                }
            }
            catch
            {
                return BadRequest("Geen behandeling gevonden.");
            }
            return RedirectToAction("Dashboard");
        }

        [Authorize(Roles = "patient")]
        public IActionResult Deny(long id)
        {
            if (id < 1)
                return BadRequest("Id kan niet 0 zijn.");
            try
            {
                Treatment treatment = treatmentRepository.GetById(id);
                if (treatment.PatientId == GetUserId())
                {
                    treatmentRepository.PatientGiveAccessToDoctor(id, false);
                }
                else
                {
                    return BadRequest("U heeft geen toegang tot deze behandeling.");
                }
            }
            catch
            {
                return BadRequest("Geen behandeling gevonden.");
            }
            return RedirectToAction("Dashboard");
        }
    }
}
