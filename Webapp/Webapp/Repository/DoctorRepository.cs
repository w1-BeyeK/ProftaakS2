using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class DoctorRepository
    {
        private readonly IContext context;

        public DoctorRepository(IContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// An administrator can add a doctor
        /// </summary>
        public bool Add(Doctor doctor)
        {
            return context.AddDoctor(doctor);
        }

        /// <summary>
        /// An administrator can add a doctor to a department
        /// </summary>
        bool AddToDepartment(long departmentId, long doctorId)
        {
            return context.AddDoctorToDepartment(departmentId, doctorId);
        }

        /// <summary>
        /// An administrator can update a doctor
        /// </summary>
        public bool Update(long id, Doctor doctor)
        {
            return context.UpdateDoctor(id, doctor);
        }

        /// <summary>
        /// An administrator can get all doctors
        /// </summary>
        public List<Doctor> GetAll()
        {
            return context.GetAllDoctors();
        }

        /// <summary>
        /// An administrator can get all doctors of a department
        /// </summary>
        public List<Doctor> GetByDepartment(long id)
        {
            return context.GetAllDoctorsByDepartmentId(id);
        }

        /// <summary>
        /// An administrator can get all doctors of an institution
        /// </summary>
        public List<Doctor> GetByInstitution(long id)
        {
            return context.GetAllDoctorsByInstitutionId(id);
        }

        /// <summary>
        /// An administrator can add a doctor by its id
        /// </summary>
        public Doctor GetById(long id)
        {
            return context.GetDoctorById(id);
        }
    }
}
