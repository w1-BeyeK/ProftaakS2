using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Webapp.Context
{
    public class MSSQLContext : IContext
    {
        /// <summary>
        /// Datarow to object X parser
        /// </summary>
        private readonly IParser parser;

        /// <summary>
        /// Handler that executes your command or select query
        /// </summary>
        private readonly IHandler handler;

        /// <summary>
        /// Constructor with default parameters
        /// </summary>
        /// <param name="parser">Object parser</param>
        /// <param name="handler">Query handler</param>
        public MSSQLContext(IParser parser, IHandler handler)
        {
            this.parser = parser;
            this.handler = handler;
        }

        public bool AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public bool ActiveDepartmentByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public bool ActiveDoctorByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public bool ActivePatientByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public bool ActiveTreatmentTypeByIdAndActive(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public bool AddComment(Comment comment, long treatmentId)
        {
            throw new NotImplementedException();
        }

        public bool AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public bool AddDepartmentToInstitution(long institutionId, long departmentId)
        {
            throw new NotImplementedException();
        }

        public bool AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool AddDoctorToDepartment(long departmentId, long doctorId)
        {
            throw new NotImplementedException();
        }

        public bool AddInstitution(Institution institution)
        {
            throw new NotImplementedException();
        }

        public bool AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool AddTreatment(Treatment treatment, long treatmentTypeId, long doctorId, long patientId)
        {
            throw new NotImplementedException();
        }

        public bool AddTreatmentType(TreatmentType treatmentType)
        {
            try
            {
                treatmentType.DepartmentId = 1;
                string query = "insert into PTS2_TreatmentType(DepartmentId, Name, Description, Active) values(@departmentId, @name, @description, @active)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("name", treatmentType.Name),
                    new KeyValuePair<string, object>("departmentId", treatmentType.DepartmentId.ToString()),
                    new KeyValuePair<string, object>("description", treatmentType.Description),
                    new KeyValuePair<string, object>("active", treatmentType.Active == true ? "1" : "0"),
                };

                handler.ExecuteCommand(query, parameters);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<Patient> GetAllActivePatients()
        {
            throw new NotImplementedException();
        }

        public List<TreatmentType> GetAllActiveTreatmentTypes()
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllCommentsByTreatmentId(long treatmentId)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAllDepartmentsByInstitutionId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctorsByDepartmentId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctorsByInstitutionId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Institution> GetAllInstitutions()
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetAllPatientsByDoctorId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetAllTreatmentsByDoctorId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetAllTreatmentsByPatientId(long id)
        {
            throw new NotImplementedException();
        }

        public List<TreatmentType> GetAllTreatmentTypesByActive(bool active)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(long id)
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorById(long id)
        {
            throw new NotImplementedException();
        }

        public Institution GetInstitutionById(long id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(long id)
        {
            string query = "select * from PTS2_TreatmentType where Id = @id";

            var dbResult = handler.ExecuteSelect(query, id);

            return default(Patient);
        }
        
        /// <summary>
        /// Get all treatment types
        /// </summary>
        /// <returns>List of treatmenttypes</returns>
        public List<TreatmentType> GetTreatmentTypes()
        {
            // Create result
            List<TreatmentType> result = new List<TreatmentType>();
            // Set query
            string query = "select * from PTS2_TreatmentType";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach(DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out TreatmentType treatmentType))
                    result.Add(treatmentType);
            }

            return result;
        }

        public bool UpdateDepartment(long id, Department department)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDoctor(long id, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInstitution(long id, Institution institution)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePatient(long id, Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTreatment(long id, Treatment Treatment)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTreatmentType(long id, TreatmentType treatmentType)
        {
            throw new NotImplementedException();
        }

        public TreatmentType GetTreatmentTypeById(long id)
        {
            throw new NotImplementedException();
        }

        public Treatment GetTreatmentById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
