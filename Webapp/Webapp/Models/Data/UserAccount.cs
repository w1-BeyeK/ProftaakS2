using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public enum Gender { Male, Female };
    public class UserAccount : BaseAccount
    {
        //TODO : Moet dit in de constructor?
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public bool Active { get; set; }
        public Gender Gender { get; set; }

        public UserAccount(int id, string username, string email) : base(id, username, email)
        { }

        public UserAccount(int id, string username, string email, string password) : base(id, username, email, password)
        { }

        public UserAccount()
        {

        }

        public string ShowPersonalData()
        {
            throw new NotImplementedException();
        }
    }
}
