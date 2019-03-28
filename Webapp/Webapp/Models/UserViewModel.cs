using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class UserViewModel
    {
        public PatientDetailViewModel Patient { get; set; } 
        public Doctor Doctor { get; set; }
    }
}
