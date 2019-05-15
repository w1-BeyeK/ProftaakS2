using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    [Authorize(Roles = "admin")]
    public class DepartmentController : Controller
    {
        //global instances
        private readonly DepartmentRepository departmentRepository;
        private readonly InstitutionRepository institutionRepository;
        private readonly IViewModelConverter<Department, DepartmentDetailViewModel> converter;

        public DepartmentController(DepartmentRepository departmentRepository,
            InstitutionRepository institutionRepository,
            IViewModelConverter<Department, DepartmentDetailViewModel> converter)
        {
            this.departmentRepository = departmentRepository;
            this.institutionRepository = institutionRepository;
            this.converter = converter;
        }

        protected IEnumerable<SelectListItem> GetInstitutionsForDropdown(long selectId = -1)
        {
            List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="Select institution...", Value = "-1" , Disabled = true, Selected = true
                }
            };
            List<Institution> institutions = institutionRepository.GetAll();
            institutions.ForEach(i =>
                {
                    items.Add(new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString(),
                        Selected = (i.Id == selectId)
                    });
                });
            
            return items;
        }

        public IActionResult Index()
        {
            DepartmentViewModel vm = new DepartmentViewModel();

            List<Department> departments = departmentRepository.GetAll();
            if (departments.Count < 1)
                return View();

            vm.Departments = converter.ModelsToViewModel(departments);

            return View(vm);
        }

        public IActionResult Details(long id)
        {
            if (id < 1)
                return BadRequest("Id cannot be 0");

            Department department = departmentRepository.GetById(id);
            if (department == null)
                return BadRequest("Department could not be found");

            DepartmentDetailViewModel vm = converter.ModelToViewModel(department);
            vm.Institutions = GetInstitutionsForDropdown(vm.Id).ToList();
            return View(vm);
        }

        public IActionResult Create()
        {
            DepartmentDetailViewModel vm = new DepartmentDetailViewModel
            {
                Institutions = GetInstitutionsForDropdown().ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(DepartmentDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department department = converter.ViewModelToModel(model);
                long id = departmentRepository.Insert(department);
                return RedirectToAction("Details", new { id });
            }
            return View();
        }

        public IActionResult Edit(long id)
        {
            if (id < 1)
                return BadRequest("Id cannot be 0");

            Department department = departmentRepository.GetById(id);
            if (department == null)
                return BadRequest("Department could not be found");

            DepartmentDetailViewModel vm = converter.ModelToViewModel(department);
            vm.Institutions = GetInstitutionsForDropdown(vm.Id).ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, DepartmentDetailViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (id != model.Id)
                    return BadRequest("Ids do not match");

                Department department = converter.ViewModelToModel(model);

                if (departmentRepository.Update(department))
                    return RedirectToAction("Details", new { department.Id });
                else
                    return View(model);
            }
            return View();
        }
        
        public IActionResult Delete(long id)
        {

            if(ModelState.IsValid)
            {
                if (!departmentRepository.Delete(id))
                    return BadRequest("Something went wrong deleting object");
            }
            return RedirectToAction("Index");
        }
    }
}