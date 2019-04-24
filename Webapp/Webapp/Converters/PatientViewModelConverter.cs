﻿using System;
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
            return new Patient(vm.Id, vm.UserName, vm.Email, vm.Name)
            {
                Birth = vm.Birth,
                BSN = vm.BSN,
                ContactPersonName = vm.ContactPersonName,
                ContactPersonPhone = vm.ContactPersonPhone,
                Gender = vm.Gender,
                HouseNumber = vm.HouseNumber,
                PhoneNumber = vm.PhoneNumber,
                Zipcode = vm.Zipcode,
                PrivAdress = vm.PrivAdress,
                PrivContactPersonName = vm.PrivContactPersonName,
                PrivContactPersonPhone = vm.PrivContactPersonPhone,
                PrivBirthDate = vm.PrivBirthDate,
                PrivGender = vm.PrivGender,
                PrivMail = vm.PrivMail,
                PrivPhoneNumber = vm.PrivPhoneNumber
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
                Gender = patient.Gender,
                HouseNumber = patient.HouseNumber,
                PhoneNumber = patient.PhoneNumber,
                Zipcode = patient.Zipcode,
                Name = patient.Name,
                PrivAdress = patient.PrivAdress,
                PrivContactPersonName = patient.PrivContactPersonName,
                PrivContactPersonPhone = patient.PrivContactPersonPhone,
                PrivBirthDate = patient.PrivBirthDate,
                PrivGender = patient.PrivGender,
                PrivMail = patient.PrivMail,
                PrivPhoneNumber = patient.PrivPhoneNumber
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
                    Gender = p.Gender,
                    Birth = p.Birth
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
