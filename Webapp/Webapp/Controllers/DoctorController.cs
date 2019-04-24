using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapp.Converters;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    [Authorize(Roles = "doctor")]
    public class DoctorController : BaseController
    {
        private readonly DoctorRepository doctorRepository;
        private readonly DepartmentRepository departmentRepository;
        DoctorViewModelConverter doctorViewModelConverter = new DoctorViewModelConverter();

        public DoctorController(DoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        /// <summary>
        /// Gets all doctors converts them from a class to a viewmodel
        /// </summary>
        public IActionResult Index()
        {
            List<Doctor> doctors = doctorRepository.GetAll();
            List<DoctorDetailViewModel> vms = doctorViewModelConverter.ModelsToViewModel(doctors);
            return View(vms);
        }
    }
}