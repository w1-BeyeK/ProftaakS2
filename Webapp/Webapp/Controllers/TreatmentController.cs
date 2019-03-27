using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapp.Conv;
using Webapp.Models.Data;

namespace Webapp.Controllers
{
    public class TreatmentController : Controller
    {
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

        public IActionResult AddTreatment()
        {
            return View();
        }

        public IActionResult EditTreatment(int Id)
        {
            Treatment treatment = new Treatment(6, "shoarmarollen", DateTime.Now, new DateTime(2020, 1, 18));
            Patient patient = new Patient()
            {
                Id = 0,
                Name = "Grietje"
            };
            treatment.Patient = patient;
            TreatmentConverter converter = new TreatmentConverter();
            return View(converter.ViewModelFromTreatment(treatment));
        }
    }
}