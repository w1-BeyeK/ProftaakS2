using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webapp.Models
{
    public class DepartmentDetailViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "De afdelingsnaam moet minimaal 3 en maximaal 100 karakters zijn")]
        [DataType(DataType.Text)]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "De beschrijving moet minimaal 3 en maximaal 100 karakters zijn")]
        [DataType(DataType.Text)]
        [Display(Name = "Beschrijving")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Actief is een vereiste")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "De beschrijving moet minimaal 3 en maximaal 100 karakters zijn")]
        [DataType(DataType.Text)]
        [Display(Name = "Afdeling actief maken")]
        public bool Active { get; set; }

        [Display(Name = "De institutie, waaronder de afdeling valt")]
        public long InstitutionId { get; set; }

        public List<SelectListItem> Institutions { get; set; }
    }
}