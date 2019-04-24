using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webapp.Models
{
    public class DepartmentDetailViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public long InstitutionId { get; set; }

        public List<SelectListItem> Institutions { get; set; }
    }
}