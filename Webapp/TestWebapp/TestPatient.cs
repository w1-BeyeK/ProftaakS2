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
            string username = "CHONG";
            string password = "ChiFan";
            string email = "Chong@gmail.com";
            string role = "patient";
            string name = "Henk";
            DateTime birth = new DateTime(2000-02-24);
            string phonenumber = "061237521";
            bool active = true;
            Gender gender = Gender.Male;
            long bsn = 048218512353;
            string contactPersonName = "Chong";
            string contactPersonPhone = "062937164";
            int houseNumber = 24;
            string zipcode = "3152SL";

            Patient patient = new Patient(1, username, email, name)
            {
                ContactPersonName = contactPersonName,
                ContactPersonPhone = contactPersonPhone,
                HouseNumber = houseNumber,
                Zipcode = zipcode
            };

            Assert.Equal(1, patient.Id);
            Assert.Equal(username, patient.UserName);
            Assert.Equal(email, patient.Email);
            Assert.Equal(name, patient.Name);
            Assert.Equal(role, patient.Role);
            Assert.Equal(contactPersonName, patient.ContactPersonName);
            Assert.Equal(contactPersonPhone, patient.ContactPersonPhone);
            Assert.Equal(houseNumber, patient.HouseNumber);
            Assert.Equal(zipcode, patient.Zipcode);
            Assert.True(patient.PrivAdress);
            Assert.True(patient.PrivBirthDate);
            Assert.True(patient.PrivContactPersonName);
            Assert.True(patient.PrivContactPersonPhone);
            Assert.True(patient.PrivGender);
            Assert.True(patient.PrivMail);
            Assert.True(patient.PrivPhone);

            patient = new Patient(1, username, email, password, name, birth, phonenumber, active, gender, bsn)
            {
                ContactPersonName = contactPersonName,
                ContactPersonPhone = contactPersonPhone,
                HouseNumber = houseNumber,
                Zipcode = zipcode
            };

            Assert.Equal(1, patient.Id);
            Assert.Equal(username, patient.UserName);
            Assert.Equal(email, patient.Email);
            Assert.Equal(name, patient.Name);
            Assert.Equal(birth, patient.Birth);
            Assert.Equal(phonenumber, patient.Phone);
            Assert.Equal(active, patient.Active);
            Assert.Equal(gender, patient.Gender);
            Assert.Equal(bsn, patient.BSN);
            Assert.Equal(role, patient.Role);
            Assert.Equal(contactPersonName, patient.ContactPersonName);
            Assert.Equal(contactPersonPhone, patient.ContactPersonPhone);
            Assert.Equal(houseNumber, patient.HouseNumber);
            Assert.Equal(zipcode, patient.Zipcode);
            Assert.True(patient.PrivAdress);
            Assert.True(patient.PrivBirthDate);
            Assert.True(patient.PrivContactPersonName);
            Assert.True(patient.PrivContactPersonPhone);
            Assert.True(patient.PrivGender);
            Assert.True(patient.PrivMail);
            Assert.True(patient.PrivPhone);
        }

        [Fact]
        public void AddDepartment()
        {
            Patient patient = new Patient(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female, 23);
            Department department = new Department(1, "name", "description", true);
            Department department2 = new Department(2, "name", "description", true);

            patient.AddDepartment(department);
            patient.AddDepartment(department2);

            Assert.True(patient.Departments.Exists(d => d == department));
            Assert.Equal(2, patient.Departments.Count);

            patient = new Patient(1, "username", "email", "name");

            patient.AddDepartment(department);
            patient.AddDepartment(department2);

            Assert.True(patient.Departments.Exists(d => d == department));
            Assert.Equal(2, patient.Departments.Count);

        }

        [Fact]
        public void AddTreatment()
        {
            Patient patient = new Patient(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female, 23);
            Doctor  doctor = new Doctor(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female);
            TreatmentType treatmentType = new TreatmentType("name", "description");
            Treatment treatment = new Treatment(1, "name", DateTime.MinValue, DateTime.Today, patient, doctor, treatmentType);
            Treatment treatment2 = new Treatment(1, "name", DateTime.MinValue, DateTime.Today);

            patient.AddTreatment(treatment);
            patient.AddTreatment(treatment2);

            Assert.True(patient.Treatments.Exists(t => t == treatment));
            Assert.Equal(2, patient.Treatments.Count);

            patient = new Patient(1, "username", "email", "name");

            patient.AddTreatment(treatment);
            patient.AddTreatment(treatment2);

            Assert.True(patient.Treatments.Exists(t => t == treatment));
            Assert.Equal(2, patient.Treatments.Count);
        }

        [Fact]
        public void GetAge()
        {
            Patient patient = new Patient(1, "username", "email", "password", "name", new DateTime(2000, 3, 20), "phonenumber", true, Gender.Female, 23);

            Assert.Equal(19, patient.GetAge());
        }
    }
}
