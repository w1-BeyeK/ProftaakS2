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
            HttpContext.Session.SetString("loginType", "admin");
            List<Department> items = new List<Department>()
            {
                /*
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                },
                new Department()
                {
                    Name = "Hartafdeling",
                    Description = "Afdeling voor hartproblemen"
                },
                new Department()
                {
                    Name = "Röngtenafdeling",
                    Description = "Hier worden röngtenfoto's gemaakt"
                }
                */
            };
            return View(items);
        }
    }
}