using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class DepartmentViewModelConverter : IViewModelConverter<Department, DepartmentDetailViewModel>
    {
        public List<DepartmentDetailViewModel> ModelsToViewModel(List<Department> models)
        {
            List<DepartmentDetailViewModel> result = new List<DepartmentDetailViewModel>();
            foreach(Department department in models)
            {
                result.Add(ModelToViewModel(department));
            }

            return result;
        }

        public DepartmentDetailViewModel ModelToViewModel(Department model)
        {
            return new DepartmentDetailViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Active = model.Active,
                Description = model.Description,
                InstitutionId = model.InstitutionId
            };
        }

        public List<Department> ViewModelsToModels(List<DepartmentDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Department ViewModelToModel(DepartmentDetailViewModel viewModel)
        {
            return new Department
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                InstitutionId = viewModel.InstitutionId,
                Active = viewModel.Active
            };
        }
    }
}
