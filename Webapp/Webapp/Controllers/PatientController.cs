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
    /// Controller for patient
    /// </summary>
    public class PatientController : BaseController
    {
        // Repos
        private readonly PatientRepository patientRepository;
        private readonly TreatmentRepository treatmentRepository;
        private readonly TreatmentTypeRepository treatmentTypeRepository;
        private readonly CommentRepository commentRepository;

        // Converters
        private readonly PatientWithTreatmentsViewModelConverter patientWithTreatmentsVMC = new PatientWithTreatmentsViewModelConverter();
        private readonly TreatmentViewModelConverter treatmentVMC = new TreatmentViewModelConverter();
        private readonly PatientViewModelConverter patientVMC = new PatientViewModelConverter();

        /// <summary>
        /// Default constructor for patient controller
        /// </summary>
        /// <param name="patientRepository"></param>
        /// <param name="treatmentRepository"></param>
        public PatientController(   
            PatientRepository patientRepository, 
            TreatmentRepository treatmentRepository,
            TreatmentTypeRepository treatmentTypeRepository,
            CommentRepository commentRepository
            )
        {
            this.patientRepository = patientRepository;
            this.treatmentRepository = treatmentRepository;
            this.treatmentTypeRepository = treatmentTypeRepository;
            this.commentRepository = commentRepository;
        }

        /// <summary>
        /// Gets all patients of a doctor and converts them from a class to a viewmodel
        /// </summary>
        [Authorize(Roles= "doctor")]
        public IActionResult Index()
        {
            // Retrieve and convert all - active - patients
            List<Patient> patienten = patientRepository.GetAll();
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
            Patient patient = new Patient();
            try
            {
                    long patientId = patientRepository.GetPatientIdByTreatmentId(id);
                    patient = patientRepository.GetById(patientId);
                    patient.Treatments = treatmentRepository.GetByPatient(patientId);
                    
                    foreach (Treatment t in patient.Treatments)
                    {
                        t.TreatmentType = treatmentTypeRepository.GetByTreatmentId(t.TreatmentTypeId);
                        t.Comments = commentRepository.GetByTreatment(id);
                    }
                patientDetailViewModel = patientWithTreatmentsVMC.PatientToViewModel(patient);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
            return View(patientDetailViewModel);
        }

        [Authorize(Roles = "doctor")]
        [HttpPost]
        public IActionResult Treatment(long id, PatientDetailViewModel vm)
        {
            Comment comment = vm.TreatmentDetailViewModels[0].Description;
            comment.TreatmentId = id;
            commentRepository.Insert(comment);
            return RedirectToAction("index", "patient");
        }
    }
}