using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MSSQLContext
{
    public class MSSQLTreatmentContext : BaseMSSQLContext, ITreatmentContext
    {
        //TODO : Change queries!!!
        public MSSQLTreatmentContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        public Treatment GetById(long id)
        {
            string query = $"select * from PTS2_Treatment where Id = @id";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", id)
            };

            var dbResult = handler.ExecuteSelect(query, parameters);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out Treatment treatment))
                return treatment;
            else
                return default(Treatment);
        }

        /// <summary>
        /// Get all treatment types
        /// </summary>
        /// <returns>List of treatmenttypes</returns>
        public List<Treatment> GetAll()
        {
            // Create result
            List<Treatment> result = new List<Treatment>();
            // Set query
            string query = "select * from PTS2_Treatment";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Treatment treatment))
                    result.Add(treatment);
            }

            return result;
        }

        public long Insert(Treatment treatment)
        {
            try
            {
                string query = "insert into PTS2_Treatment(Name, DoctorId, PatientId, StartDate, EndDate, TreatmentType) OUTPUT INSERTED.Id values(@name, @doctorId, @patientId, @beginDate, @endDate, @treatmentTypeId)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("name", treatment.Name),
                    new KeyValuePair<string, object>("beginDate", treatment.BeginDate.ToString("yyyy-MM-dd")),
                    new KeyValuePair<string, object>("endDate", treatment.EndDate.ToString("yyyy-MM-dd")),
                    new KeyValuePair<string, object>("doctorId", treatment.DoctorId),
                    new KeyValuePair<string, object>("patientId", treatment.Patient.Id),
                    new KeyValuePair<string, object>("treatmentTypeId", treatment.TreatmentType.Id),
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Treatment treatment)
        {
            try
            {
                string query = "update PTS2_Treatment set @fields where Id = @id";

                string fields = "";
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", treatment.Id)
                };

                if (treatment.Name != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[name] = @name";
                    parameters.Add(new KeyValuePair<string, object>("name", treatment.Name));
                }
                if (treatment.BeginDate != DateTime.MinValue)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[beginDate] = @beginDate";
                    parameters.Add(new KeyValuePair<string, object>("beginDate", treatment.BeginDate));
                }
                if (treatment.EndDate != DateTime.MinValue)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[endDate] = @endDate";
                    parameters.Add(new KeyValuePair<string, object>("endDate", treatment.EndDate));
                }

                query = query.Replace("@fields", fields);

                handler.ExecuteCommand(query, parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Treatment treatment)
        {
            //try
            //{
            //    string query = "update PTS2_Treatment set Active = @active where Id = @id";

            //    handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
            //    {
            //        new KeyValuePair<string, object>("id", treatment.Id),
            //        new KeyValuePair<string, object>("active", treatment.Active),

            //    });
            //    return true;
            //}
            //catch (Exception e)
            //{
                return false;
            //}
        }

        public List<Treatment> GetByDoctor(long id)
        {
            try
            {
                // Create result
                List<Treatment> result = new List<Treatment>();
                // Set query
                string query = $"select * from PTS2_Treatment where DoctorId = @doctorId";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("doctorId", id)
            };

                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

                // Parse all rows
                foreach (DataRow dr in dbResult.Rows)
                {
                    // Parse only if succeeded
                    if (parser.TryParse(dr, out Treatment treatment))
                        result.Add(treatment);
                }

                return result;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public List<Treatment> GetByPatient(long id)
        {
            try
            {
                // Create result
                List<Treatment> result = new List<Treatment>();
                // Set query
                string query = $"select * from PTS2_Treatment where PatientId = @id";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", id)
            };

                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

                // Parse all rows
                foreach (DataRow dr in dbResult.Rows)
                {
                    // Parse only if succeeded
                    if (parser.TryParse(dr, out Treatment treatment))
                        result.Add(treatment);
                }

                return result;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public bool CheckTreatmentRelationship(long doctorId, long patientId)
        {
            try
            {
                // Create result
                List<Treatment> result = new List<Treatment>();

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("doctorId", doctorId),
                    new KeyValuePair<string, object>("patientId", patientId)
                };

                // Set query
                string query = $"select * from PTS2_Treatment where DoctorId = @doctorId and PatientId = @patientId and EndDate >= convert(date, {DateTime.Today.AddYears(-1)})";

                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

                // Parse all rows
                if(dbResult != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}
