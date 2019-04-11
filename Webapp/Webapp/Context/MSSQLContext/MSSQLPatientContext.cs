using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MSSQLContext
{
    public class MSSQLPatientContext : BaseMSSQLContext, IPatientContext
    {
        //TODO : Change Queries!!!!
        public MSSQLPatientContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        public Patient GetById(long id)
        {
            string query = $"select * from PTS2_TreatmentType where Id = {id}";

            var dbResult = handler.ExecuteSelect(query, id);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out Patient patient))
                return patient;
            else
                return default(Patient);
        }

        /// <summary>
        /// Get all treatment types
        /// </summary>
        /// <returns>List of treatmenttypes</returns>
        public List<Patient> GetAll()
        {
            // Create result
            List<Patient> result = new List<Patient>();
            // Set query
            string query = "select * from PTS2_TreatmentType where active = 1";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Patient patient))
                    result.Add(patient);
            }

            return result;
        }

        public long Insert(Patient patient)
        {
            try
            {
                string query = "insert into PTS2_TreatmentType(DepartmentId, Name, Description, Active) OUTPUT INSERTED.Id values(@departmentId, @name, @description, @active)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    //new KeyValuePair<string, object>("name", patient.Name),
                    //new KeyValuePair<string, object>("departmentId", patient.DepartmentId),
                    //new KeyValuePair<string, object>("description", patient.Description),
                    //new KeyValuePair<string, object>("active", "1"),
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Patient patient)
        {
            try
            {
                string query = "update PTS2_TreatmentType set @fields where Id = @id";

                string fields = "";
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", patient.Id)
                };

                if (patient.Name != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[name] = @name";
                    parameters.Add(new KeyValuePair<string, object>("name", patient.Name));
                }
                if (!string.IsNullOrWhiteSpace(fields))
                    fields += ",";
                fields += "active = @active";
                parameters.Add(new KeyValuePair<string, object>("active", patient.Active ? "1" : "0"));

                query = query.Replace("@fields", fields);

                handler.ExecuteCommand(query, parameters);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Delete(Patient patient)
        {
            try
            {
                string query = "update PTS2_TreatmentType set Active = 0 where Id = @id";

                handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", patient.Id)
                });
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<Patient> GetAllPatientsByDoctorId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
