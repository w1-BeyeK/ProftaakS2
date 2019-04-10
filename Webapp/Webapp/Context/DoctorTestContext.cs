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
        public bool ActiveDoctorByIdAndActive(long id, bool active)
        {
            int index = doctors.FindIndex(t => t.Id == id);
            if (index >= 0)
            {
                doctors[index].Active = active;
                return true;
            }
            return false;
        }

        public bool Insert(Doctor doctor)
        {
            doctors.Add(doctor);
            return true;
        }

        public Doctor GetById(long id)
        {
            return doctors.FirstOrDefault(d => d.Id == id);
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctors;
        }

        public List<Doctor> GetAllDoctorsByDepartmentId(long id)
        {
            //throw new NotImplementedException();
            //By department id!????????
            return doctors;
        }

        public List<Doctor> GetAllDoctorsByInstitutionId(long id)
        {
            List<Department> departmentDoctor = institutions.Find(t => t.Id == id).Departments;
            //Get all doctors of all the departments and distinct all double doctors
            throw new NotImplementedException();
        }

        public bool Update(long id, Doctor doctor)
        {
            if (id != doctor.Id)
                return false;

            Doctor oldDoctor = GetDoctorById(id);
            oldDoctor = doctor;
            return true;
        }
    }
}
