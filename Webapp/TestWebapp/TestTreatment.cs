using Microsoft.AspNetCore.Identity;
using System;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestTreatment
    {
        [Fact]
        public void TreatmentConstructor()
        {
            string username = "Sjaak";
            string password = "Loeki";
            string email = "Sjaak@gmail.com";
            string role = "doctor";

            Doctor doctor1 = new Doctor(1, username, email);
            Doctor doctor2 = new Doctor(2, username, email, password);
            Doctor doctor3 = new Doctor();

            Assert.Equal(username, doctor1.UserName);
            Assert.Equal(email, doctor1.Email);
            Assert.Equal(role, doctor1.Role);
            Assert.Equal(username, doctor2.UserName);
            Assert.Equal(email, doctor2.Email);
            Assert.Equal(password, doctor2.Password);
            Assert.Equal(role, doctor2.Role);
            Assert.Equal(role, doctor3.Role);
        }
        verwerkditlater
    }
}
