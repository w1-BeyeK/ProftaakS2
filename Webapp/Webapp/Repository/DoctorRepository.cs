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

        /// <summary>
        /// An administrator can add a doctor
        /// </summary>
        public bool AddDoctor(Doctor doctor)
        {
            return Context.AddDoctor(doctor);
        }

        /// <summary>
        /// An administrator can update a doctor
        /// </summary>
        public bool UpdateDoctor(long id, Doctor doctor)
        {
            return Context.UpdateDoctor(id, doctor);
        }

        /// <summary>
        /// An administrator can activate or deactivate a doctor by its id
        /// </summary>
        public bool ActiveDoctorByIdAndActive(long id, bool active)
        {
            return Context.ActiveDoctorByIdAndActive(id, active);
        }

        /// <summary>
        /// An administrator can get all doctors of a department
        /// </summary>
        public List<Doctor> GetAllDoctorsByDepartmentId(long id)
        {
            return Context.GetAllDoctorsByDepartmentId(id);
        }

        /// <summary>
        /// An administrator can add a doctor by its id
        /// </summary>
        public Doctor GetDoctorById(long id)
        {
            return Context.GetDoctorById(id);
        }
    }
}
