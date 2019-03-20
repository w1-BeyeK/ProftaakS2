using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class TestContext : IContext
    {
        private List<Patient> patients;

        public TestContext()
        {
            patients = new List<Patient>()
            {
                //new Patient()
                //{
                //    Name = "Kevin Beye",
                //    Mail = "k.beye@student.fontys.nl",
                //    Gender = Gender.Male,
                //    Password = "Test123",
                //    Active = true,
                //    Username = "kevinbeye",
                //    Birth = DateTime.Now
                //}
            };
        }

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
            Patient patient = patients.FirstOrDefault(p => p.UserName == username && p.Password == password);

            if (patient == null)
                throw new KeyNotFoundException("No patient found");

            return patient;
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

        public List<Treatment> ShowTreatments(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public List<TreatmentType> ShowTreatmentTypes(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
