using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class DoctorListViewModel
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "ArtsId is niet binnen de grenzen van 1 en 9223372036854775807")]
        [Display(Name = "Werknemersnummer")]
        public long EmployeeNumber { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "Naam lengte moet tussen 1 and 75 karakters.", MinimumLength = 1)]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Geslacht")]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime Birth { get; set; }

        [Display(Name = "Functie")]
        public string Fuction { get; set; }
    }
}
