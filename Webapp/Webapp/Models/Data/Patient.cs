using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Patient: UserAccount
    {        
        public long BSN { get; set; }
        
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }
        public int HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public bool PrivContactPersonName { get; set; }
        public bool PrivContactPersonPhone { get; set; }
        public bool PrivMail { get; set; }
        public bool PrivPhone { get; set; }
        public bool PrivAdress { get; set; }
        public bool PrivGender { get; set; }
        public bool PrivBirthDate { get; set; }
        public List<Department> Departments { get; set; }
        public List<Treatment> Treatments { get; set; }


        public Patient(long id, string userName, string email) : base(id, userName, email)
        {
            Departments = new List<Department>();
            Treatments = new List<Treatment>();

            Role = "patient";

            PrivAdress = true;
            PrivBirthDate = true;
            PrivContactPersonName = true;
            PrivContactPersonPhone = true;
            PrivGender = true;
            PrivMail = true;
            PrivPhone = true;
        }

        public Patient(long id, string userName, string email, string name) : base(id, userName, email, name)
        {
            Departments = new List<Department>();
            Treatments = new List<Treatment>();

            Role = "patient";

            PrivAdress = true;
            PrivBirthDate = true;
            PrivContactPersonName = true;
            PrivContactPersonPhone = true;
            PrivGender = true;
            PrivMail = true;
            PrivPhone = true;
        }

        public Patient(long id, string userName, string email, string password, string name, DateTime birth, string phoneNumber, bool active, Gender gender, long bSN): base (id, userName, email, password, name, birth, phoneNumber, active, gender)
        {
            BSN = bSN;
            Departments = new List<Department>();
            Treatments = new List<Treatment>();

            Role = "patient";

            PrivAdress = true;
            PrivBirthDate = true;
            PrivContactPersonName = true;
            PrivContactPersonPhone = true;
            PrivGender = true;
            PrivMail = true;
            PrivPhone = true;
        }

        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public void AddTreatment(Treatment treatment)
        {
            Treatments.Add(treatment);
        }

        public Patient()
        {

        }

        public int GetAge()
        {
            int age = (int)((DateTime.Today - Birth).Days / 365.25);
            return age;
        }
    }
}
