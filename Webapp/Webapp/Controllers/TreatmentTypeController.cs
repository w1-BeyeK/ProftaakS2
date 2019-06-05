using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webapp.Converters;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    [Authorize(Roles = "admin, doctor")]
    public class TreatmentTypeController : BaseController
    {
        //global instances
        private readonly TreatmentTypeRepository repository;
        private readonly DepartmentRepository departmentRepository;
        private readonly InstitutionRepository institutionRepository;
        private readonly IViewModelConverter<TreatmentType, TreatmentTypeDetailViewModel> converter;

        /// <summary>
        /// Constructor that sets the instances of the repositories and the converters
        /// </summary>
        /// <param name="treatmentRepository"></param>
        /// <param name="departmentRepository"></param>
        /// <param name="institutionRepository"></param>
        public TreatmentTypeController(TreatmentTypeRepository treatmentRepository, 
            DepartmentRepository departmentRepository,
            InstitutionRepository institutionRepository)
        {
            this.repository = treatmentRepository;
            this.departmentRepository = departmentRepository;
            this.institutionRepository = institutionRepository;
            converter = new TreatmentTypeViewModelConverter();
        }

        /// <summary>
        /// The home screen of treatmenttypes that gets all treatmenttypes and converts them to a list of viewmodels.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            TreatmentTypeViewModel vm = new TreatmentTypeViewModel()
            {
                TreatmentTypes = new List<TreatmentTypeDetailViewModel>()
            };
            List<TreatmentType> treatmentTypes = new List<TreatmentType>();
            if (User.IsInRole("admin"))
            {
                // Retrieve all treatmenttypes
                treatmentTypes = repository.GetAll();
            }
            else if (User.IsInRole("doctor"))
            {
                long id = GetUserId();
                treatmentTypes = repository.GetTreatmentTypesByDoctorId(GetUserId());
            }
            if (treatmentTypes.Count < 1)
                return View(vm);

            vm.TreatmentTypes = converter.ModelsToViewModel(treatmentTypes);
            return View(vm);
        }

        /// <summary>
        /// Gets of the specific treatmenttype the requested data and converts them to a viewmodel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        //TODO: Moet een dokter ook niet de treatment details kunnen inzien?
        public IActionResult Details(long id)
        {
            // Check if id is set
            if (id < 1)
                return BadRequest("No user found");
            
            // Retrieve from db
            TreatmentType model = repository.GetById(id);
            TreatmentTypeDetailViewModel vm = converter.ModelToViewModel(model);

            // Get all departments for select list
            List<Department> departments = departmentRepository.GetAll();
            IEnumerable<SelectListItem> items =
                from value in departments
                select new SelectListItem
                {
                    Text = value.Name,
                    Value = value.Id.ToString(),
                    Selected = (value.Id == vm.DepartmentId)
                };
            vm.Departments = items.ToList();

            return View(vm);
        }
        
        /// <summary>
        /// Method gets all objects form departments and institutions and coverts them to a viewmodel.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            // Retrieve for dropdown
            List<Department> departments = departmentRepository.GetAll();
            List<Institution> institutions = institutionRepository.GetAll();

            List<SelectListItem> items = new List<SelectListItem>();
            SelectListGroup group;
            
            // Create dropdownlist for treatmenttype
            foreach (Institution i in institutions)
            {
                group = new SelectListGroup
                {
                    Name = i.Name
                };

                foreach (Department dm in departments.Where(d => d.InstitutionId == i.Id))
                {
                    items.Add(new SelectListItem
                    {
                        Value = dm.Id.ToString(),
                        Text = dm.Name,
                        Group = group
                    });
                }
            }
            
            TreatmentTypeDetailViewModel vm = new TreatmentTypeDetailViewModel
            {
                Departments = items
            };

            return View(vm);
        }

        /// <summary>
        /// Method converts a detailviewmodel to an TreatmentType and passes it through.
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create(TreatmentTypeDetailViewModel vm)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {
                // Push to database
                TreatmentType tt = converter.ViewModelToModel(vm);
                long id = repository.Insert(tt);

                // Return details page of just inserted record
                return RedirectToAction("details", new { id });
            }
            else
            {
                return View(vm);
            }
            
        }

        /// <summary>
        /// Method gets all objects form departments and institutions and coverts them to a viewmodel.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Edit(long id)
        {
            // Check if model is valid
            if(ModelState.IsValid)
            {
                // Get
                TreatmentType tt = repository.GetById(id);

                if (tt == null)
                    return BadRequest("Gebruiker niet gevonden.");

                // Get dropdown for treatmenttype
                List<Department> departments = departmentRepository.GetAll();
                List<Institution> institutions = institutionRepository.GetAll();

                List<SelectListItem> items = new List<SelectListItem>();
                SelectListGroup group;
                foreach (Institution i in institutions)
                {
                    group = new SelectListGroup
                    {
                        Name = i.Name
                    };

                    foreach (Department dm in departments.Where(d => d.InstitutionId == i.Id))
                    {
                        items.Add(new SelectListItem
                        {
                            Value = dm.Id.ToString(),
                            Text = dm.Name,
                            Group = group
                        });
                    }
                }

                // Convert to vm
                TreatmentTypeDetailViewModel vm = converter.ModelToViewModel(tt);
                vm.Departments = items;

                return View(vm);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method converts a detailviewmodel to an TreatmentType and passes it through to update the treatment.
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(TreatmentTypeDetailViewModel vm)
        {
            // Check if model is valid
            if(ModelState.IsValid)
            {
                // Update in database
                TreatmentType tt = converter.ViewModelToModel(vm);
                repository.Update(tt);

                if (tt.Active)
                    return RedirectToAction("details", new { id = tt.Id });
                else
                    return RedirectToAction("index");
            }
            return View(vm);
        }

        /// <summary>
        /// Passes the requested through to delete the treatmentType
        /// </summary>
        /// <param name="id"> Id of an TreatmentType</param>
        /// <returns> Send the user back to the page with all treatmentTypes</returns>
        [Authorize(Roles = "admin")]
        public IActionResult Delete(long id)
        {
            // Check if is valid
            if(ModelState.IsValid)
            {
                // Delete treatmenttype
                repository.Delete(id, false);
            }
            return RedirectToAction("index");
        }
    }
}