using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class PatientRepository
    {
        IContext context;

        public PatientRepository(IContext context)
        {
            this.context = context;
        }

        public Patient GetById(long id)
        {
            return context.GetPatientById(id);
        }
    }
}
