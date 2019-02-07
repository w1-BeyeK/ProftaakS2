using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class TreadmentType
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Treadment> Treadments { get; set; }
    }
}
