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

        public bool ActiveDoctorByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public bool ActivePatientByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public bool ActiveTreatmentTypeByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public bool AddComment(Comment comment, long treatmentId)
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

        public bool AddTreatment(Treatment treatment, long doctorId, long patientId)
        {
            throw new NotImplementedException();
        }

        public bool AddTreatmentType(TreatmentType treatmentType)
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsByTreatmentId(long treatmentId)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartmentsByInstitutionId(long id)
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorsByDepartmentId(long id)
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

        public List<Treatment> GetTreatmentsByDoctorId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetTreatmentsByPatientId(long id)
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
