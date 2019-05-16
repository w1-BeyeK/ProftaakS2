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
    /// <summary>
    /// Controller to maintain departments
    /// </summary>
    [Authorize(Roles = "admin, doctor")]
    public class DepartmentController : Controller
    {
        // Repos
        private readonly DepartmentRepository departmentRepository;
        private readonly InstitutionRepository institutionRepository;
        // Converter
        private readonly IViewModelConverter<Department, DepartmentDetailViewModel> converter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentRepository">Department repository</param>
        /// <param name="institutionRepository">Institution repository</param>
        /// <param name="converter">Converter</param>
        public DepartmentController(DepartmentRepository departmentRepository,
            InstitutionRepository institutionRepository,
            IViewModelConverter<Department, DepartmentDetailViewModel> converter)
        {
            this.departmentRepository = departmentRepository;
            this.institutionRepository = institutionRepository;
            this.converter = converter;
        }

        /// <summary>
        /// Get all institutions for select
        /// </summary>
        /// <param name="selectId">Set the default selected value of the dropdown</param>
        /// <returns></returns>
        protected IEnumerable<SelectListItem> GetInstitutionsForDropdown(long selectId = -1)
        {
            List<SelectListItem> items = new List<SelectListItem>
            {
                // Set default first item
                new SelectListItem
                {
                    Text="Select institution...", Value = "-1" , Disabled = true, Selected = true
                }
            };

            //Retrieve all insitutions
            List<Institution> institutions = institutionRepository.GetAll();

            // Create item for each institution
            institutions.ForEach(i =>
                {
                    items.Add(new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString(),
                        // Selected if Ids match
                        Selected = (i.Id == selectId)
                    });
                });
            
            return items;
        }

        /// <summary>
        /// Index method which returns a view of all departments
        /// </summary>
        /// <returns>Page list of departments</returns>
        public IActionResult Index()
        {
            DepartmentViewModel vm = new DepartmentViewModel();

            // Retrieve all departments
            List<Department> departments = departmentRepository.GetAll();

            // If none exist return empty view
            if (departments.Count < 1)
                return View();

            // Assign departments
            vm.Departments = converter.ModelsToViewModel(departments);

            return View(vm);
        }

        /// <summary>
        /// Get department by id
        /// </summary>
        /// <param name="id">Id filter</param>
        /// <returns>Detail page of department</returns>
        public IActionResult Details(long id)
        {
            // Check if id is set
            if (id < 1)
                return BadRequest("Id cannot be 0");

            // Retrieve department
            Department department = departmentRepository.GetById(id);
            if (department == null)
                return BadRequest("Department could not be found");

            // Assign and return view
            DepartmentDetailViewModel vm = converter.ModelToViewModel(department);
            vm.Institutions = GetInstitutionsForDropdown(vm.Id).ToList();
            return View(vm);
        }

        /// <summary>
        /// Get request to create department
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            // Setup VM
            DepartmentDetailViewModel vm = new DepartmentDetailViewModel
            {
                Institutions = GetInstitutionsForDropdown().ToList()
            };
            return View(vm);
        }

        /// <summary>
        /// Post for create department
        /// </summary>
        /// <param name="model">Model to insert</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create(DepartmentDetailViewModel model)
        {
            // Check if is valid
            if (ModelState.IsValid)
            {
                // Push to database
                Department department = converter.ViewModelToModel(model);
                long id = departmentRepository.Insert(department);

                // Return detail view
                return RedirectToAction("Details", new { id });
            }
            return View();
        }

        /// <summary>
        /// Get request to update department
        /// </summary>
        /// <param name="id">Id filter</param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Edit(long id)
        {
            // Check if id is set
            if (id < 1)
                return BadRequest("Id cannot be 0");

            // Retrieve department
            Department department = departmentRepository.GetById(id);
            if (department == null)
                return BadRequest("Department could not be found");

            // Convert and return
            DepartmentDetailViewModel vm = converter.ModelToViewModel(department);
            vm.Institutions = GetInstitutionsForDropdown(vm.Id).ToList();
            return View(vm);
        }

        /// <summary>
        /// Post method to update department
        /// </summary>
        /// <param name="id">Id parameter from url</param>
        /// <param name="model">Model to update</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(long id, DepartmentDetailViewModel model)
        {
            // Check if model is valid
            if(ModelState.IsValid)
            {
                // Validation on Ids
                if (id != model.Id)
                    return BadRequest("Ids do not match");

                // Convert vm back to model
                Department department = converter.ViewModelToModel(model);

                // Update department, if success redirect to details
                if (departmentRepository.Update(department))
                    return RedirectToAction("Details", new { department.Id });
                else
                    return View(model);
            }
            return View();
        }
        
        /// <summary>
        /// Delete for department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Delete(long id)
        {
            // Check if model is valid
            if(ModelState.IsValid)
            {
                // Delete the department
                if (!departmentRepository.Delete(id))
                    return BadRequest("Something went wrong deleting object");
            }
            return RedirectToAction("Index");
        }
    }
}