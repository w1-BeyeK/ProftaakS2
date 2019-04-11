using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class InstitutionRepository
    {
        private readonly IInstitutionContext context;

        public InstitutionRepository(IInstitutionContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// An administrator can add an institution
        /// </summary>
        public long AddInstitution(Institution institution)
        {
            return context.Insert(institution);
        }

        /// <summary>
        /// A department is added to an institution
        /// </summary>
        bool AddDepartmentToInstitution(long institutionId, long departmentId)
        {
            //return context.AddDepartmentToInstitution(institutionId, departmentId);
            return true;
        }

        /// <summary>
        /// An administrator can update an institution
        /// </summary>
        public bool Update(Institution institution)
        {
            return context.Update(institution);
        }

        /// <summary>
        /// An administrator or doctor can get all institutions
        /// </summary>
        public List<Institution> GetAll()
        {
            return context.GetAll();
        }

        /// <summary>
        /// An administrator or doctor can get a institution by its id
        /// </summary>
        public Institution GetById(long id)
        {
            return context.GetById(id);
        }
    }
}
