using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class TreatmentDetailViewModel
    {
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        //public TreatmentType TreatmentType { get; set; }
        //public IEnumerable<Comment> Comments { get; set; }
    }
}
