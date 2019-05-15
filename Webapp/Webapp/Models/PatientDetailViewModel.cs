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
        [StringLength(200, ErrorMessage = "Username length must be between 1 and 200.", MinimumLength = 1)]
        public string UserName { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Email length must be between 1 and 200.", MinimumLength = 1)]
        public string Email { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Name length must be between 1 and 200.", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [StringLength(15, ErrorMessage = "PhoneNumber telefoonnummer is tussen de 7 en 15 tekens lang.", MinimumLength = 7)]
        public string PhoneNumber { get; set; }
        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "BSN is niet binnen de grenzen van 1 en 9223372036854775807")]
        public long BSN { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "ContactPersonName length must be between 1 and 200.", MinimumLength = 1)]
        public string ContactPersonName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "ContactPersonPhone length must be between 1 and 200.", MinimumLength = 1)]
        [DataType(DataType.PhoneNumber)]
        public string ContactPersonPhone { get; set; }
        public int HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public bool PrivContactPersonName { get; set; }
        public bool PrivContactPersonPhone { get; set; }
        public bool PrivMail { get; set; }
        public bool PrivPhoneNumber { get; set; }
        public bool PrivAdress { get; set; }
        public bool PrivGender { get; set; }
        public bool PrivBirthDate { get; set; }
        public int Age { get; set; }
        public List<TreatmentDetailViewModel> TreatmentDetailViewModels { get; set; }
    }
}
