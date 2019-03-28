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
            repo = new TreatmentRepository(context);
        }

        [Authorize(Roles = "doctor, patient")]
        public IActionResult Index()
        {
            List<Treatment> items = new List<Treatment>();
            if (User.IsInRole("doctor"))
            {
                items = repo.ShowTreatmentsByDoctorId(GetUserId());
            }
            else if (User.IsInRole("patient"))
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
        public IActionResult Add()
        {
            return View();
        }

        //TODO : Voeg extra parameters toe!
        [HttpPost]
        public IActionResult Add(long patientid, string treatmentname, DateTime begindate, TimeSpan begintime, DateTime enddate, TimeSpan endtime, string comment)
        {
            PatientDetailViewModel patientDetail = new PatientDetailViewModel()
            {
                Id = patientid,
            };

            //Type = treatmenttype,
            TreatmentDetailViewModel treatmentDetail = new TreatmentDetailViewModel()
            {
                Name = treatmentname,
                BeginDate = begindate + begintime,
                EndDate = begindate + begintime,
                Comment = comment,
                PatientDetailViewModel = patientDetail,
            };
            Treatment treatment = TreatmentVMC.ViewModelToTreatment(treatmentDetail);
            bool gelukt = repo.AddTreatment(treatment, doctorId, patientId);

            ViewBag.Bericht = gelukt.ToString();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(long id)
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
        public IActionResult Edit(string patientname, string treatmentname,
        string treatmenttype, DateTime begindate, DateTime begintime, DateTime enddate, DateTime endtime, string comment)
        {
            return View();
        }
    }
}