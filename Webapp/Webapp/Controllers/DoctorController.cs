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
        private readonly DoctorViewModelConverter converter = new DoctorViewModelConverter();

        public DoctorController
            (
                DoctorRepository doctorRepository,
                AccountRepository accountRepository,
                DepartmentRepository departmentRepository
            )
        {
            this.doctorRepository = doctorRepository;
            this.accountRepository = accountRepository;
            this.departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Page list of doctors
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            DoctorViewModel vm = new DoctorViewModel();
            List<Doctor> doctors = new List<Doctor>();
            if (User.IsInRole("admin"))
            {
                // Retrieve doctors
                doctors = doctorRepository.GetAll();
                if (doctors.Count < 1)
                    return View();
            }
            else if(User.IsInRole("doctor"))
            {
                long userId = GetUserId();
                doctors = doctorRepository.GetByDepartment(userId);
                if (doctors.Count < 1)
                    return View();
            }
            
            // Convert to viewmodels
            vm.Doctors = converter.ModelsToViewModel(doctors);
            //foreach(Doctor doctor in doctors)
            //{
            //    UserAccount account = accounts.FirstOrDefault(a => a.DoctorId == doctor.Id);
            //    if (account == null)
            //    {
            //        continue;
            //    }

            //    doctor.Name = account.Name;
            //    vm.Doctors.Add(converter.ModelToViewModel(doctor));
            //}
            
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
            vm.Genders = converter.GetGenders();
            //vm.Institutions = GetInstitutionsForDropdown().ToList();
            return View(vm);
        }

        /// <summary>
        /// Post for create doctor
        /// </summary>
        /// <param name="model">Model to insert</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create(DoctorDetailViewModel vm)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {
                Doctor doctor = converter.ViewModelToModel(vm);
                long id = doctorRepository.Insert(doctor);
                return RedirectToAction("Details", new { id });
            }
            else
            {
                vm.Genders = converter.GetGenders();
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(long id)
        {
            if (id < 1)
                return BadRequest("Id cannot be 0");

            Doctor doctor = doctorRepository.GetById(id);
            if (doctor == null)
                return BadRequest("Department could not be found");

            DoctorDetailViewModel vm = converter.ModelToViewModel(doctor);
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(long id, DoctorDetailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (id != vm.EmployeeNumber)
                {
                    return BadRequest("Ids do not match");
                }

                Doctor doctor = converter.ViewModelToModel(vm);

                if (doctorRepository.Update(doctor))
                {
                    return RedirectToAction("Details", new { doctor.Id });
                }
                else
                {
                    vm.Genders = converter.GetGenders();
                    return View(vm);
                }
            }
            else
            {
                vm.Genders = converter.GetGenders();
                return View(vm);
            }
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