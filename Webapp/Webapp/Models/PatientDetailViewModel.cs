using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class PatientDetailViewModel
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "PatiëntId is niet binnen de grenzen van 1 en 9223372036854775807")]
        public long Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Username length must be between 1 and 50.", MinimumLength = 1)]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Email length must be between 1 and 255.", MinimumLength = 1)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name length must be between 1 and 50.", MinimumLength = 1)]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime Birth { get; set; }

        [StringLength(15, ErrorMessage = "Phone telefoonnummer is tussen de 7 en 15 tekens lang.", MinimumLength = 7)]
        [Display(Name = "Telefoonnummer")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Geslacht")]
        public int GenderId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "BSN is niet binnen de grenzen van 1 en 9223372036854775807")]
        [Display(Name = "BSN")]
        public long BSN { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "ContactPersonName length must be between 1 and 75.", MinimumLength = 1)]
        [Display(Name = "Naam van de contactpersoon")]
        public string ContactPersonName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "ContactPersonPhone length must be between 1 and 50.", MinimumLength = 1)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefoonnummer van de contactpersoon")]
        public string ContactPersonPhone { get; set; }

        [Display(Name = "Huisnummer")]
        public int HouseNumber { get; set; }

        [Display(Name = "Postcode")]
        public string Zipcode { get; set; }

        [Display(Name = "Naam van de contactpersoon zichtbaar maken")]
        public bool PrivContactPersonName { get; set; }

        [Display(Name = "Telefoonnummer van de contactpersoon zichtbaar maken")]
        public bool PrivContactPersonPhone { get; set; }

        [Display(Name = "Email zichtbaar maken")]
        public bool PrivMail { get; set; }

        [Display(Name = "Telefoonnummer zichtbaar maken")]
        public bool PrivPhone { get; set; }

        [Display(Name = "Adres zichtbaar maken")]
        public bool PrivAdress { get; set; }

        [Display(Name = "Geslacht zichtbaar maken")]
        public bool PrivGender { get; set; }

        [Display(Name = "'Geboortedatum zichtbaar maken")]
        public bool PrivBirthDate { get; set; }

        [Display(Name = "Leeftijd zichtbaar maken")]
        public int Age { get; set; }

        public List<TreatmentDetailViewModel> TreatmentDetailViewModels { get; set; }
        public List<string> Genders { get; set; }
    }
}
