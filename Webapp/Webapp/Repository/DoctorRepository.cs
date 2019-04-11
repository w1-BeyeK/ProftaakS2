using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class DoctorRepository // : ICRUDRepository<T>
    {
        private readonly IDoctorContext context;

        public DoctorRepository(IDoctorContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// An administrator can add a doctor
        /// </summary>
        public long Add(Doctor doctor)
        {
            return context.Insert(doctor);
        }

        /// <summary>
        /// An administrator can add a doctor to a department
        /// </summary>
        bool AddToDepartment(long departmentId, long doctorId)
        {
            return context.AddToDepartment(departmentId, doctorId);
        }

        /// <summary>
        /// An administrator can update a doctor
        /// </summary>
        public bool Update(Doctor doctor)
        {
            return context.Update(doctor);
        }

        /// <summary>
        /// An administrator can get all doctors
        /// </summary>
        public List<Doctor> GetAll()
        {
            return context.GetAll();
        }

        /// <summary>
        /// An administrator can get all doctors of a department
        /// </summary>
        public List<Doctor> GetByDepartment(long id)
        {
            return context.GetByDepartment(id);
        }

        /// <summary>
        /// An administrator can get all doctors of an institution
        /// </summary>
        public List<Doctor> GetByInstitution(long id)
        {
            return context.GetByInstitution(id);
        }

        /// <summary>
        /// An administrator can add a doctor by its id
        /// </summary>
        public Doctor GetById(long id)
        {
            return context.GetById(id);
        }
    }
}
