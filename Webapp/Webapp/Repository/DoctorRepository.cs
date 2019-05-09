using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context;
using Webapp.Context.InterfaceContext;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class DoctorRepository // : ICRUDRepository<T>
    {
        private readonly IDoctorContext context;

        public DoctorRepository(IDoctorContext context)
        {
            this.context = context ?? throw new NullReferenceException("De dokterContext is leeg.");
        }

        /// <summary>
        /// An administrator can add a doctor
        /// </summary>
        public long Insert(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new NullReferenceException("De dokter is leeg.");
            }
            return context.Insert(doctor);
        }

        /// <summary>
        /// An administrator can add a doctor to a department
        /// </summary>
        bool AddToDepartment(long departmentId, long doctorId)
        {
            if (departmentId < 1)
            {
                throw new NullReferenceException("Het afdelingId is leeg.");
            }
            if(doctorId < 1)
            {
                throw new NullReferenceException("Het dokterId is leeg.");
            }
            return context.AddToDepartment(departmentId, doctorId);
        }

        /// <summary>
        /// An administrator can update a doctor
        /// </summary>
        public bool Update(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new NullReferenceException("De dokter is leeg.");
            }
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
            if (id < 1)
            {
                throw new NullReferenceException("Het afdelingId is leeg.");
            }
            return context.GetByDepartment(id);
        }

        /// <summary>
        /// An administrator can get all doctors of an institution
        /// </summary>
        public List<Doctor> GetByInstitution(long id)
        {
            if (id < 1)
            {
                throw new NullReferenceException("Het instellingId is leeg.");
            }
            return context.GetByInstitution(id);
        }

        /// <summary>
        /// An administrator can add a doctor by its id
        /// </summary>
        public Doctor GetById(long id)
        {
            if (id < 1)
            {
                throw new NullReferenceException("Het dokterId is leeg.");
            }
            return context.GetById(id);
        }
    }
}
