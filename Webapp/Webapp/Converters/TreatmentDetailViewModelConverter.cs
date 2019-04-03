using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class TreatmentDetailViewModelConverter
    {
        public Patient ViewModelToTreatment(PatientDetailViewModel vm)
        {
            Patient patient = new Patient()
            {
                Id = vm.Id,
                Name = vm.Name
            };

            Treatment treatment = new Treatment()
            {
                Id = vm.TreatmentDetailViewModel.Id,
                Name = vm.TreatmentDetailViewModel.Name,
                Patient = patient,
                BeginDate = vm.TreatmentDetailViewModel.BeginDate,
                EndDate = vm.TreatmentDetailViewModel.EndDate,
                TreatmentType = vm.TreatmentDetailViewModel.Type
            };

            patient.AddTreatment(treatment);

            return patient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public PatientDetailViewModel PatientToViewModel(Patient patient)
        {
            TreatmentDetailViewModel treatmentDetailViewModel = new TreatmentDetailViewModel()
            {
                Id = patient.Treatments.First().Id,
                Name = patient.Treatments.First().Name,
                Type = patient.Treatments.First().TreatmentType,
                BeginDate = patient.Treatments.First().BeginDate,
                EndDate = patient.Treatments.First().EndDate
            };

            PatientDetailViewModel vm = new PatientDetailViewModel()
            {
                Id = patient.Id,
                Name = patient.Name,
                TreatmentDetailViewModel = treatmentDetailViewModel
            };
            
            return vm;
        }
    }
}
