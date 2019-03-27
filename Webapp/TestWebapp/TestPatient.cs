using Microsoft.AspNetCore.Identity;
using System;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestPatient
    {
        [Fact]
        public void PatientConstructor()
        {
            string username = "Chong";
            string password = "ChiFan";
            string email = "Chong@gmail.com";
            string role = "patient";
            string name = "Henk";
            DateTime birth = new DateTime(2000-02-24);
            string phonenumber = "061237521";
            bool active = true;
            Gender gender = Gender.Male;
            long bsn = 048218512353;

            Patient patient = new Patient(1, username, email);

            Assert.Equal(1, patient.Id);
            Assert.Equal(username, patient.UserName);
            Assert.Equal(email, patient.Email);
            Assert.Equal(role, patient.Role);

            patient = new Patient(2, username, email, password);

            Assert.Equal(2, patient.Id);
            Assert.Equal(username, patient.UserName);
            Assert.Equal(email, patient.Email);
            Assert.Equal(password, patient.Password);
            Assert.Equal(role, patient.Role);

            patient = new Patient(3, username, email, password, name, birth, phonenumber, active, gender, bsn);

            Assert.Equal(3, patient.Id);
            Assert.Equal(username, patient.UserName);
            Assert.Equal(email, patient.Email);
            Assert.Equal(password, patient.Password);
            Assert.Equal(name, patient.Name);
            Assert.Equal(birth, patient.Birth);
            Assert.Equal(phonenumber, patient.PhoneNumber);
            Assert.Equal(active, patient.Active);
            Assert.Equal(gender, patient.Gender);
            Assert.Equal(bsn, patient.BSN);
            Assert.Equal(role, patient.Role);
        }

        [Fact]
        public void AddDepartment()
        {
            Patient patient = new Patient(1, "username", "email");
            Department department = new Department("name", "description", true);
            Department department2 = new Department("name", "description", true);

            patient.AddDepartment(department);
            patient.AddDepartment(department2);

            Assert.True(patient.Departments.Exists(d => d == department));
            Assert.Equal(2, patient.Departments.Count);

            patient = new Patient(2, "username", "email", "password");

            patient.AddDepartment(department);
            patient.AddDepartment(department2);

            Assert.True(patient.Departments.Exists(d => d == department));
            Assert.Equal(2, patient.Departments.Count);

            patient = new Patient(3, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female, 23);

            patient.AddDepartment(department);
            patient.AddDepartment(department2);

            Assert.True(patient.Departments.Exists(d => d == department));
            Assert.Equal(2, patient.Departments.Count);
        }

        [Fact]
        public void AddTreatment()
        {
            Patient patient = new Patient(1, "username", "email");
            Doctor doctor = new Doctor(1, "username", "password");
            TreatmentType treatmentType = new TreatmentType("name", "description");
            Treatment treatment = new Treatment("name", DateTime.MinValue, DateTime.Today, patient, doctor, treatmentType);
            Treatment treatment2 = new Treatment("name", DateTime.MinValue, DateTime.Today, patient, doctor, treatmentType);

            patient.AddTreatment(treatment);
            patient.AddTreatment(treatment2);

            Assert.True(patient.Treatments.Exists(t => t == treatment));
            Assert.Equal(2, patient.Treatments.Count);

            patient = new Patient(2, "username", "email", "password");

            patient.AddTreatment(treatment);
            patient.AddTreatment(treatment2);

            Assert.True(patient.Treatments.Exists(t => t == treatment));
            Assert.Equal(2, patient.Treatments.Count);

            patient = new Patient(3, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female, 23);

            patient.AddTreatment(treatment);
            patient.AddTreatment(treatment2);

            Assert.True(patient.Treatments.Exists(t => t == treatment));
            Assert.Equal(2, patient.Treatments.Count);
        }
    }
}
