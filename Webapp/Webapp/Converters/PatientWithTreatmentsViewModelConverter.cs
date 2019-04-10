using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class PatientWithTreatmentsViewModelConverter
    {
        public Patient ViewModelToPatient(PatientDetailViewModel vm)
        {
            Patient patient = new Patient()
            {
                Id = vm.Id,
                Name = vm.Name,
                Birth = vm.Birth
            };

            foreach (TreatmentDetailViewModel t in vm.TreatmentDetailViewModels)
            {
                Treatment treatment = new Treatment()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Patient = patient,
                    BeginDate = t.BeginDate,
                    EndDate = t.EndDate,
                    TreatmentType = t.Type,
                    Comments = new List<Comment>(t.Comments),
                };
                patient.AddTreatment(treatment);
            }

            return patient;
        }

        public PatientDetailViewModel PatientToViewModel(Patient patient)
        {
            PatientDetailViewModel vm = new PatientDetailViewModel()
            {
                Id = patient.Id,
                Name = patient.Name,
                Birth = patient.Birth,
                Age = patient.GetAge()
            };
            vm.TreatmentDetailViewModels = new List<TreatmentDetailViewModel>();
            foreach (Treatment t in patient.Treatments)
            {
                //The first comment is the description
                t.Comments.OrderBy(x => x.Date);
                List<Comment> comments = t.Comments;
                Comment description = comments[0];
                comments.RemoveAt(0);

                TreatmentDetailViewModel treatmentDetailViewModel = new TreatmentDetailViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Type = t.TreatmentType,
                    BeginDate = t.BeginDate,
                    EndDate = t.EndDate,
                    Comments = comments,
                    Description = description,
                    Age = t.GetAge()
                };
                vm.TreatmentDetailViewModels.Add(treatmentDetailViewModel);
            }

            return vm;
        }
    }
}
