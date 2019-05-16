using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapp.Converters;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    /// <summary>
    /// Doctor controller
    /// </summary>
    [Authorize(Roles = "doctor, admin")]
    public class DoctorController : BaseController
    {
        // Repos
        private readonly DoctorRepository doctorRepository;
        private readonly AccountRepository accountRepository;
        private readonly DepartmentRepository departmentRepository;
        // Converter
        private readonly IViewModelConverter<Doctor, DoctorDetailViewModel> converter;

        public DoctorController(DoctorRepository doctorRepository,
            AccountRepository accountRepository,
            DepartmentRepository departmentRepository,
            IViewModelConverter<Doctor, DoctorDetailViewModel> converter)
        {
            this.doctorRepository = doctorRepository;
            this.accountRepository = accountRepository;
            this.departmentRepository = departmentRepository;
            this.converter = converter;
        }

        /// <summary>
        /// Page list of doctors
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            DoctorViewModel vm = new DoctorViewModel();

            // Retrieve doctors
            List<Doctor> doctors = doctorRepository.GetAll();
            if (doctors.Count < 1)
                return View();
            
            // Convert to viewmodels
            vm.Doctors = converter.ModelsToViewModel(doctors);
            
            // Return view
            return View(vm);
        }

        /// <summary>
        /// Detail page for doctor
        /// </summary>
        /// <param name="id">Id filter</param>
        /// <returns></returns>
        public IActionResult Details(long id)
        {
            // Check if id is set
            if (id < 1)
                return BadRequest("Id cannot be 0");

            // Retrieve doctor
            Doctor doctor = doctorRepository.GetById(id);
            if (doctor == null)
                return BadRequest("Department could not be found");

            // Convert to viewmodel and return in view
            DoctorDetailViewModel vm = converter.ModelToViewModel(doctor);
            return View(vm);
        }

        /// <summary>
        /// Get for create
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            DoctorDetailViewModel vm = new DoctorDetailViewModel();
            return View(vm);
        }

        /// <summary>
        /// Post for create doctor
        /// </summary>
        /// <param name="model">Model to insert</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles ="admin")]
        public IActionResult Create(DoctorDetailViewModel model)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {
                Doctor doctor = converter.ViewModelToModel(model);
                // Create the doctor
                long id = doctorRepository.Insert(doctor);
                return RedirectToAction("Details", new { id });
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(long id)
        {
            if (id < 1)
                return BadRequest("Id cannot be 0");

            Doctor doctor = doctorRepository.GetById(id);
            if (doctor == null)
                return BadRequest("Department could not be found");

            DoctorDetailViewModel vm = converter.ModelToViewModel(doctor);
            //vm.Institutions = GetInstitutionsForDropdown(vm.Id).ToList();
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(long id, DoctorDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.EmployeeNumber)
                    return BadRequest("Ids do not match");

                Doctor doctor = converter.ViewModelToModel(model);

                if (doctorRepository.Update(doctor))
                    return RedirectToAction("Details", new { doctor.Id });
                else
                    return View(model);
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(long id)
        {

            if (ModelState.IsValid)
            {
                if (!departmentRepository.Delete(id))
                    return BadRequest("Something went wrong deleting object");
            }
            return RedirectToAction("Index");
        }
    }
}