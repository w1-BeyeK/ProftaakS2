using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class TreatmentViewModelConverter : IViewModelConverter<Treatment, TreatmentDetailViewModel>
    {
        public Treatment ViewModelToModel(TreatmentDetailViewModel vm)
        {
            Patient patient = new Patient()
            {
                Id = vm.PatientId,
            };

            TreatmentType treatmenttype = new TreatmentType()
            {
                Id = vm.TypeId,
            };

            Treatment treatment = new Treatment()
            {
                Id = vm.Id,
                Name = vm.Name,
                Patient = patient,
                BeginDate = vm.BeginDate + vm.BeginTime,
                EndDate = vm.EndDate + vm.EndTime,
                TreatmentType = treatmenttype,
                PatientName = vm.PatientName
            };

            return treatment;
        }

        public TreatmentDetailViewModel ModelToViewModel(Treatment treatment)
        {
            TreatmentDetailViewModel vm = new TreatmentDetailViewModel()
            {
                Id = treatment.Id,
                Name = treatment.Name,
                TypeId = treatment.TreatmentTypeId,
                PatientId = treatment.PatientId,
                PatientName = treatment.PatientName,
                BeginDate = treatment.BeginDate,
                EndDate = treatment.EndDate,
                DoctorName = treatment.DoctorName,
                Age = treatment.GetAge()
            };
            return vm;
        }

        public List<TreatmentDetailViewModel> ModelsToViewModel(List<Treatment> models)
        {
            List<TreatmentDetailViewModel> result = new List<TreatmentDetailViewModel>();

            foreach(Treatment treatment in models)
            {
                result.Add(ModelToViewModel(treatment));
            }
            return result;
        }

        public List<Treatment> ViewModelsToModels(List<TreatmentDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }
    }
}
