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
        public List<TreatmentListViewModel> TreatmentListToViewModel(List<TreatmentType> types)
        {
            List<TreatmentListViewModel> Types = new List<TreatmentListViewModel>();

            foreach (TreatmentType t in types)
            {
                TreatmentListViewModel type = new TreatmentListViewModel
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
