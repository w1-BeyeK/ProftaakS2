using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapp.Context;
using Webapp.Converters;
using Webapp.Interfaces;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly IContext context;
        private readonly TreatmentRepository repo;
        private readonly TreatmentViewModelConverter TreatmentVMC = new TreatmentViewModelConverter();

        public TreatmentController()
        {
            context = TestContext.GetInstance();
            //repo = new TreatmentRepository(context);
        }
        
        public IActionResult Index()
        {
            List<Treatment> items = new List<Treatment>();

            string[] treat = { "VoetZoeken", "BeenHakken", "ArmAandraaien", "FipronilTrekken", "Oorsmeerpeuteren" };

            Random rnd = new Random();

            for (int i = 0; i < 23; i++)
            {
                Treatment treatment = new Treatment(i, treat[rnd.Next(5)], DateTime.Now, new DateTime(2020, 1, 18));
                items.Add(treatment);
            }

            return View(items);
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
        public IActionResult EditTreatment(int id)
        {
            Treatment treatment = new Treatment(6, "shoarmarollen", DateTime.Now, new DateTime(2020, 1, 18));
            Patient patient = new Patient()
            {
                Id = 0,
                Name = "Grietje"
            };
            treatment.Patient = patient;
            TreatmentViewModelConverter converter = new TreatmentViewModelConverter();
            return View(converter.ViewModelFromTreatment(treatment));
        }

        [HttpPost]
        public IActionResult AddTreatment(string patientname, string treatmentname,
        string treatmenttype, DateTime begindate, DateTime begintime, DateTime enddate, DateTime endtime, string comment)
        {
            return View();
        }
    }
}