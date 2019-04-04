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
    public class TreatmentController : BaseController
    {
        private readonly IContext context;
        private readonly TreatmentRepository repo;
        private readonly TreatmentViewModelConverter TreatmentVMC = new TreatmentViewModelConverter();
        private readonly TreatmentDetailViewModelConverter TreatmentDetailVMC = new TreatmentDetailViewModelConverter();

        public TreatmentController()
        {
            context = TestContext.GetInstance();
            repo = new TreatmentRepository(context);
        }

        [Authorize(Roles = "doctor, patient")]
        public IActionResult Index()
        {
            List<Treatment> items = new List<Treatment>();
            if (User.IsInRole("doctor"))
            {
                items = repo.GetAllTreatmentsByDoctorId(GetUserId());
            }
            else if (User.IsInRole("patient"))
            {
                items = repo.GetAllTreatmentsByPatientId(GetUserId());
            }

            TreatmentViewModel vm = new TreatmentViewModel()
            {
                treatments = new List<TreatmentDetailViewModel>()
            };
            foreach (Treatment treatment in items)
            {
                vm.treatments.Add(TreatmentVMC.TreatmentToViewModel(treatment));
            }

            return View(vm.treatments);
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //TODO : Voeg extra parameters toe! bij AddTreatment
        [HttpPost]
        public IActionResult Add(TreatmentDetailViewModel vm)
        {
            Treatment treatment = TreatmentVMC.ViewModelToTreatment(vm);
            repo.AddTreatment(treatment, GetUserId(), treatment.Patient.Id);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            TreatmentDetailViewModel vm = TreatmentVMC.TreatmentToViewModel(repo.GetTreatmentById(id));

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, TreatmentDetailViewModel vm)
        {
            Treatment treatment = TreatmentVMC.ViewModelToTreatment(vm);
            repo.UpdateTreatment(id, treatment);
            return RedirectToAction("index", "treatment");
        }
    }
}