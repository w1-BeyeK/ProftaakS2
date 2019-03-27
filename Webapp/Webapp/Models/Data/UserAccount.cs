using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public enum Gender { Male, Female };
    public abstract class UserAccount : BaseAccount
    {
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
        public Gender Gender { get; set; }

        public UserAccount(int id, string userName, string email, string password, string name) : base(id, userName, email, password, name)
        { }

        public UserAccount(long id, string userName, string email, string password, string name, DateTime birth, string phoneNumber, bool active, Gender gender) : base(id, userName, email, password, name)
        {
            Birth = birth;
            PhoneNumber = phoneNumber;
            Email = email;
            Active = active;
            Gender = gender;
        }
    }
}
