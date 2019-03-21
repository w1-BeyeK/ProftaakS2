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

        //TODO : Moet dit in de constructor?
        public Administrator Administrator { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        public Institution(string name, int houseNumber, string zipcode, string phoneNumber, string country)
        {
            Name = name;
            HouseNumber = houseNumber;
            Zipcode = zipcode;
            PhoneNumber = phoneNumber;
            Country = country;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
