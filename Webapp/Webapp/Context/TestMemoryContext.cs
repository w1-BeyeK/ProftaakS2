using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    
    public class TestMemoryContext //: ICommentContext, IDepartmentContext, IDoctorContext, IInstitutionContext, IPatientContext, ITreatmentContext, ITreatmentTypeContext
    {
        /*protected List<Patient> patients = new List<Patient>();
        protected List<Treatment> treatments = new List<Treatment>();
        protected List<Doctor> doctors = new List<Doctor>();
        protected List<Department> departments = new List<Department>();
        protected List<Institution> institutions = new List<Institution>();
        protected List<TreatmentType> treatmentTypes = new List<TreatmentType>();

        public bool Insert(Comment comment, long treatmentId)
        {
            if (treatments.Exists(t => t.Id == treatmentId))
            {
                treatments.Find(t => t.Id == treatmentId).Comments.Add(comment);
                return true;
            }
            return false;
        }

        public List<Comment> GetByTreatmentId(long id)
        {
            return treatments.Find(t => t.Id == id).Comments;
        }

        public bool Delete(Department department)
        {
            departments.FirstOrDefault(d => d.Id == department.Id).Active = department.Active;
            return true;
        }

        public long Insert(Department department)
        {
            departments.Add(department);
            return department.Id;
        }

        public List<Department> GetByInstitution(long id)
        {
            return new List<Department>(institutions.Find(t => t.Id == id).Departments);
        }

        public Department GetById(long id)
        {
            return departments.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(Department department)
        {

            //
            return true;
        }

        public bool AddDoctorToDepartment(long departmentId, long doctorId)
        {
            throw new NotImplementedException();
        }

        //TODO : GetAllByInstitution
        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }

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

        public Doctor IDoctorContext.GetById(long id)
        {
            return doctors.FirstOrDefault(d => d.Id == id);
        }

        List<Doctor> IDoctorContext.GetAll()
        {
            return doctors;
        }

        public List<Doctor> GetByDepartment(long id)
        {
            //throw new NotImplementedException();
            //By department id!????????
            return doctors;
        }

        public List<Doctor> IDoctorContext.GetByInstitution(long id)
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
        */
    }
}
