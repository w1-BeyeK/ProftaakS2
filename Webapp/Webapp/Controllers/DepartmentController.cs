﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapp.Models.Data;

namespace Webapp.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            List<Department> items = new List<Department>();

            string[] departName = { "VoetZoekAfdeling", "BeenHakAfdeling", "ArmAandraaiAfdeling", "FipronilTrekAfdeling", "OorsmeerpeuterAfdeling" };

            Random rnd = new Random();

            for (int i = 0; i < 23; i++)
            {
                Department treatment = new Department(departName[rnd.Next(5)], "Ojaa", true);
                items.Add(treatment);
            }
            return View(items);
        }
    }
}