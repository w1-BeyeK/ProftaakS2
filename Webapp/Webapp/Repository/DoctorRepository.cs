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
            return context.AddDoctor(doctor);
        }

        /// <summary>
        /// An administrator can add a doctor to a department
        /// </summary>
        bool AddDoctorToDepartment(long departmentId, long doctorId)
        {
            return context.AddDoctorToDepartment(departmentId, doctorId);
        }

        /// <summary>
        /// An administrator can update a doctor
        /// </summary>
        public bool UpdateDoctor(long id, Doctor doctor)
        {
            return context.UpdateDoctor(id, doctor);
        }

        /// <summary>
        /// An administrator can activate or deactivate a doctor by its id
        /// </summary>
        public bool ActiveDoctorByIdAndActive(long id, bool active)
        {
            return context.ActiveDoctorByIdAndActive(id, active);
        }

        /// <summary>
        /// An administrator can get all doctors
        /// </summary>
        public List<Doctor> GetAllDoctors()
        {
            return context.GetAllDoctors();
        }

        /// <summary>
        /// An administrator can get all doctors of a department
        /// </summary>
        public List<Doctor> GetAllDoctorsByDepartmentId(long id)
        {
            return context.GetAllDoctorsByDepartmentId(id);
        }

        /// <summary>
        /// An administrator can get all doctors of an institution
        /// </summary>
        public List<Doctor> GetAllDoctorsByInstitutionId(long id)
        {
            return context.GetAllDoctorsByInstitutionId(id);
        }

        /// <summary>
        /// An administrator can add a doctor by its id
        /// </summary>
        public Doctor GetDoctorById(long id)
        {
            return context.GetDoctorById(id);
        }

        public List<Doctor> GetDoctors()
        {
            return default(List<Doctor>);
        }
    }
}
