using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Department
    {
        public Institution Institution { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<TreadmentType> TreadmentTypes { get; set; }
    }
}
