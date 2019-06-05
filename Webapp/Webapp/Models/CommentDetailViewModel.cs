using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class CommentDetailViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Je bericht moet minimaal 1 en maximaal 300 karakters bevatten", MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Je bericht moet minimaal 1 en maximaal 300 karakters bevatten", MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        public long TreatmentId { get; set; }
    }
}
