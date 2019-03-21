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
            List<Department> items = new List<Department>();
            for (int i = 0; i < 50; i++)
            {
                Department depart = new Department("Röngtenafdeling " + i.ToString(), "Hier worden röngtenfoto's gemaakt", true);
                items.Add(depart);
            }

            return View(items);
        }
    }
}