using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class PatientRepository : BaseRepository
    {
        public PatientRepository(IContext context) : base(context)
        {
        }

        public Patient GetById(long id)
        {
            return Context.GetPatientById(id);
        }
    }
}
