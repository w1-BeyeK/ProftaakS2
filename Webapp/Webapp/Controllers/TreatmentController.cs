﻿using System;
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
    [Authorize(Roles = "doctor, patient")]
    public class TreatmentController : BaseController
    {
        private readonly TreatmentRepository treatmentRepository;
        private readonly PatientRepository patientRepository;
        private readonly TreatmentTypeRepository treatmentTypeRepository;

        private readonly TreatmentViewModelConverter TreatmentConverter = new TreatmentViewModelConverter();
        private readonly PatientViewModelConverter PatientConverter = new PatientViewModelConverter();
        private readonly TreatmentTypeViewModelConverter TypeConverter = new TreatmentTypeViewModelConverter();

        public TreatmentController(
            TreatmentRepository treatmentRepository, 
            PatientRepository patientRepository, 
            TreatmentTypeRepository treatmentTypeRepository
            )
        {
            this.treatmentRepository = treatmentRepository;
            this.patientRepository = patientRepository;
            this.treatmentTypeRepository = treatmentTypeRepository;
        }

        public IActionResult Index()
        {
            List<Treatment> items = new List<Treatment>();
            if (User.IsInRole("doctor"))
            {
                items = treatmentRepository.GetByDoctor(GetUserId());
            }
            else if (User.IsInRole("patient"))
            {
                items = treatmentRepository.GetByPatient(GetUserId());
            }

            TreatmentViewModel vm = new TreatmentViewModel()
            {
                treatments = new List<TreatmentDetailViewModel>()
            };
            foreach (Treatment treatment in items)
            {
                vm.treatments.Add(TreatmentConverter.ModelToViewModel(treatment));
            }

            return View(vm.treatments);
        }

        [Authorize(Roles = "doctor")]
        [HttpGet]
        public IActionResult Add()
        {
            TreatmentDetailViewModel vm = new TreatmentDetailViewModel
            {
                Patients = PatientConverter.PatientlistToViewModel(patientRepository.GetAll()),
                TreatmentTypes = TypeConverter.ModelsToViewModel(treatmentTypeRepository.GetAll())
            };
            return View(vm);
        }
        
        //TODO : Voeg extra parameters toe! bij AddTreatment
        [Authorize(Roles = "doctor")]
        [HttpPost]
        public IActionResult Add(TreatmentDetailViewModel vm)
        {
            Treatment treatment = TreatmentConverter.ViewModelToModel(vm);
            treatmentRepository.Insert(treatment, treatment.TreatmentType.Id, GetUserId(), treatment.Patient.Id);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            TreatmentDetailViewModel vm = TreatmentConverter.ModelToViewModel(treatmentRepository.GetById(id));

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, TreatmentDetailViewModel vm)
        {
            Treatment treatment = TreatmentConverter.ViewModelToModel(vm);
            treatmentRepository.Update(treatment);
            return RedirectToAction("index", "treatment");
        }
    }
}