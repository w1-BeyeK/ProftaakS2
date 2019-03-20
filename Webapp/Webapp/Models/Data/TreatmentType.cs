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

        //TODO : Moet dit in de constructor?
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }

        public TreatmentType(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
