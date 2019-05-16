using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class TreatmentViewModel
    {
        public List<TreatmentDetailViewModel> treatments { get; set; } = new List<TreatmentDetailViewModel>();
    }
}
