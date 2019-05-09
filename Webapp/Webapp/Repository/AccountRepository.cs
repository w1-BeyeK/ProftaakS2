using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class AccountRepository
    {
        protected readonly IAccountContext context;

        public AccountRepository(IAccountContext context)
        {
            this.context = context ?? throw new NullReferenceException("De accountContext is leeg.");
        }

        public UserAccount GetById(long id)
        {
            if (id < 1)
            {
                throw new NullReferenceException("Het accountId is leeg.");
            }
            return this.context.GetById(id);
        }
        public List<UserAccount> GetAll()
        {
            return this.context.GetAll();
        }
        public UserAccount GetForDoctor(long id)
        {
            if (id < 1)
            {
                throw new NullReferenceException("Het accountId is leeg.");
            }
            return GetAll().FirstOrDefault(a => a.DoctorId == id);
        }
        public UserAccount GetForPatient(long id)
        {
            if (id < 1)
            {
                throw new NullReferenceException("Het accountId is leeg.");
            }
            return GetAll().FirstOrDefault(a => a.PatientId == id);
        }
        public long Insert(UserAccount obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("Het account is leeg.");
            }
            return this.context.Insert(obj);
        }
        public bool Update(UserAccount obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("Het account is leeg.");
            }
            return this.context.Update(obj);
        }
    }
}