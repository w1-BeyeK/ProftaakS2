using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class DoctorTestContext : BaseTestContext, IDoctorContext
    {
        public bool Delete(Doctor doctor)
        {
            int index = doctors.FindIndex(t => t.Id == doctor.Id);
            if (index >= 0)
            {
                doctors[index].Active = doctor.Active;
                return true;
            }
            return false;
        }

        public long Insert(Doctor doctor)
        {
            //TODO : Get last id?!!?!?!?!?
            doctors.Add(doctor);
            return doctor.Id;
        }

        public Doctor GetById(long id)
        {
            return doctors.FirstOrDefault(d => d.Id == id);
        }

        public List<Doctor> GetAll()
        {
            return doctors;
        }

        public List<Doctor> GetByDepartment(long id)
        {
            //throw new NotImplementedException();
            //By department id!????????
            return doctors;
        }

        public List<Doctor> GetByInstitution(long id)
        {
            List<Department> departmentDoctor = institutions.Find(t => t.Id == id).Departments;
            //Get all doctors of all the departments and distinct all double doctors
            throw new NotImplementedException();
        }

        public bool Update(Doctor doctor)
        {
            Doctor oldDoctor = GetById(doctor.Id);
            oldDoctor = doctor;
            return true;
        }

        public bool AddToDepartment(long departmentId, long doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
