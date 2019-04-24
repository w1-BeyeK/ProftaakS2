using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class TreatmentViewModelConverter
    {
        public Treatment ViewModelToTreatment(TreatmentDetailViewModel vm)
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
            };

            return treatment;
        }

        public TreatmentDetailViewModel TreatmentToViewModel(Treatment treatment)
        {
            TreatmentDetailViewModel vm = new TreatmentDetailViewModel()
            {
                Id = treatment.Id,
                Name = treatment.Name,
                TypeId = treatment.TreatmentTypeId,
                PatientId = treatment.PatientId,
                BeginDate = treatment.BeginDate,
                EndDate = treatment.EndDate,
                Age = treatment.GetAge()
            };
            return vm;
        }

        internal List<TreatmentDetailViewModel> TreatmentsToViewModel(List<Treatment> treatments)
        {
            List<TreatmentDetailViewModel> result = new List<TreatmentDetailViewModel>();

            foreach(Treatment treatment in treatments)
            {
                result.Add(TreatmentToViewModel(treatment));
            }
            return result;
        }
    }
}
