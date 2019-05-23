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
        [StringLength(75, ErrorMessage = "Naam mag maximaal 75 characters zijn.")]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "behandelingstype")]
        public long TypeId { get; set; }

        [Display(Name = "Behandelingstype")]
        public string TypeName { get; set; }

        [Display(Name = "Patiënt")]
        public long PatientId { get; set; }

        [Display(Name = "Naam van de patiënt")]
        public string PatientName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Begindatum")]
        public DateTime BeginDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Begintijd")]
        public TimeSpan BeginTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Einddatum")]
        public DateTime EndDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Eindtijd")]
        public TimeSpan EndTime { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        [Required]
        [Display(Name = "Beschrijving")]
        public Comment Description { get; set; }

        [Required]
        [Range(0, 150, ErrorMessage = "Enkel leeftijden tussen 0 en 150")]
        [Display(Name = "Leeftijd")]
        public int Age { get; set; }

        public List<PatientListViewModel> Patients { get; set; }
        public List<TreatmentTypeDetailViewModel> TreatmentTypes { get; set; }
    }
}
