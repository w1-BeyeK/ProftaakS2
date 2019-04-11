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
        private readonly DoctorViewModelConverter doctorConverter;

        public ProfileController(
            PatientRepository patientRepository,
            DoctorRepository doctorRepository
            )
        {
            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;

            patientConverter = new PatientViewModelConverter();
            doctorConverter = new DoctorViewModelConverter();
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
                    Patient patient = patientRepository.GetById(id);
                    viewModel.Patient = patientConverter.PatientToViewModel(patient);
                }
                else if (HttpContext.User.IsInRole("doctor"))
                {
                    Doctor doctor = doctorRepository.GetById(id);
                    viewModel.Doctor = doctorConverter.DoctorToViewModel(doctor);
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
                    Patient patient = patientRepository.GetById(id);
                    viewModel.Patient = patientConverter.PatientToViewModel(patient);
                }
                else if (HttpContext.User.IsInRole("doctor"))
                {
                    Doctor doctor = doctorRepository.GetById(id);
                    viewModel.Doctor = doctorConverter.DoctorToViewModel(doctor);
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel viewModel)
        {
            var id = GetUserId();
            

            if (HttpContext.User.IsInRole("patient"))
            {
                viewModel.Patient.Id = id;
                //  PatientDetailViewModel patientDetailViewModel = new PatientDetailViewModel();
                Patient patient = patientConverter.ViewModelToPatient(viewModel.Patient);
                patientRepository.Update(patient);
            }
            else if (HttpContext.User.IsInRole("doctor"))
            {
                viewModel.Doctor.EmployeeNumber = id;
                Doctor doctor = doctorConverter.ViewModelToDoctor(viewModel.Doctor);
                doctorRepository.Update(doctor);
            }
            return RedirectToAction("index","Profile");
        }
    }
}