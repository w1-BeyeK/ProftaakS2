using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Institution : Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public bool Active { get; set; }
        public Administrator Administrator { get; set; }
        public List<Department> Departments { get; set; }

        public Institution()
        { }

        public Institution(string name, int houseNumber, string zipcode, string phoneNumber, string country, Administrator administrator,bool active = true)
        {
            Name = name;
            HouseNumber = houseNumber;
            Zipcode = zipcode;
            PhoneNumber = phoneNumber;
            Country = country;
            Administrator = administrator;
            Departments = new List<Department>();
            Active = active;
        }

        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
