using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class UserViewModel
    {
        public Patient Patient { get; set; } 
        public Doctor Doctor { get; set; }
    }
}
