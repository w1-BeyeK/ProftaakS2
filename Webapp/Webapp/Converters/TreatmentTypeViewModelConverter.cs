using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class TreatmentTypeViewModelConverter : IViewModelConverter<TreatmentType, TreatmentTypeDetailViewModel>
    {
        public List<TreatmentTypeDetailViewModel> ModelsToViewModel(List<TreatmentType> models)
        {
            List<TreatmentTypeDetailViewModel> result = new List<TreatmentTypeDetailViewModel>();

            foreach(TreatmentType model in models)
            {
                result.Add(ModelToViewModel(model));
            }

            return result;
        }

        public TreatmentTypeDetailViewModel ModelToViewModel(TreatmentType model)
        {
            TreatmentTypeDetailViewModel viewModel = new TreatmentTypeDetailViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Active = model.Active,
                DepartmentId = model.DepartmentId
            };

            return viewModel;
        }

        public List<TreatmentType> ViewModelsToModals(List<TreatmentTypeDetailViewModel> viewModels)
        {
            List<TreatmentType> result = new List<TreatmentType>();

            foreach(TreatmentTypeDetailViewModel viewModel in viewModels)
            {
                result.Add(ViewModelToModal(viewModel));
            }

            return result;
        }

        public TreatmentType ViewModelToModal(TreatmentTypeDetailViewModel viewModel)
        {
            TreatmentType model = new TreatmentType()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Active = viewModel.Active,
                DepartmentId = viewModel.DepartmentId
            };

            return model;
        }
    }
}
