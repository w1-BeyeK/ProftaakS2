using System;
using System.Text;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestAdministrator
    {
        [Fact]
        public void AdministratorConstructor()
        {
            string username = "Henk";
            string password = "Sjoeki";
            string email = "Henk@gmail.com";
            string role = "admin";
            string name = "Henk";
            long employeeNumber = 2138129;

            Administrator administrator = new Administrator(1, username, email, password, name)
            {
                EmployeeNumber = employeeNumber
            };

            Assert.Equal(1, administrator.Id);
            Assert.Equal(username, administrator.UserName);
            Assert.Equal(email, administrator.Email);
            Assert.Equal(password, administrator.Password);
            Assert.Equal(name, administrator.Name);
            Assert.Equal(employeeNumber, administrator.EmployeeNumber);
            Assert.Equal(role, administrator.Role);
        }
    }
}
