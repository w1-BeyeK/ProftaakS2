﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class TreatmentTypeViewModel
    {
        public List<TreatmentTypeDetailViewModel> TreatmentTypes { get; set; } = new List<TreatmentTypeDetailViewModel>();
    }
}
