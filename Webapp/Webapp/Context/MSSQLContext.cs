using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class MSSQLContext : IContext
    {
        public bool ActivateDepartment(Department department, bool activate)
        {
            throw new NotImplementedException();
        }

        public bool ActivateDoctor(Doctor doctor, bool activate)
        {
            throw new NotImplementedException();
        }

        public bool ActivateInstitution(Institution institution, bool activate)
        {
            throw new NotImplementedException();
        }

        public bool AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public bool AddDepartment()
        {
            throw new NotImplementedException();
        }

        public bool AddDoctor()
        {
            throw new NotImplementedException();
        }

        public bool AddInstitution(Institution institution)
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

        public bool AssignDoctor(Department department, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool EditDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public bool EditDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool EditDoctorPrivacy(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool EditInstitution(Institution institution)
        {
            throw new NotImplementedException();
        }

        public bool EditPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool EditPatientPrivacy(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool EditTreatment(Treatment treatment)
        {
            throw new NotImplementedException();
        }

        public bool EditTreatmentType(TreatmentType treatmentType)
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorById(long id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(long id)
        {
            throw new NotImplementedException();
        }

        public Administrator LoginAdmin(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Doctor LoginDoctor(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Patient LoginPatient(string username, string password)
        {
            throw new NotImplementedException();
        }

        public List<Department> ShowDepartments(Institution institution)
        {
            throw new NotImplementedException();
        }

        public List<Department> ShowDepartments(Institution institution, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> ShowDoctors(Department department)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> ShowDoctors(Patient patient)
        {
            throw new NotImplementedException();
        }

        public List<Patient> ShowPatients(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> ShowTreatments(Patient patient)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> ShowTreatmentsByDoctorId(int doctorId)
        {
            throw new NotImplementedException();
        }

        public List<TreatmentType> ShowTreatmentTypes(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
