using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class DoctorRepository : BaseRepository
    {
        public DoctorRepository(IContext context) : base(context)
        {
        }

        public bool AddDoctor(Doctor doctor)
        {
            return Context.AddDoctor(doctor);
        }

        public bool EditDoctor(Doctor doctor)
        {
            return Context.UpdateDoctor(doctor.Id, doctor);
        }

        public Doctor GetDoctorById(long id)
        {
            return Context.GetDoctorById(id);
        }
    }
}
