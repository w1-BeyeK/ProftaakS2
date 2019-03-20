using System;
using System.Text;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestUserAccount
    {
        [Fact]
        public void AdministratorConstructor()
        {
            string username = "Henk";
            string password = "Sjoeki";
            string email = "Henk@gmail.com";
            string role = "admin";

            Administrator administrator1 = new Administrator(1, username, email);
            Administrator administrator2 = new Administrator(2, username, email, password);
            Administrator administrator3 = new Administrator();

            Assert.Equal(username, administrator1.UserName);
            Assert.Equal(email, administrator1.Email);
            Assert.Equal(role, administrator1.Role);
            Assert.Equal(username, administrator2.UserName);
            Assert.Equal(email, administrator2.Email);
            Assert.Equal(password, administrator2.Password);
            Assert.Equal(role, administrator2.Role);
            Assert.Equal(role, administrator3.Role);
        }
    }
}
