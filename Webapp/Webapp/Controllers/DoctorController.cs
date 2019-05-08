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
    [Authorize(Roles = "doctor, admin")]
    public class DoctorController : BaseController
    {
        private readonly DoctorRepository doctorRepository;
        private readonly AccountRepository accountRepository;
        private readonly DepartmentRepository departmentRepository;
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

        public IActionResult Index()
        {
            DoctorViewModel vm = new DoctorViewModel();

            List<Doctor> doctors = doctorRepository.GetAll();
            if (doctors.Count < 1)
                return View();

            List<UserAccount> accounts = accountRepository.GetAll();
            vm.Doctors = new List<DoctorDetailViewModel>();
            foreach(Doctor doctor in doctors)
            {
                UserAccount account = accounts.FirstOrDefault(a => a.DoctorId == doctor.Id);
                if (account == null)
                {
                    continue;
                }

                doctor.Name = account.Name;
                vm.Doctors.Add(converter.ModelToViewModel(doctor));
            }
            
            return View(vm);
        }

        public IActionResult Details(long id)
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

        public IActionResult Create()
        {
            DoctorDetailViewModel vm = new DoctorDetailViewModel();
            //vm.Institutions = GetInstitutionsForDropdown().ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(DoctorDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor = converter.ViewModelToModel(model);
                long id = doctorRepository.Insert(doctor);
                return RedirectToAction("Details", new { id });
            }
            return View();
        }

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
        public IActionResult Edit(long id, DoctorDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.Id)
                    return BadRequest("Ids do not match");

                Doctor doctor = converter.ViewModelToModel(model);

                if (doctorRepository.Update(doctor))
                    return RedirectToAction("Details", new { doctor.Id });
                else
                    return View(model);
            }
            return View();
        }

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