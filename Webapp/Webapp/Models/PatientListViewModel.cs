using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class PatientListViewModel
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birth { get; set; }
    }
}
