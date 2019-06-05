using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webapp.Context;
using Webapp.Converters;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    /// <summary>
    /// Treatment controller
    /// </summary>
    [Authorize(Roles = "doctor, patient")]
    public class TreatmentController : BaseController
    {
        /// <summary>
        /// Repos
        /// </summary>
        private readonly TreatmentRepository treatmentRepository;
        private readonly PatientRepository patientRepository;
        private readonly TreatmentTypeRepository treatmentTypeRepository;
        private readonly CommentRepository commentRepository;

        /// <summary>
        /// Converters
        /// </summary>
        private readonly TreatmentViewModelConverter TreatmentConverter = new TreatmentViewModelConverter();
        private readonly PatientViewModelConverter PatientConverter = new PatientViewModelConverter();
        private readonly TreatmentTypeViewModelConverter TypeConverter = new TreatmentTypeViewModelConverter();

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="treatmentRepository"></param>
        /// <param name="patientRepository"></param>
        /// <param name="treatmentTypeRepository"></param>
        public TreatmentController(
            TreatmentRepository treatmentRepository, 
            PatientRepository patientRepository, 
            TreatmentTypeRepository treatmentTypeRepository,
            CommentRepository commentRepository
            )
        {
            this.treatmentRepository = treatmentRepository;
            this.patientRepository = patientRepository;
            this.treatmentTypeRepository = treatmentTypeRepository;
            this.commentRepository = commentRepository;
        }

        /// <summary>
        /// Page of treatment detail
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // Get by role
            List<Treatment> items = new List<Treatment>();
            if (User.IsInRole("doctor"))
            {
                items = treatmentRepository.GetByDoctor(GetUserId());
                
            }
            else if (User.IsInRole("patient"))
            {
                items = treatmentRepository.GetByPatient(GetUserId());
            }

            // Parse to viewmodel
            TreatmentViewModel vm = new TreatmentViewModel()
            {
                treatments = new List<TreatmentDetailViewModel>()
            };
            // add treatments
            foreach (Treatment treatment in items)
            {
                vm.treatments.Add(TreatmentConverter.ModelToViewModel(treatment));
            }

            // Return view with treatments
            return View(vm.treatments);
        }

        /// <summary>
        /// Add new treatment
        /// </summary>
        /// <param name="id"> PatientId </param>
        /// <returns></returns>
        [Authorize(Roles = "doctor")]
        [HttpGet]
        public IActionResult Create(long id = 0)
        {
            // Get and convert treatment
            TreatmentDetailViewModel vm = new TreatmentDetailViewModel
            {
                Patients = PatientConverter.PatientlistToViewModel(patientRepository.GetAll()),
                TreatmentTypes = TypeConverter.ModelsToViewModel(treatmentTypeRepository.GetAll()),
                PatientId = id
            };
            return View(vm);
        }

        /// <summary>
        /// Add treatment
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [Authorize(Roles = "doctor")]
        [HttpPost]
        public IActionResult Create(TreatmentDetailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Convert back and create treatment
                Treatment treatment = TreatmentConverter.ViewModelToModel(vm);
                treatment.DoctorId = GetUserId();
                Comment comment = vm.Description;
                comment.TreatmentId = treatmentRepository.Insert(treatment);
                commentRepository.Insert(comment);
                return RedirectToAction("index", "treatment");
            }
            else
            {
                vm.Patients = PatientConverter.PatientlistToViewModel(patientRepository.GetAll());
                vm.TreatmentTypes = TypeConverter.ModelsToViewModel(treatmentTypeRepository.GetAll());
                return View(vm);
            }
        }

        /// <summary>
        /// Get for update
        /// </summary>
        /// <param name="id"> TreatmentId </param>
        /// <returns></returns>
        [Authorize(Roles = "doctor")]
        [HttpGet]
        public IActionResult Edit(long id)
        {
            //Retrieve treatment
            TreatmentDetailViewModel vm = TreatmentConverter.ModelToViewModel(treatmentRepository.GetById(id));
            vm.PatientName = patientRepository.GetById(vm.PatientId).Name;
            vm.TreatmentTypes = TypeConverter.ModelsToViewModel(treatmentTypeRepository.GetAll());

            // Return with model
            return View(vm);
        }

        /// <summary>
        /// Post update treatment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vm"></param>
        /// <returns></returns>
        [Authorize(Roles = "doctor")]
        [HttpPost]
        public IActionResult Edit(long id, TreatmentDetailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Treatment treatment = TreatmentConverter.ViewModelToModel(vm);
                treatmentRepository.Update(treatment);
                return RedirectToAction("index", "treatment");
            }
            else
            {
                vm.PatientName = patientRepository.GetById(patientRepository.GetPatientIdByTreatmentId(id)).Name;
                vm.TreatmentTypes = TypeConverter.ModelsToViewModel(treatmentTypeRepository.GetAll());
                return View(vm);
            }
        }
    }
}