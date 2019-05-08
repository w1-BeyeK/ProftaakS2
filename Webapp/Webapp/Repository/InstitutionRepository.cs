using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context;
using Webapp.Context.InterfaceContext;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class InstitutionRepository // : ICRUDRepository<T>
    {
        private readonly IInstitutionContext context;

        public InstitutionRepository(IInstitutionContext context)
        {
            this.context = context ?? throw new NullReferenceException("De instellingcontext is leeg.");
        }

        /// <summary>
        /// An administrator can add an institution
        /// </summary>
        public long Insert(Institution institution)
        {
            if (institution == null)
            {
                throw new NullReferenceException("De instellingId is leeg.");
            }
            return context.Insert(institution);
        }

        /// <summary>
        /// A department is added to an institution
        /// </summary>
        public bool AddDepartmentToInstitution(long institutionId, long departmentId)
        {
            if (institutionId < 1)
            {
                throw new NullReferenceException("De instellingId is leeg.");
            }
            if (departmentId < 1)
            {
                throw new NullReferenceException("De afdelingId is leeg.");
            }
            //return context.AddDepartmentToInstitution(institutionId, departmentId);
            return true;
        }

        /// <summary>
        /// An administrator can update an institution
        /// </summary>
        public bool Update(Institution institution)
        {
            if (institution == null)
            {
                throw new NullReferenceException("De instelling is leeg.");
            }
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
            if (id < 1)
            {
                throw new NullReferenceException("De instellingId is leeg.");
            }
            return context.GetById(id);
        }
    }
}
