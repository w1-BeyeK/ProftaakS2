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
    }
}
