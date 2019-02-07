using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Institution
    {
        public Administrator Administrator { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}
