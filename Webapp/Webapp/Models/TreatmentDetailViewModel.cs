using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class TreatmentDetailViewModel
    {
        [Required]
        public long Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Naam mag maximaal 50 characters zijn.")]
        public string Name { get; set; }
        public long TypeId { get; set; }
        public string TypeName { get; set; }
        public long PatientId { get; set; }
        public string PatientName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BeginDate { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan BeginTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.DateTime)]
        public TimeSpan EndTime { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        [Required]
        public Comment Description { get; set; }
        [Required]
        [Range(0, 150, ErrorMessage = "Enkel leeftijden tussen 0 en 150")]
        public int Age { get; set; }
        public List<PatientListViewModel> Patients { get; set; }
        public List<TreatmentTypeDetailViewModel> TreatmentTypes { get; set; }
    }
}
