using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Treatment
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
