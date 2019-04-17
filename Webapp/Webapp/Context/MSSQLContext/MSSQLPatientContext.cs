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
    public class MSSQLPatientContext : BaseMSSQLContext, IPatientContext
    {
        //TODO : Change Queries!!!!
        public MSSQLPatientContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        public Patient GetById(long id)
        {
            string query = $"select * from PTS2_Patient where Id = {id}";

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
            string query = "select * from PTS2_Patient where active = 1";

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
                string query = "insert into PTS2_Patient(Active, Birth, BSN, ContactPersonName, ContactPersonPhone, Email, Gender, HouseNumber, Name, NormalizedUserName, PhoneNumber, PrivAdress) OUTPUT INSERTED.Id values(@departmentId, @name, @description, @active)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("BSN", patient.Active),
                    new KeyValuePair<string, object>("BSN", patient.Birth),
                    new KeyValuePair<string, object>("BSN", patient.BSN),
                    new KeyValuePair<string, object>("BSN", patient.ContactPersonName),
                    new KeyValuePair<string, object>("BSN", patient.ContactPersonPhone),
                    new KeyValuePair<string, object>("BSN", patient.Email),
                    new KeyValuePair<string, object>("BSN", patient.Gender),
                    new KeyValuePair<string, object>("BSN", patient.HouseNumber),
                    new KeyValuePair<string, object>("BSN", patient.Name),
                    new KeyValuePair<string, object>("BSN", patient.NormalizedUserName),
                    new KeyValuePair<string, object>("BSN", patient.PhoneNumber),
                    new KeyValuePair<string, object>("BSN", patient.PrivAdress),
                    new KeyValuePair<string, object>("BSN", patient.PrivBirthDate),
                    new KeyValuePair<string, object>("BSN", patient.PrivContactPersonName),
                    new KeyValuePair<string, object>("BSN", patient.PrivContactPersonPhone),
                    new KeyValuePair<string, object>("BSN", patient.PrivGender),
                    new KeyValuePair<string, object>("BSN", patient.PrivMail),
                    new KeyValuePair<string, object>("BSN", patient.PrivPhoneNumber),
                    new KeyValuePair<string, object>("BSN", patient.Zipcode)
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
                string query = "update PTS2_Patient set @fields where Id = @id";

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
                string query = "update PTS2_Patient set Active = 0 where Id = @id";

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

        //TODO : USE DOCTORID!!!
        public List<Patient> GetByDoctor(long id)
        {
            // Create result
            List<Patient> result = new List<Patient>();
            // Set query
            string query = "select * from PTS2_Patient where active = 1";

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
    }
}
