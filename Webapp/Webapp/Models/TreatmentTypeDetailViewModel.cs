using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class TreatmentTypeDetailViewModel
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(65535)]
        public string Description { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [Range(1, long.MaxValue)]
        public long DepartmentId { get; set; }
        [Required]
        public List<SelectListItem> Departments { get; set; }
    }
}
