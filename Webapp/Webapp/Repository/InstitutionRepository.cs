using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class InstitutionRepository : BaseRepository
    {
        public InstitutionRepository(IContext context) : base(context)
        {
        }

        public bool AddInstitution(Institution institution)
        {
            return Context.AddInstitution(institution);
        }
    }
}
