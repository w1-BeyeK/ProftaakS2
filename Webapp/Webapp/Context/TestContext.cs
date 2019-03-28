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
        private List<Treatment> treatments = new List<Treatment>();
        private List<Doctor> doctors;

        private static TestContext instance = null;

        public static TestContext GetInstance()
        {
            if (instance == null)
                instance = new TestContext();

            return instance;
        }

        public TestContext()
        {
            patients = new List<Patient>()
            {
                new Patient(12, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Male,
                    Password = "Test123",
                    Active = true,
                    Birth = DateTime.Now,
                    PhoneNumber = "0611061788",
                    BSN = 233619355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS"
                }
            };
            doctors = new List<Doctor>()
            {
                new Doctor(12, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin")
                {
                    Active = true,
                    Birth = DateTime.Now,
                    EmployeeNumber = 12,
                    Function = "HOI",
                    Gender = Gender.Male,
                    Password = "Test123",
                    PhoneNumber = "12345"
                }
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
            treatments.Add(treatment);
            return true;
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
            if (treatments.Exists(t => t.Id == treatment.Id))
            {
                int index = treatments.FindIndex(t => t.Id == treatment.Id);
                treatments[index] = treatment;
                return true;
            }
            return false;
        }

        public bool EditTreatmentType(TreatmentType treatmentType)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(long id)
        {
            return patients.FirstOrDefault(p => p.Id == id);
        }

        public Doctor GetDoctorById(long id)
        {
            return doctors.FirstOrDefault(d => d.Id == id);
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

        public List<Treatment> ShowTreatmentsByPatientId(long patientId)
        {
            List<Treatment> Treatments = treatments.FindAll(t => t.Patient.Id == patientId);
            return Treatments;
        }

        public List<Treatment> ShowTreatmentsByDoctorId(long doctorId)
        {
            List<Treatment> Treatments = treatments.FindAll(t => t.Doctor.Id == doctorId);
            return Treatments;
        }

        public List<TreatmentType> ShowTreatmentTypes(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
