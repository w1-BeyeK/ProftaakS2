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
        public string Mail { get; set; }
        public bool Active { get; set; }
        public Gender Gender { get; set; }

        public UserAccount(int id, string userName, string email) : base(id, userName, email)
        { }

        public UserAccount(int id, string userName, string email, string password) : base(id, userName, email, password)
        { }

        public UserAccount(long id, string userName, string email, string password, string name, DateTime birth, string phoneNumber, string mail, bool active, Gender gender) : base(id, userName, email, password, name)
        {
            Birth = birth;
            PhoneNumber = phoneNumber;
            Mail = mail;
            Active = active;
            Gender = gender;
        }
    }
}
