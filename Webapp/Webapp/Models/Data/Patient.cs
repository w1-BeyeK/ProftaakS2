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

        public Patient(int id, string username, string email) : base(id, username, email)
        {
            Role = "patient";
        }

        public Patient(int id, string userName, string email, string password) : base(id, userName, email, password)
        {
            Role = "patient";
        }

        public Patient(int id, string userName, string email, string password, string name, DateTime birth, string phoneNumber, string mail, bool active, Gender gender, long bSN, string contactPersonName, string contactPersonPhone, int houseNumber, string zipcode, bool privContactPersonName, bool privContactPersonPhone, bool privMail, bool privPhoneNumber, bool privAdress, bool privGender, bool privBirthDate) : base (id, userName, email, password, name, birth, phoneNumber, active, gender)
        {
            BSN = bSN;
            ContactPersonName = contactPersonName;
            ContactPersonPhone = contactPersonPhone;
            HouseNumber = houseNumber;
            Zipcode = zipcode;
            PrivContactPersonName = privContactPersonName;
            PrivContactPersonPhone = privContactPersonPhone;
            PrivMail = privMail;
            PrivPhoneNumber = privPhoneNumber;
            PrivAdress = privAdress;
            PrivGender = privGender;
            PrivBirthDate = privBirthDate;
            Departments = new List<Department>();
            Treatments = new List<Treatment>();

            Role = "patient";
        }

        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public void AddTreatment(Treatment treatment)
        {
            Treatments.Add(treatment);
        }

        public int GetAge()
        {
            throw new NotImplementedException();
        }
    }
}
