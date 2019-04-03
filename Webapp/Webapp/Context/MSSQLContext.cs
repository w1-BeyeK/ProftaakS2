using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;
using System.Data;
using System.Data.SqlClient;

namespace Webapp.Context
{
    public class MSSQLContext : IContext
    {
        string connectionString = "Server=mssql.fhict.local;Database=dbi409368;User Id=dbi409368;Password=Test123;";

        public bool AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public bool AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public bool AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool AddInstitution(Institution institution)
        {
            throw new NotImplementedException();
        }

        public bool AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool AddTreatment(Treatment treatment)
        {
            throw new NotImplementedException();
        }

        public bool AddTreatmentType(TreatmentType treatmentType)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDepartmentById(long id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDoctorById(long id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteInstitutionById(long id)
        {
            throw new NotImplementedException();
        }

        public bool DeletePatientById(long id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTreatmentById(long id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTreatmentTypeById(long id)
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetComments()
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmenById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctors()
        {
            throw new NotImplementedException();
        }

        public Institution GetInstitutionById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Institution> GetInstitutions()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetPatients()
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetPatientsByDoctorId(long id)
        {
            throw new NotImplementedException();
        }

        public Treatment GetTreatmentById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetTreatments()
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetTreatmentsByDoctor(long id)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetTreatmentsByPatient(long id)
        {
            throw new NotImplementedException();
        }

        public TreatmentType GetTreatmentTypeById(long id)
        {
            throw new NotImplementedException();
        }

        public List<TreatmentType> GetTreatmentTypes()
        {
            throw new NotImplementedException();
        }

        public bool UpdateDepartment(long id, Department department)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDoctor(long id, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInstitution(long id, Institution institution)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePatient(long id, Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTreatment(long id, Treatment Treatment)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTreatmentType(long id, TreatmentType treatmentType)
        {
            throw new NotImplementedException();
        }
    }
}
