﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class TreatmentTypeDetailViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required]
        [StringLength(65535)]
        [Display(Name = "Beschrijving")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Actief")]
        public bool Active { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        [Display(Name = "Afdeling")]
        public long DepartmentId { get; set; }

        public List<SelectListItem> Departments { get; set; }
    }
}
