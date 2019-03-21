using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapp.Models.Data;

namespace Webapp.Controllers
{
    public class TreatmentController : Controller
    {
        public IActionResult Index()
        {
            List<Treatment> items = new List<Treatment>()
            {
                new Treatment()
                {
                    Name = "VoetZoeken",
                    BeginDate = DateTime.Now,
                    EndDate = new DateTime(2020, 1, 18)
                },
                new Treatment()
                {
                    Name = "BeenHakken",
                    BeginDate = DateTime.Now,
                    EndDate = new DateTime(2020, 1, 18)
                },
                new Treatment()
                {
                    Name = "ArmAandraaien",
                    BeginDate = DateTime.Now,
                    EndDate = new DateTime(2020, 1, 18)
                }
            };
            return View(items);
        }

        public IActionResult AddTreatment()
        {
            return View();
        }

        public IActionResult EditTreatment()
        {
            return View();
        }
    }
}