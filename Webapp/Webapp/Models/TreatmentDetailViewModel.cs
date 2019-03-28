using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class TreatmentDetailViewModel
    {
        public int Id { get; set; }
        public string TreatmentName { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndTime { get; set; }
        public string Comments { get; set; }
        public string Description { get; set; }
    }
}
