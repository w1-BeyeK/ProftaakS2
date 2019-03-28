using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class InstitutionRepository
    {
        IContext context;

        public bool AddInstitution(Institution institution)
        {
            return context.AddInstitution(institution);
        }
    }
}
