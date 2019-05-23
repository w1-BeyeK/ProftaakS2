using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class PatientListViewModel
    {

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "PatiëntId is niet binnen de grenzen van 1 en 9223372036854775807")]
        public long UserId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Name length must be between 1 and 200.", MinimumLength = 1)]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Geslacht")]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime Birth { get; set; }
    }
}
