using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class PatientRepository
    {
        IContext context;

        public PatientRepository(IContext context)
        {
            this.context = context;
        }

        public Patient LoginPatient(string username, string password)
        {
            return context.LoginPatient(username, password);
        }

        public bool EditPatient(Patient patient)
        {
            return context.EditPatient(patient);
        }

        public bool EditPatientPrivacy(Patient patient)
        {
            return context.EditPatientPrivacy(patient);
        }

        /// <summary>
        /// Shows all doctors of a patient.
        /// </summary>
        public List<Doctor> ShowDoctorsOfPatient(Patient patient)
        {
            return context.ShowDoctors(patient);
        }
    }
}
