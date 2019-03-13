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
        IContext context;

        public Doctor LoginDoctor(string username, string password)
        {
            return context.LoginDoctor(username, password);
        }

        public bool AddDoctor(Doctor doctor)
        {
            return context.AddDoctor();
        }

        public bool EditDoctor(Doctor doctor)
        {
            return context.EditDoctor(doctor);
        }

        public bool EditDoctorPrivacy(Doctor doctor)
        {
            return context.EditDoctorPrivacy(doctor);
        }

        /// <summary>
        /// Used both to activate and deactive doctors.
        /// </summary>
        public bool ActivateDoctor(Doctor doctor, bool activate)
        {
            return context.ActivateDoctor(doctor, activate);
        }

        /// <summary>
        /// Shows all doctors from one of its department(s)
        /// </summary>
        public List<Doctor> ShowDoctors(Department department)
        {
            return context.ShowDoctors(department);
        }

        /// <summary>
        /// Shows all patients of a doctor.
        /// </summary>
        public List<Patient> ShowPatients(Doctor doctor)
        {
            return context.ShowPatients(doctor);
        }
    }
}
