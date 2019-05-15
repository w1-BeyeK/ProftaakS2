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
        public long EmployeeNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [StringLength(15, ErrorMessage = "Telefoonnummer is tussen de 7 en 15 tekens lang.", MinimumLength = 7)]
        public string Phone { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Username length must be between 1 and 200.", MinimumLength = 1)]
        public string UserName { get; set; }
        
        [StringLength(200, ErrorMessage = "Email length must be between 1 and 200.", MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Name length must be between 1 and 200.", MinimumLength = 1)]
        public string Name { get; set; }

        //[Range(0, 150, ErrorMessage = "CommentaarId is niet binnen de grenzen van {0} en {150}")]
        public int Age { get; set; }
        public bool PrivMail { get; set; }
        public bool PrivPhonenumber { get; set; }
        public List<TreatmentTypeDetailViewModel> TreatmentTypes { get; set; }
    }
}
