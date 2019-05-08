using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class DoctorViewModelConverter : IViewModelConverter<Doctor, DoctorDetailViewModel>
    {
        public Doctor ViewModelToModel(DoctorDetailViewModel vm)
        {
            return new Doctor(vm.EmployeeNumber, vm.UserName, vm.Email, vm.Name)
            {
                Id = vm.Id,
                Birth = vm.Birth,
                Gender = vm.Gender,
                PhoneNumber = vm.PhoneNumber,
                PrivMail = vm.PrivMail,
                PrivPhoneNumber = vm.PrivPhonenumber
            };
        }

        public DoctorDetailViewModel ModelToViewModel(Doctor doctor)
        {
            return new DoctorDetailViewModel()
            {
                Id = doctor.Id,
                EmployeeNumber = doctor.EmployeeNumber,
                Email = doctor.Email,
                UserName = doctor.UserName,
                Birth = doctor.Birth,
                Gender = doctor.Gender,
                Name = doctor.Name,
                Age = doctor.GetAge(),
                PhoneNumber = doctor.PhoneNumber,
                PrivMail = doctor.PrivMail,
                PrivPhonenumber = doctor.PrivPhoneNumber
            };
        }

        public List<DoctorDetailViewModel> ModelsToViewModel(List<Doctor> doctors)
        {
            List<DoctorDetailViewModel> result = new List<DoctorDetailViewModel>();

            foreach (Doctor d in doctors)
            {
                result.Add(ModelToViewModel(d));
            }
            return result;
        }

        public List<DoctorDetailViewModel> ModelsToViewModel(List<Doctor> models)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> ViewModelsToModels(List<DoctorDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }
    }
}
