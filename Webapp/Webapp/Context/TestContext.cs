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
        private List<Treatment> treatments;
        private List<Doctor> doctors;
        private List<Comment> comments;
        private List<Department> departments;
        private List<Institution> institutions;
        private List<TreatmentType> treatmentTypes;

        private static TestContext instance = null;

        public static TestContext GetInstance()
        {
            if (instance == null)
            {
                instance = new TestContext();
            }
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
                new Doctor(12, "kevin<3Catuja", "kevin.beye1999@hotmail.com", "Kevin")
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
            treatments = new List<Treatment>();
            comments = new List<Comment>();
            departments = new List<Department>();
            institutions = new List<Institution>();
            treatmentTypes = new List<TreatmentType>();
            treatments = new List<Treatment>()
            {
                new Treatment()
                {
                    Name = "Zowarmarollen",
                    Id = 1,
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Today,
                    Patient = patients.Find(t => t.Id == 12),
                    Doctor = doctors.Find(t => t.Id == 12)
                }
            };
        }

        #region Patient
        public bool AddPatient(Patient patient)
        {
            patients.Add(patient);
            return true;
        }

        public bool ActivePatientByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(long id)
        {
            return patients.FirstOrDefault(p => p.Id == id);
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public List<Patient> GetPatientsByDoctorId(long id)
        {
            // ??
            return patients;
        }

        public Patient LoginPatient(string username, string password)
        {
            Patient patient = patients.FirstOrDefault(p => p.UserName == username && p.Password == password);

            if (patient == null)
                throw new KeyNotFoundException("No patient found");

            return patient;
        }

        public bool UpdatePatient(long id, Patient patient)
        {
            if (id != patient.Id)
                return false;

            Patient oldPatient = GetPatientById(id);
            oldPatient = patient;
            return true;
        }

        #endregion
        #region Doctor
        public bool ActiveDoctorByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public bool AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
            return true;
        }

        public Doctor GetDoctorById(long id)
        {
            return doctors.FirstOrDefault(d => d.Id == id);
        }

        public List<Doctor> GetDoctorsByDepartmentId(long id)
        {
            return doctors;
        }

        public bool UpdateDoctor(long id, Doctor doctor)
        {
            if (id != doctor.Id)
                return false;

            Doctor oldDoctor = GetDoctorById(id);
            oldDoctor = doctor;
            return true;
        }
        #endregion
        #region Comment
        public bool AddComment(Comment comment)
        {
            comments.Add(comment);
            return true;
        }

        public List<Comment> GetCommentsByTreatmentId(long id)
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(long id)
        {
            return comments.FirstOrDefault(c => c.Id == id);
        }
        #endregion
        #region Department
        public bool AddDepartment(Department department)
        {
            departments.Add(department);
            return true;
        }

        public bool UpdateDepartment(long id, Department department)
        {
            if (id != department.Id)
                return false;

            Department oldDepartment = GetDepartmenById(id);
            oldDepartment = department;
            return true;
        }

        public bool ActiveDepartmentByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartmentsByInstitutionId(long id)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmenById(long id)
        {
            return departments.FirstOrDefault(d => d.Id == id);
        }
        #endregion
        #region Institution
        public bool AddInstitution(Institution institution)
        {
            institutions.Add(institution);
            return true;
        }

        public bool UpdateInstitution(long id, Institution institution)
        {
            if (id != institution.Id)
                return false;

            Institution oldInstitution = GetInstitutionById(id);
            oldInstitution = institution;
            return true;
        }

        public List<Institution> GetInstitutions()
        {
            return institutions;
        }

        public Institution GetInstitutionById(long id)
        {
            return institutions.FirstOrDefault(i => i.Id == id);
        }
        #endregion

        #region Treatment

        public bool AddTreatment(Treatment treatment)
        {
            treatments.Add(treatment);
            return true;
        }

        public bool UpdateTreatment(long id, Treatment treatment)
        {
            if (id != treatment.Id)
                return false;

            if (treatments.Exists(t => t.Id == treatment.Id))
            {
                int index = treatments.FindIndex(t => t.Id == treatment.Id);
                treatments[index] = treatment;
                return true;
            }
            return false;
        }

        public Treatment GetTreatmentById(long id)
        {
            return treatments.FirstOrDefault(t => t.Id == id);
        }

        public List<Treatment> GetTreatmentsByDoctorId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetTreatmentsByPatientId(long id)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region TreatmentType
        public bool AddTreatmentType(TreatmentType treatmentType)
        {
            treatmentTypes.Add(treatmentType);
            return true;
        }

        public bool UpdateTreatmentType(long id, TreatmentType treatmentType)
        {
            if (id != treatmentType.Id)
                return false;

            TreatmentType oldTreatmentType = GetTreatmentTypeById(id);
            oldTreatmentType = treatmentType;
            return true;
        }
        
        public bool ActiveTreatmentTypeByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public List<TreatmentType> GetTreatmentTypes()
        {
            throw new NotImplementedException();
        }

        public TreatmentType GetTreatmentTypeById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetTreatmentsByDoctor(long id)
        {
            return treatments.Where(t => t.Doctor != null && t.Doctor.Id == id).ToList();
        }

        public List<Treatment> GetTreatmentsByPatient(long id)
        {
            return treatments.Where(t => t.Patient != null && t.Patient.Id == id).ToList();
        }
    }
}
