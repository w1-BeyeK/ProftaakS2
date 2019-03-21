using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class TreatmentType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }

        public TreatmentType(string name, string description, IEnumerable<Department> departments, IEnumerable<Doctor> doctors, IEnumerable<Treatment> treatments)
        {
            Name = name;
            Description = description;
            Departments = departments;
            Doctors = doctors;
            Treatments = treatments;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
