using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapp.Models.Data;

namespace Webapp.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            List<Doctor> items = new List<Doctor>()
            {
               
            };
            return View(items);
        }
    }
}