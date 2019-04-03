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
        public TimeSpan BeginTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public PatientDetailViewModel PatientDetailViewModel { get; set; }
        
    }
}
