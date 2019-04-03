﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class TestContext : IContext
    {
        private List<Patient> patients = new List<Patient>();
        private List<Treatment> treatments = new List<Treatment>();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Comment> comments = new List<Comment>();
        private List<Department> departments = new List<Department>();
        private List<Institution> institutions = new List<Institution>();
        private List<TreatmentType> treatmentTypes = new List<TreatmentType>();

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
            comments.Add(new Comment("Arm afzagen", "De arm wordt afgezaagd",DateTime.Now));
            comments.Add(new Comment("Arm afzagen succes","De arm is afgezaagd",DateTime.Now));

            treatments = new List<Treatment>()
            {
                new Treatment()
                {
                    Name = "Zowarmarollen",
                    Id = 1,
                    BeginDate = new DateTime(2019, 04, 01, 11, 32, 21),
                    EndDate = DateTime.Now,
                    Comments = comments,
                    TreatmentType = new TreatmentType("Arm afzagen", "Arm gaat eraf"),
                }
            };
            patients = new List<Patient>()
            {
                new Patient(12, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Male,
                    Password = "Test123",
                    Active = true,
                    Birth = new DateTime(2000, 12, 3),
                    PhoneNumber = "0611061788",
                    BSN = 233619355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = treatments
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
            departments = new List<Department>();
            institutions = new List<Institution>();
            treatmentTypes = new List<TreatmentType>();
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
        public bool AddComment(Comment comment, long treatmentId)
        {
            throw new NotImplementedException();
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
        public bool ActiveDepartmentByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public bool AddDepartment(Department department)
        {
            departments.Add(department);
            return true;
        }

        public List<Department> GetDepartmentsByInstitutionId(long id)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(long id)
        {
            return departments.FirstOrDefault(t => t.Id == id);
        }

        public bool UpdateDepartment(long id, Department department)
        {
            if (id != department.Id)
                return false;

            Department oldDepartment = GetDepartmentById(id);
            oldDepartment = department;
            return true;
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

        public bool AddTreatment(Treatment treatment, long doctorId, long patientId)
        {
            throw new NotImplementedException();
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
            return treatments.FindAll(t => t.Doctor.Id == id);
        }

        public List<Treatment> GetTreatmentsByPatientId(long id)
        {
            return treatments.FindAll(t => t.Patient.Id == id);
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
        #endregion
    }
}
