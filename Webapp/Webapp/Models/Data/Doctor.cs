using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Doctor : UserAccount
    {
        //TODO : Moet dit in de constructor?
        //TODO : Moet dit ook in Classendiagram???
        public string Function { get; set; }
        public long EmployeeNumber { get; set; }

        public Doctor(long id, string userName, string email, string name) : base((int)id, userName, email, name)
        {
            Role = "doctor";
        }

        public Doctor(long id, string userName, string email, string password, string name, DateTime birth, string phoneNumber, bool active, Gender gender) : base(id, userName, email, password, name, birth, phoneNumber, active, gender)
        {
            Role = "doctor";
            EmployeeNumber = Id;
        }
    }
}
