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
    //[Route("patient")]
    public class PatientController : BaseController
    {
        // global instances
        private readonly PatientRepository patientRepository;
        private readonly TreatmentRepository treatmentRepository;

        private readonly PatientWithTreatmentsViewModelConverter patientWithTreatmentsVMC = new PatientWithTreatmentsViewModelConverter();
        private readonly TreatmentViewModelConverter treatmentVMC = new TreatmentViewModelConverter();
        private readonly PatientViewModelConverter patientVMC = new PatientViewModelConverter();

        public PatientController(
            PatientRepository patientRepository, 
            TreatmentRepository treatmentRepository
            )
        {
            this.patientRepository = patientRepository;
            this.treatmentRepository = treatmentRepository;
        }

        /// <summary>
        /// Gets all patients of a doctor and converts them from a class to a viewmodel
        /// </summary>
        [Authorize(Roles= "doctor")]
        public IActionResult Index()
        {
            //if (User.IsInRole("patient"))
            //{
            //    return RedirectToAction("Index", "Profile");
            //}

            List<Patient> patienten = patientRepository.GetByDoctor(GetUserId());
            List<PatientListViewModel> vms = patientVMC.PatientlistToViewModel(patienten);

            return View(vms);
        }

        /// <summary>
        /// Gets a treatment with a small amount of data of the patient with the given id and converts that to a viewmodel
        /// </summary>
        //[HttpGet("{id}")]
        [Authorize(Roles = "doctor, patient")]
        public IActionResult Treatment(long id)
        {
            PatientDetailViewModel patientDetailViewModel = new PatientDetailViewModel();
            try
            {
                patientDetailViewModel = patientWithTreatmentsVMC.PatientToViewModel(patientRepository.GetById(id));
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
            return View(patientDetailViewModel);
        }
    }
}