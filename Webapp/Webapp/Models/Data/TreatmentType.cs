using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class TreatmentType
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }

        public TreatmentType(IEnumerable<Department> departments, IEnumerable<Doctor> doctors, IEnumerable<Treatment> treatments)
        {
            Departments = departments;
            Doctors = doctors;
            Treatments = treatments;
        }
    }
}
