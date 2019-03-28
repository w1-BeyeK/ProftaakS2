using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class TreatmentRepository
    {
        IContext context;

        public bool AddTreatment(Treatment treatment)
        {
            return context.AddTreatment(treatment);
        }
    }
}
