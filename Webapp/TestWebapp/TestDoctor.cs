using Microsoft.AspNetCore.Identity;
using System;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestDoctor
    {
        [Fact]
        public void DoctorConstructor()
        {
            string username = "SJAAK";
            string password = "Loeki";
            string email = "sk@gmail.com";
            string name = "Piotr";
            DateTime birthDate = new DateTime(1980 - 03 - 20);
            string phoneNumber = "0428375212";
            bool active = true;
            Gender gender = Gender.Female;
            string function = "Kaakchirurg";
            long employeeNumber = 2138128;
            string role = "doctor";


            Doctor doctor = new Doctor(1, username, email, password, name, birthDate, phoneNumber, active, gender)
            {
                Function = function,
                EmployeeNumber = employeeNumber
            };

            Assert.Equal(1, doctor.Id);
            Assert.Equal(username, doctor.UserName);
            Assert.Equal(email, doctor.Email);
            Assert.Equal(role, doctor.Role);
            Assert.Equal(name, doctor.Name);
            Assert.Equal(birthDate, doctor.Birth);
            Assert.Equal(phoneNumber, doctor.Phone);
            Assert.Equal(active, doctor.Active);
            Assert.Equal(gender, doctor.Gender);
            Assert.Equal(function, doctor.Function);
            Assert.Equal(employeeNumber, doctor.EmployeeNumber);
            Assert.Equal(role, doctor.Role);
        }
    }
}
