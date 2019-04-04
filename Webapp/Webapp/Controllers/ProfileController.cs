using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webapp.Converters;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    [Authorize(Roles = "patient, doctor")]
    public class ProfileController : BaseController
    {
        private readonly PatientRepository patientRepository;
        private readonly DoctorRepository doctorRepository;

        private readonly PatientViewModelConverter patientConverter;

        public ProfileController(
            PatientRepository patientRepository,
            DoctorRepository doctorRepository
            )
        {
            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;

            patientConverter = new PatientViewModelConverter();
        }

        public IActionResult Index()
        {
            try
            {
                var id = GetUserId();

                if (id < 1)
                    return RedirectToAction("index", "home");

                UserViewModel viewModel = new UserViewModel();

                if (HttpContext.User.IsInRole("patient"))
                {
                    Patient patient = patientRepository.GetPatientById(id);
                    viewModel.Patient = patientConverter.PatientToViewModel(patient);
                }
                else if (HttpContext.User.IsInRole("doctor"))
                {
                    Doctor doctor = doctorRepository.GetDoctorById(id);
                    viewModel.Doctor = doctor;
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Edit()
        {
            try
            {
                var id = GetUserId();

                if (id < 1)
                    return RedirectToAction("index", "home");

                UserViewModel viewModel = new UserViewModel();

                if (HttpContext.User.IsInRole("patient"))
                {
                    Patient patient = patientRepository.GetPatientById(id);
                    viewModel.Patient = patientConverter.PatientToViewModel(patient);
                }
                else if (HttpContext.User.IsInRole("doctor"))
                {
                    Doctor doctor = doctorRepository.GetDoctorById(id);
                    viewModel.Doctor = doctor;
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}