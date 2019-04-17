﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapp.Converters;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorRepository doctorRepository;
        DoctorViewModelConverter doctorViewModelConverter = new DoctorViewModelConverter();

        public DoctorController(DoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        //
        public IActionResult Index()
        {
            List<Doctor> doctors = doctorRepository.GetAll();
            List<DoctorListViewModel> vms = doctorViewModelConverter.DoctorlistToViewModel(doctors);
            return View(vms);
        }
    }
}