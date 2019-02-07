using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Treadment
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public TreadmentType TreadmentType { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
