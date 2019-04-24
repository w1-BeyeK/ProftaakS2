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
        private readonly TreatmentTypeRepository treatmentTypeRepository;

        private readonly PatientViewModelConverter patientConverter;
        private readonly DoctorViewModelConverter doctorConverter;
        private readonly TreatmentTypeViewModelConverter typeConverter;

        public ProfileController(
            PatientRepository patientRepository,
            DoctorRepository doctorRepository,
            TreatmentTypeRepository treatmentTypeRepository
            )
        {
            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;
            this.treatmentTypeRepository = treatmentTypeRepository;

            patientConverter = new PatientViewModelConverter();
            doctorConverter = new DoctorViewModelConverter();
            typeConverter = new TreatmentTypeViewModelConverter();
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
                    viewModel.Doctor = doctorConverter.ModelToViewModel(doctor);
                    viewModel.Doctor.TreatmentTypes = typeConverter.ModelsToViewModel(treatmentTypeRepository.GetAll());
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult Inzie(long id)
        {
            try
            {
                UserViewModel viewModel = new UserViewModel();

                if (HttpContext.User.IsInRole("doctor"))
                {
                    Patient patient = patientRepository.GetById(id);
                    viewModel.Patient = patientConverter.PatientToViewModel(patient);
                }
                else if (HttpContext.User.IsInRole("patient"))
                {
                    Doctor doctor = doctorRepository.GetById(id);
                    viewModel.Doctor = doctorConverter.ModelToViewModel(doctor);
                    viewModel.Doctor.TreatmentTypes = typeConverter.ModelsToViewModel(treatmentTypeRepository.GetAll());
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
                long id = GetUserId();

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
                    viewModel.Doctor = doctorConverter.ModelToViewModel(doctor);
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
            long id = GetUserId();
            
            if (HttpContext.User.IsInRole("patient"))
            {
                viewModel.Patient.Id = id;
                Patient patient = patientConverter.ViewModelToPatient(viewModel.Patient);
                patientRepository.Update(patient);
            }
            else if (HttpContext.User.IsInRole("doctor"))
            {
                viewModel.Doctor.EmployeeNumber = id;
                Doctor doctor = doctorConverter.ViewModelToModel(viewModel.Doctor);
                doctorRepository.Update(doctor);
            }
            return RedirectToAction("index","Profile");
        }
    }
}