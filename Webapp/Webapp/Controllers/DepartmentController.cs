using System;
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
            List<Department> items = new List<Department>()
            {
                new Department("Hartafdeling", true, "Afdeling voor hartproblemen"),
                new Department("Röngtenafdeling", true, "Hier worden röngtenfoto's gemaakt"),
                new Department("Hartafdeling", true, "Afdeling voor hartproblemen"),
                new Department("Röngtenafdeling", true, "Hier worden röngtenfoto's gemaakt"),
                new Department("Hartafdeling", true, "Afdeling voor hartproblemen"),
                new Department("Röngtenafdeling", true, "Hier worden röngtenfoto's gemaakt"),
                new Department("Hartafdeling", true, "Afdeling voor hartproblemen"),
                new Department("Röngtenafdeling", true, "Hier worden röngtenfoto's gemaakt"),
                new Department("Hartafdeling", true, "Afdeling voor hartproblemen"),
                new Department("Röngtenafdeling", true, "Hier worden röngtenfoto's gemaakt"),
                new Department("Hartafdeling", true, "Afdeling voor hartproblemen"),
                new Department("Röngtenafdeling", true, "Hier worden röngtenfoto's gemaakt"),
                new Department("Hartafdeling", true, "Afdeling voor hartproblemen"),
                new Department("Röngtenafdeling", true, "Hier worden röngtenfoto's gemaakt"),
                new Department("Hartafdeling", true, "Afdeling voor hartproblemen"),
                new Department("Röngtenafdeling", true, "Hier worden röngtenfoto's gemaakt")
            };
            return View(items);
        }
    }
}