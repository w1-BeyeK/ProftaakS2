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
            this.context = context;
        }

        public UserAccount GetById(long id)
        {
            return this.context.GetById(id);
        }
        public List<UserAccount> GetAll()
        {
            return this.context.GetAll();
        }
        public UserAccount GetForDoctor(long id)
        {
            return GetAll().FirstOrDefault(a => a.DoctorId == id);
        }
        public UserAccount GetForPatient(long id)
        {
            return GetAll().FirstOrDefault(a => a.PatientId == id);
        }
        public long Insert(UserAccount obj)
        {
            return this.context.Insert(obj);
        }
        public bool Update(UserAccount obj)
        {
            return this.context.Update(obj);
        }
    }
}
