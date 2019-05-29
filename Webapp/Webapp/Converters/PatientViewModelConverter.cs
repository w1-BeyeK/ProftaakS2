using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class PatientViewModelConverter : IViewModelConverter<Patient, PatientDetailViewModel>
    {
        public Patient ViewModelToModel(PatientDetailViewModel vm)
        {
            return new Patient(vm.Id, null, vm.Email, vm.Name)
            {
                Birth = vm.Birth,
                BSN = vm.BSN,
                ContactPersonName = vm.ContactPersonName,
                ContactPersonPhone = vm.ContactPersonPhone,
                Gender = (Gender)vm.GenderId,
                HouseNumber = vm.HouseNumber,
                Phone = vm.Phone,
                Zipcode = vm.Zipcode,
                PrivAdress = vm.PrivAdress,
                PrivContactPersonName = vm.PrivContactPersonName,
                PrivContactPersonPhone = vm.PrivContactPersonPhone,
                PrivBirthDate = vm.PrivBirthDate,
                PrivGender = vm.PrivGender,
                PrivMail = vm.PrivMail,
                PrivPhone = vm.PrivPhone
            };
        }

        public PatientDetailViewModel ModelToViewModel(Patient patient)
        {
            return new PatientDetailViewModel()
            {
                Id = patient.Id,
                Email = patient.Email,
                UserName = patient.UserName,
                Birth = patient.Birth,
                BSN = patient.BSN,
                ContactPersonName = patient.ContactPersonName,
                ContactPersonPhone = patient.ContactPersonPhone,
                GenderId = (int)patient.Gender,
                HouseNumber = patient.HouseNumber,
                Phone = patient.Phone,
                Zipcode = patient.Zipcode,
                Name = patient.Name,
                PrivAdress = patient.PrivAdress,
                PrivContactPersonName = patient.PrivContactPersonName,
                PrivContactPersonPhone = patient.PrivContactPersonPhone,
                PrivBirthDate = patient.PrivBirthDate,
                PrivGender = patient.PrivGender,
                PrivMail = patient.PrivMail,
                PrivPhone = patient.PrivPhone,
                Genders = new List<string>()
                {
                    "Man",
                    "Vrouw",
                    "Anders"
                }
            };
        }

        public List<PatientListViewModel> PatientlistToViewModel(List<Patient> patienten)
        {
            List<PatientListViewModel> Patienten = new List<PatientListViewModel>();

            foreach (Patient p in patienten)
            {
                PatientListViewModel patient = new PatientListViewModel
                {
                    UserId = p.Id,
                    Name = p.Name,
                    GenderId = (int)p.Gender,
                    Birth = p.Birth,
                    Status = p.Status,
                    Genders = new List<string>()
                    {
                    "Man",
                    "Vrouw",
                    "Anders"
                    }
                };

                Patienten.Add(patient);
            }

            return Patienten;
        }

        public List<PatientDetailViewModel> ModelsToViewModel(List<Patient> models)
        {
            throw new NotImplementedException();
        }

        public List<Patient> ViewModelsToModels(List<PatientDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }
        
    }
}
