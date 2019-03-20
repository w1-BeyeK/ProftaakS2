using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Patient: UserAccount
    {        
        //TODO : Moet dit in de constructor?
        public long BSN { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }
        public int HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public bool PrivContactPersonName { get; set; }
        public bool PrivContactPersonPhone { get; set; }
        public bool PrivMail { get; set; }
        public bool PrivPhoneNumber { get; set; }
        public bool PrivAdress { get; set; }
        public bool PrivGender { get; set; }
        public bool PrivBirthDate { get; set; }

        //TODO : Moet dit in de constructor?
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }

        public Patient(int id, string username, string email) : base(id, username, email)
        {
            Role = "patient";
        }

        public Patient(int id, string username, string email, string password) : base(id, username, email, password)
        {
            Role = "patient";
        }

        public int GetAge()
        {
            throw new NotImplementedException();
        }
    }
}
