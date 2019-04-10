using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorRepository doctorRepository;

        public DoctorController(DoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public IActionResult Index()
        {
            List<Doctor> items = doctorRepository.GetDoctors();
            return View(items);
        }
    }
}