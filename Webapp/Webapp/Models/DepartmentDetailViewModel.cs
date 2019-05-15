using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webapp.Models
{
    public class DepartmentDetailViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Name length must be between 1 and 200.", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description length must be between 1 and 200.", MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "InstituutId is niet binnen de grenzen van 1 en 9223372036854775807")]
        public long InstitutionId { get; set; }

        public List<SelectListItem> Institutions { get; set; }
    }
}