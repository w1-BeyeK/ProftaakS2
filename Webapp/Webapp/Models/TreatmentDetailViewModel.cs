using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class TreatmentDetailViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public TreatmentType Type { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndTime { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Description { get; set; }
        public PatientDetailViewModel PatientDetailViewModel { get; set; }
        
    }
}
