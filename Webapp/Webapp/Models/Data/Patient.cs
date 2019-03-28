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
        public List<Department> Departments { get; set; }
        public List<Treatment> Treatments { get; set; }

        public Patient(int id, string userName, string email, string name) : base(id, userName, email, name)
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
            PrivPhoneNumber = true;
        }

        public Patient(int id, string userName, string email, string password, string name, DateTime birth, string phoneNumber, bool active, Gender gender, long bSN): base (id, userName, email, password, name, birth, phoneNumber, active, gender)
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
            PrivPhoneNumber = true;
        }

        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public void AddTreatment(Treatment treatment)
        {
            Treatments.Add(treatment);
        }

        public Patient() : base(-1, "", "", "")
        {

        }

        public int GetAge()
        {
            int age = (int)((DateTime.Today - Birth).Days / 365.25);
            return age;
        }
    }
}
