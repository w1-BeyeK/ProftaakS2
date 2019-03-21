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
            string username = "Sjaak";
            string password = "Loeki";
            string email = "sk@gmail.com";
            string name = "Piotr";
            DateTime birthDate = new DateTime(1980 - 03 - 20);
            string phoneNumber = "0428375212";
            bool active = true;
            Gender gender = Gender.Female;
            string role = "doctor";

            Doctor doctor1 = new Doctor(1, username, email);
            Doctor doctor2 = new Doctor(2, username, email, "Haha", name, birthDate, phoneNumber, active, gender);

            Assert.Equal(username, doctor1.UserName);
            Assert.Equal(email, doctor1.Email);
            Assert.Equal(role, doctor1.Role);
            Assert.Equal(username, doctor2.UserName);
            Assert.Equal(email, doctor2.Email);
            Assert.Equal(password, doctor2.Password);
            Assert.Equal(name, doctor2.Name);
            Assert.Equal(birthDate, doctor2.Birth);
            Assert.Equal(phoneNumber, doctor2.PhoneNumber);
            Assert.Equal(active, doctor2.Active);
            Assert.Equal(gender, doctor2.Gender);
            Assert.Equal(role, doctor2.Role);
        }
    }
}
