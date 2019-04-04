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

        public bool ActiveDepartmentByIdAndActive(long id, bool active)
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

        public List<Patient> GetAllActivePatients()
        {
            throw new NotImplementedException();
        }

        public List<TreatmentType> GetAllActiveTreatmentTypes()
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllCommentsByTreatmentId(long treatmentId)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAllDepartmentsByInstitutionId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctorsByDepartmentId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctorsByInstitutionId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Institution> GetAllInstitutions()
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetAllPatientsByDoctorId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetAllTreatmentsByDoctorId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetAllTreatmentsByPatientId(long id)
        {
            throw new NotImplementedException();
        }

        public List<TreatmentType> GetAllTreatmentTypesByActive(bool active)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(long id)
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorById(long id)
        {
            throw new NotImplementedException();
        }

        public Institution GetInstitutionById(long id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(long id)
        {
            throw new NotImplementedException();
        }

        public Treatment GetTreatmentById(long id)
        {
            throw new NotImplementedException();
        }

        public TreatmentType GetTreatmentTypeById(long id)
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
