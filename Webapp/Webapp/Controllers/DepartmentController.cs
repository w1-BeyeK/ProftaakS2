using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;
using Webapp.Repository;

namespace Webapp.Controllers
{
    //[Authorize(Roles = "admin")]
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

        public IActionResult Index()
        {
            DepartmentViewModel vm = new DepartmentViewModel();

            List<Department> departments = departmentRepository.GetAll();
            if (departments.Count < 1)
                return View();

            vm.Departments = converter.ModelsToViewModel(departments);

            return View();
        }
    }
}