using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Doctor
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<TreadmentType> TreatmentTypes { get; set; }
        public IEnumerable<Treadment> Treadments { get; set; }
    }
}
