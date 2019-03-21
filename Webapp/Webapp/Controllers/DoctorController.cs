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
                new Doctor()
                {
                    Name = "Harm Hardloper",
                    Function = "Cardioloog"

                },
                new Doctor()
                {
                    Name = "Gerda Grottenfuhler",
                    Function = "Gynaecoloog"
                },
                new Doctor()
                {
                    Name = "Klaas Koppijn",
                    Function = "Hersenchirurg"
                },
                new Doctor()
                {
                    Name = "Sonya Slaapmaardoor",
                    Function = "Anesthesist"
                },
                new Doctor()
                {
                    Name = "Floor Flamoes",
                    Function = "Gynaecoloog"
                },
                new Doctor()
                {
                    Name = "Karel van Kamelenrug",
                    Function = "Mammografist"
                },
                new Doctor()
                {
                    Name = "Aaron van Astma",
                    Function = "Longexpert"
                },
                new Doctor()
                {
                    Name = "Peter Plasman",
                    Function = "Uroloog"
                },
                new Doctor()
                {
                    Name = "Simon Spraakgebrek",
                    Function = "Logopedist"
                },
                new Doctor()
                {
                    Name = "Olga Ongelukya-inyabroek'ya",
                    Function = "Uroloog"
                },
                new Doctor()
                {
                    Name = "Karel Kinderlach",
                    Function = "Cliniclown"
                },
            };
            return View(items);
        }
    }
}