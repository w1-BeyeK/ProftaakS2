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
    public class TreatmentController : BaseController
    {
        private readonly IContext context;
        private readonly TreatmentRepository repo;
        private readonly TreatmentViewModelConverter TreatmentVMC = new TreatmentViewModelConverter();

        public TreatmentController()
        {
            context = TestContext.GetInstance();
            //repo = new TreatmentRepository(context);
            repo = new TreatmentRepository(context);
        }

        //[Authorize(Roles = "Doctor, Patient")]
        public IActionResult Index()
        {
            List<Treatment> items = new List<Treatment>();
            if (User.IsInRole("Doctor"))
            {
                items = repo.ShowTreatmentsByDoctorId(GetUserId());
            }
            else if (User.IsInRole("Patient"))
            {
                items = repo.ShowTreatmentsByPatientId(GetUserId());
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
        public IActionResult AddTreatment()
        {
            return View();
        }

        //TODO : Voeg extra parameters toe!
        [HttpPost]
        public IActionResult AddTreatment(long patientid, string patientname, string treatmentname, 
        string treatmenttype, DateTime begindate, DateTime begintime, DateTime enddate, DateTime endtime, string comment)
        {
            //Sla het op
            return View();
        }

        [HttpGet]
        public IActionResult EditTreatment(long id)
        {
            Treatment treatment = new Treatment(6, "shoarmarollen", DateTime.Now, new DateTime(2020, 1, 18));
            Patient patient = new Patient()
            {
                Id = 0,
                Name = "Grietje"
            };
            treatment.Patient = patient;
            return View(TreatmentVMC.TreatmentToViewModel(treatment));
        }

        [HttpPost]
        public IActionResult AddTreatment(string patientname, string treatmentname,
        string treatmenttype, DateTime begindate, DateTime begintime, DateTime enddate, DateTime endtime, string comment)
        {
            return View();
        }
    }
}