using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class DoctorViewModelConverter
    {
        public Doctor ViewModelToDoctor(DoctorDetailViewModel vm)
        {
            return new Doctor(vm.EmployeeNumber, vm.UserName, vm.Email, vm.Name)
            {
                Birth = vm.Birth,
                Gender = vm.Gender,
                PhoneNumber = vm.PhoneNumber,
                PrivMail = vm.PrivMail,
                PrivPhoneNumber = vm.PrivPhonenumber
            };
        }

        public DoctorDetailViewModel DoctorToViewModel(Doctor doctor)
        {
            return new DoctorDetailViewModel()
            {
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

        public List<DoctorListViewModel> DoctorlistToViewModel(List<Doctor> doctors)
        {
            List<DoctorListViewModel> Doctors = new List<DoctorListViewModel>();

            foreach (Doctor d in doctors)
            {
                DoctorListViewModel doctor = new DoctorListViewModel()
                {
                    EmployeeNumber = d.EmployeeNumber,
                    Name = d.Name,
                    Gender = d.Gender,
                    Birth = d.Birth
                };

                Doctors.Add(doctor);
            }
            return Doctors;
        }
    }
}
