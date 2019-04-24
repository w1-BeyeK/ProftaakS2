using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryDoctorContext : IDoctorContext
    {
        public bool Delete(Doctor doctor)
        {
            int index = BaseMemoryContext.doctors.FindIndex(t => t.Id == doctor.Id);
            if (index >= 0)
            {
                BaseMemoryContext.doctors[index].Active = doctor.Active;
                return true;
            }
            return false;
        }

        public long Insert(Doctor doctor)
        {
            if (BaseMemoryContext.doctors.Count > 0)
            {
                BaseMemoryContext.doctors.OrderBy(d => d.Id);
                doctor.Id = BaseMemoryContext.doctors.Last().Id + 1;
            }
            else
            {
                doctor.Id = 1;
            }
            BaseMemoryContext.doctors.Add(doctor);
            return doctor.Id;
        }

        Doctor IUniversalGenerics<Doctor>.GetById(long id)
        {
            return BaseMemoryContext.doctors.FirstOrDefault(d => d.Id == id);
        }

        List<Doctor> IUniversalGenerics<Doctor>.GetAll()
        {
            return BaseMemoryContext.doctors;
        }

        public List<Doctor> GetByDepartment(long id)
        {
            //throw new NotImplementedException();
            //By department id!????????
            return BaseMemoryContext.doctors;
        }

        List<Doctor> IDoctorContext.GetByInstitution(long id)
        {
            List<Department> departmentDoctor = BaseMemoryContext.institutions.Find(t => t.Id == id).Departments;
            //Get all doctors of all the departments and distinct all double doctors
            throw new NotImplementedException();
        }

        public bool Update(Doctor doctor)
        {
            int index = BaseMemoryContext.doctors.FindIndex(p => p.Id == doctor.Id);
            if (index >= 0)
            {
                BaseMemoryContext.doctors[index].Email = doctor.Email;
                BaseMemoryContext.doctors[index].Password = doctor.Password;
                BaseMemoryContext.doctors[index].PhoneNumber = doctor.PhoneNumber;
                BaseMemoryContext.doctors[index].PrivMail = doctor.PrivMail;
                BaseMemoryContext.doctors[index].PrivPhoneNumber = doctor.PrivPhoneNumber;
                BaseMemoryContext.doctors[index].UserName = doctor.UserName;
                return BaseMemoryContext.doctors.Exists(d => d == doctor);
            }
            return false;
        }
        public bool AddToDepartment(long departmentId, long doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
