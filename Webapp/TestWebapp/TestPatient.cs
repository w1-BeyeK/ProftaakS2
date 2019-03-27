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
            Patient patient = new Patient(1, username, email);
            

            Assert.Equal(username, patient.UserName);
            Assert.Equal(email, patient.Email);
            Assert.Equal(role, patient.Role);

            patient = new Patient(2, username, email, password);

            Assert.Equal(username, patient.UserName);
            Assert.Equal(email, patient.Email);
            Assert.Equal(password, patient.Password);
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


        }
    }
}
