using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Institution
    {
        public string Name { get; set; }
        public int HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public Administrator Administrator { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        public Institution(string name, int houseNumber, string zipcode, string phoneNumber, string country, Administrator administrator, IEnumerable<Department> departments)
        {
            Name = name;
            HouseNumber = houseNumber;
            Zipcode = zipcode;
            PhoneNumber = phoneNumber;
            Country = country;
            Administrator = administrator;
            Departments = departments;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
