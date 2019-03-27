using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Conv
{
    public class TreatmentConverter
    {
        public Treatment ViewModelToTreatment(TreatmentDetailViewModel vm)
        {
            Patient patient = new Patient()
            {
                Id = vm.PatientId,
                Name = vm.PatientName
            };

            Treatment treatment = new Treatment()
            {
                Id = vm.Id,
                Name = vm.Name,
                Patient = patient,
                BeginDate = vm.BeginDate,
                EndDate = vm.EndDate
            };

            return treatment;
        }

        public TreatmentDetailViewModel ViewModelFromTreatment(Treatment treatment)
        {
            TreatmentDetailViewModel vm = new TreatmentDetailViewModel()
            {
                Id = treatment.Id,
                Name = treatment.Name,
                PatientId = treatment.Patient.Id,
                PatientName = treatment.Patient.Name,
                BeginDate = treatment.BeginDate,
                EndDate = treatment.EndDate
            };
            return vm;
        }
    }
}
