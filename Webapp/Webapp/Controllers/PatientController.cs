﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapp.Context;
using Webapp.Converters;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    [Route("patient")]
    public class PatientController : BaseController
    {
        private readonly PatientRepository patientRepository;
        private readonly TreatmentRepository treatmentRepository;

        private readonly TreatmentViewModelConverter treatmentViewModelConverter;

        public PatientController(PatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
            //this.treatmentRepository = treatmentRepository;

            IContext context = TestContext.GetInstance();
            treatmentRepository = new TreatmentRepository(context);
            treatmentViewModelConverter = new TreatmentViewModelConverter();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Detail(long id)
        {
            TreatmentViewModel treatmentViewModel = new TreatmentViewModel();

            try
            {
                Patient patient = patientRepository.GetById(id);
                List<Treatment> treatments = treatmentRepository.GetTreatmentsByDoctor(id).OrderByDescending(p => p.BeginDate).ToList();
                
                treatmentViewModel.treatments = treatmentViewModelConverter.TreatmentsToViewModel(treatments);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
            return View();
        }
    }
}