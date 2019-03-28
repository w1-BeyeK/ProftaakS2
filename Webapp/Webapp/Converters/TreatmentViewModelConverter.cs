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
                Id = vm.PatientDetailViewModel.Id,
                Name = vm.PatientDetailViewModel.Name
            };

            Treatment treatment = new Treatment()
            {
                Id = vm.Id,
                Name = vm.TreatmentName,
                Patient = patient,
                BeginDate = vm.BeginDate,
                EndDate = vm.EndDate,
                TreatmentType = vm.TreatmentType
            };

            return treatment;
        }

        public TreatmentDetailViewModel TreatmentToViewModel(Treatment treatment)
        {
            PatientDetailViewModel patientDetailViewModel = new PatientDetailViewModel()
            {
                Id = treatment.Patient.Id,
                Name = treatment.Patient.Name,
            };

            TreatmentDetailViewModel vm = new TreatmentDetailViewModel()
            {
                Id = treatment.Id,
                TreatmentName = treatment.Name,
                TreatmentType = treatment.TreatmentType,
                PatientDetailViewModel = patientDetailViewModel,
                BeginDate = treatment.BeginDate,
                EndDate = treatment.EndDate
            };
            return vm;
        }
    }
}
