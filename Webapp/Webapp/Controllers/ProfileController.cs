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
    /// <summary>
    /// Controller for profiles
    /// </summary>
    [Authorize(Roles = "patient, doctor")]
    public class ProfileController : BaseController
    {
        /// <summary>
        /// Repositories
        /// </summary>
        private readonly PatientRepository patientRepository;
        private readonly DoctorRepository doctorRepository;
        private readonly TreatmentTypeRepository treatmentTypeRepository;
        private readonly TreatmentRepository treatmentRepository;

        /// <summary>
        /// Converters
        /// </summary>
        private readonly PatientViewModelConverter patientConverter;
        private readonly DoctorViewModelConverter doctorConverter;
        private readonly TreatmentTypeViewModelConverter typeConverter;

        /// <summary>
        /// Default constructor for profiles
        /// </summary>
        /// <param name="patientRepository"></param>
        /// <param name="doctorRepository"></param>
        /// <param name="treatmentTypeRepository"></param>
        /// <param name="treatmentRepository"></param>
        public ProfileController(
            PatientRepository patientRepository,
            DoctorRepository doctorRepository,
            TreatmentTypeRepository treatmentTypeRepository,
            TreatmentRepository treatmentRepository
            )
        {
            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;
            this.treatmentTypeRepository = treatmentTypeRepository;
            this.treatmentRepository = treatmentRepository;

            patientConverter = new PatientViewModelConverter();
            doctorConverter = new DoctorViewModelConverter();
            typeConverter = new TreatmentTypeViewModelConverter();
        }

        /// <summary>
        /// Standard method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            try
            {
                // Get user id
                var id = GetUserId();
                
                // Check if it exists
                if (id < 1)
                    return RedirectToAction("index", "home");

                UserViewModel viewModel = new UserViewModel();

                // Redirect user based on role
                if (HttpContext.User.IsInRole("patient"))
                {
                    Patient patient = patientRepository.GetById(id);
                    viewModel.Patient = patientConverter.ModelToViewModel(patient);
                }
                else if (HttpContext.User.IsInRole("doctor"))
                {
                    Doctor doctor = doctorRepository.GetById(id);
                    viewModel.Doctor = doctorConverter.ModelToViewModel(doctor);
                    //TODO : BY DOCTORID!!!!!!
                    viewModel.Doctor.TreatmentTypes = typeConverter.ModelsToViewModel(treatmentTypeRepository.GetAll());
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get details from doctor
        /// </summary>
        /// <param name="id"> id is docterId</param>
        /// <returns></returns>
        public IActionResult DoctorDetails(long id)
        {
            long userId = GetUserId();
            try
            {
                UserViewModel viewModel = new UserViewModel();

                if (HttpContext.User.IsInRole("doctor"))
                {
                    if (doctorRepository.CheckDoctorRelationship(userId, id))
                    {
                        Doctor doctor = doctorRepository.GetById(id);
                        viewModel.Doctor = doctorConverter.ModelToViewModel(doctor);
                    }
                    else
                    {
                        return RedirectToAction("index", "doctor");
                    }
                }
                else if (HttpContext.User.IsInRole("patient"))
                {
                    if (treatmentRepository.CheckTreatmentRelationship(id, userId))
                    {
                        Doctor doctor = doctorRepository.GetById(id);
                        viewModel.Doctor = doctorConverter.ModelToViewModel(doctor);
                        viewModel.Doctor.TreatmentTypes = typeConverter.ModelsToViewModel(treatmentTypeRepository.GetAll());
                    }
                    else
                    {
                        return RedirectToAction("index", "treatment");
                    }
                }
                else
                {
                    return Unauthorized();
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get details from patient
        /// </summary>
        /// <param name="id"> id is patientId</param>
        /// <returns></returns>
        [Authorize(Roles = "doctor")]
        public IActionResult PatientDetails(long id)
        {
            long userId = GetUserId();
            try
            {
                UserViewModel viewModel = new UserViewModel();

                if (treatmentRepository.CheckTreatmentRelationship(userId, id))
                {
                    Patient patient = patientRepository.GetById(id);
                    viewModel.Patient = patientConverter.ModelToViewModel(patient);
                }
                else
                {
                    return RedirectToAction("index", "patient");
                }
                return View(viewModel);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Edit profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit()
        {
            try
            {
                // Get and validate user id
                long id = GetUserId();

                if (id < 1)
                    return RedirectToAction("index", "home");

                UserViewModel viewModel = new UserViewModel();

                if (HttpContext.User.IsInRole("patient"))
                {
                    Patient patient = patientRepository.GetById(id);
                    viewModel.Patient = patientConverter.ModelToViewModel(patient);
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

        /// <summary>
        /// Post for update user
        /// </summary>
        /// <param name="viewModel">Model to update</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(UserViewModel viewModel)
        {
            // Get user id
            long id = GetUserId();
            
            // Execute correct action based on role
            if (HttpContext.User.IsInRole("patient"))
            {
                viewModel.Patient.Id = id;
                Patient patient = patientConverter.ViewModelToModel(viewModel.Patient);
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