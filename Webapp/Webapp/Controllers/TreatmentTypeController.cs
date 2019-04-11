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
    [Authorize(Roles = "admin")]
    public class TreatmentTypeController : Controller
    {
        private readonly TreatmentTypeRepository repository;
        private readonly DepartmentRepository departmentRepository;
        private readonly InstitutionRepository institutionRepository;
        private readonly IViewModelConverter<TreatmentType, TreatmentTypeDetailViewModel> converter;

        public TreatmentTypeController(TreatmentTypeRepository treatmentRepository, 
            DepartmentRepository departmentRepository,
            InstitutionRepository institutionRepository)
        {
            this.repository = treatmentRepository;
            this.departmentRepository = departmentRepository;
            this.institutionRepository = institutionRepository;
            converter = new TreatmentTypeViewModelConverter();
        }

        public IActionResult Index()
        {
            TreatmentTypeViewModel vm = new TreatmentTypeViewModel()
            {
                TreatmentTypes = new List<TreatmentTypeDetailViewModel>()
            };

            List<TreatmentType> treatmentTypes = repository.GetAll();
            if (treatmentTypes.Count < 1)
                return View(vm);

            vm.TreatmentTypes = converter.ModelsToViewModel(treatmentTypes);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            if (id < 1)
                return BadRequest("No user found");
            
            TreatmentType model = repository.GetById(id);
            TreatmentTypeDetailViewModel vm = converter.ModelToViewModel(model);

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
        
        public IActionResult Create()
        {
            List<Department> departments = departmentRepository.GetAll();
            List<Institution> institutions = institutionRepository.GetAll();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach(Institution i in institutions)
            {
                SelectListGroup group = new SelectListGroup();
                group.Name = i.Name;

                foreach(Department dm in departments.Where(d => d.InstitutionId == i.Id))
                {
                    items.Add(new SelectListItem
                    {
                        Value = dm.Id.ToString(),
                        Text = dm.Name,
                        Group = group
                    });
                }
            }

            //IEnumerable < SelectListItem > items =
            //    from value in departments
            //    select new SelectListItem
            //    {
            //        Text = value.Name,
            //        Value = value.Id.ToString(),
            //    };

            TreatmentTypeDetailViewModel vm = new TreatmentTypeDetailViewModel
            {
                Departments = items.ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(TreatmentTypeDetailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                TreatmentType tt = converter.ViewModelToModal(vm);
                long id = repository.Add(tt);

                return RedirectToAction("details", new { id });
            }
            else
            {
                return View(vm);
            }
            
        }

        public IActionResult Edit(long id)
        {
            if(ModelState.IsValid)
            {
                TreatmentType tt = repository.GetById(id);

                if (tt == null)
                    return BadRequest("User not found.");

                List<Department> departments = departmentRepository.GetAll();

                TreatmentTypeDetailViewModel vm = converter.ModelToViewModel(tt);
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(TreatmentTypeDetailViewModel vm)
        {
            if(ModelState.IsValid)
            {
                TreatmentType tt = converter.ViewModelToModal(vm);
                repository.Update(tt);

                if (tt.Active)
                    return RedirectToAction("details", new { id = tt.Id });
                else
                    return RedirectToAction("index");
            }
            return View(vm);
        }

        public IActionResult Delete(long id)
        {
            if(ModelState.IsValid)
            {
                repository.Delete(id);
            }
            return RedirectToAction("index");
        }
    }
}