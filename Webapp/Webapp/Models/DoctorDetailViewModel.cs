using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class DoctorDetailViewModel
    {
        [Display(Name = "Werknemersnummer")]
        public long EmployeeNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime Birth { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Telefoonnummer moet tussen de 7 en 15 tekens lang zijn.", MinimumLength = 7)]
        [Phone]
        [Display(Name = "Telefoonnummer")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Geslacht")]
        public int GenderId { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "Gebruikersnaam moet minimaal 1 en maximaal 75 karakters lang zijn.", MinimumLength = 1)]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Email moet minimaal 1 en maximaal 255 karakters lang zijn.", MinimumLength = 1)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Naam moet minimaal 1 en maximaal 50 karakters lang zijn.", MinimumLength = 1)]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Leeftijd")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Email zichtbaar maken")]
        public bool PrivMail { get; set; }

        [Required]
        [Display(Name = "Telefoonnummer zichtbaar maken")]
        public bool PrivPhonenumber { get; set; }

        public List<TreatmentTypeDetailViewModel> TreatmentTypes { get; set; }
        public List<string> Genders { get; set; }
    }
}
