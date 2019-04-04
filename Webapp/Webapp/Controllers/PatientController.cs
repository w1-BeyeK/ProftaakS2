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
        private readonly PatientRepository patientRepository;
        private readonly TreatmentRepository treatmentRepository;
        private readonly IContext context;
        private readonly TreatmentViewModelConverter treatmentViewModelConverter = new TreatmentViewModelConverter();
        private readonly PatientListViewModel pLVM = new PatientListViewModel();
        private readonly PatientViewModelConverter pVMC = new PatientViewModelConverter();

        public PatientController()
        {
            //this.treatmentRepository = treatmentRepository;
            context = TestContext.GetInstance();
            patientRepository = new PatientRepository(context);
            treatmentRepository = new TreatmentRepository(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Patientlist()
        {
            if (User.IsInRole("patient"))
            {
                return RedirectToAction("Index", "Profile");
            }

            List<Patient> patienten = patientRepository.GetPatients();
            List<PatientListViewModel> convert = new List<PatientListViewModel>();

            foreach (Patient p in patienten)
            {
                convert.Add(pVMC.PatientlistToViewModel(p));
            }

            return View(convert);
        }

        //[HttpGet("{id}")]
        public IActionResult Treatment(long id)
        {
            PatientDetailViewModel patientDetailViewModel = new PatientDetailViewModel();
            TreatmentDetailViewModelConverter treatmentDetailViewModelConverter = new TreatmentDetailViewModelConverter();
            try
            {
                Patient patient = patientRepository.GetPatientById(id);
                patientDetailViewModel = treatmentDetailViewModelConverter.PatientToViewModel(patient);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
            return View(patientDetailViewModel);
        }
    }
}