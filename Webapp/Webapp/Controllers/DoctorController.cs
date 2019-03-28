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
            List<Doctor> items = new List<Doctor>();

            string[] functie = { "Cardioloog", "Gynaecoloog", "Hersenchirurg", "Anesthesist", "Chocoladefabriek" };

            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                Doctor doctor = new Doctor(i, "", "", "Sjaak " + i.ToString())
                {
                    Function = functie[rnd.Next(5)]
                };
                items.Add(doctor);
            }
            return View(items);
        }
    }
}