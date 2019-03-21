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
            Patient patient1 = new Patient(1, username, email);
            Patient patient2 = new Patient(2, username, email, password);
            Patient patient3 = new Patient(3, username, email, password);

            Assert.Equal(username, patient1.UserName);
            Assert.Equal(email, patient1.Email);
            Assert.Equal(role, patient1.Role);
            Assert.Equal(username, patient2.UserName);
            Assert.Equal(email, patient2.Email);
            Assert.Equal(password, patient2.Password);
            Assert.Equal(role, patient2.Role);

        }

        
    }
}
