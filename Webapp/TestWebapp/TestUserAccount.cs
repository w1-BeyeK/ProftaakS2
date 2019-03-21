using System;
using System.Text;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestUserAccount
    {
        [Fact]
        public void UserAccountConstructor()
        {
            int id = 1;
            string username = "Spons";
            string email = "Henk@gmail.com";
            string password = "Sjaak";

            UserAccount userAccount1 = new UserAccount(id, username, email);
            UserAccount userAccount2 = new UserAccount(id, username, email, password);
            UserAccount userAccount3 = new UserAccount();

            Assert.Equal(id, userAccount1.Id);
            Assert.Equal(username, userAccount1.UserName);
            Assert.Equal(email, userAccount1.Email);
            Assert.Equal(id, userAccount2.Id);
            Assert.Equal(username, userAccount2.UserName);
            Assert.Equal(email, userAccount2.Email);
            Assert.Equal(password, userAccount2.Password);
        }
    }
}
