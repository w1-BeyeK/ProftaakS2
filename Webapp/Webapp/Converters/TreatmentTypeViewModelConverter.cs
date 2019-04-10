using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class TreatmentTypeViewModelConverter
    {
        public List<TreatmentTypeDetailViewModel> TreatmentTypeToViewModel(List<TreatmentType> types)
        {
            List<TreatmentTypeDetailViewModel> Types = new List<TreatmentTypeDetailViewModel>();

            foreach (TreatmentType t in types)
            {
                TreatmentTypeDetailViewModel type = new TreatmentTypeDetailViewModel
                {
                    Name = t.Name,
                    Description = t.Description
                };

                Types.Add(type);
            }

            return Types;
        }
    }
}
