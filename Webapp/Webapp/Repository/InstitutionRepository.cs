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

        /// <summary>
        /// An administrator can add an institution
        /// </summary>
        public bool AddInstitution(Institution institution)
        {
            return context.AddInstitution(institution);
        }

        /// <summary>
        /// A department is added to an institution
        /// </summary>
        bool AddDepartmentToInstitution(long institutionId, long departmentId)
        {
            return context.AddDepartmentToInstitution(institutionId, departmentId);
        }

        /// <summary>
        /// An administrator can update an institution
        /// </summary>
        public bool UpdateInstitution(long id, Institution institution)
        {
            return context.UpdateInstitution(id, institution);
        }

        /// <summary>
        /// An administrator or doctor can get all institutions
        /// </summary>
        public List<Institution> GetAllInstitutions()
        {
            return context.GetAllInstitutions();
        }

        /// <summary>
        /// An administrator or doctor can get a institution by its id
        /// </summary>
        public Institution GetInstitutionById(long id)
        {
            return context.GetInstitutionById(id);
        }
    }
}
