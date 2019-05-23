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
    public class MSSQLAccountContext : BaseMSSQLContext, IAccountContext
    {
        public MSSQLAccountContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        /// <summary>
        /// Deactivates the designated user account
        /// </summary>
        /// <param name="obj"> UserAccount </param>
        /// <returns> Bool </returns>
        public bool Delete(long id, bool active)
        {
            try
            {
                string query = "update PTS2_Account set Active = @active where Id = @id";

                handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", id),
                    new KeyValuePair<string, object>("active", active? "1" : "0")
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns> List of UserAccounts </returns>
        public List<UserAccount> GetAll()
        {
            // Create result
            List<UserAccount> result = new List<UserAccount>();
            // Set query
            string query = "select * from PTS2_Account order by [name]";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out UserAccount UserAccount))
                    result.Add(UserAccount);
            }

            return result;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns> List of Patients </returns>
        public List<UserAccount> GetAllPatients()
        {
            // Create result
            List<UserAccount> result = new List<UserAccount>();
            // Set query
            string query = "select * from PTS2_Account where patientId is not null and doctorId is null order by [name]";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out UserAccount UserAccount))
                    result.Add(UserAccount);
            }

            return result;
        }

        /// <summary>
        /// Get all doctors
        /// </summary>
        /// <returns> List of Doctors </returns>
        public List<UserAccount> GetAllDoctors()
        {
            // Create result
            List<UserAccount> result = new List<UserAccount>();
            // Set query
            string query = "select * from PTS2_Account where patientId is null and doctorId is not null order by [name]";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out UserAccount UserAccount))
                    result.Add(UserAccount);
            }

            return result;
        }

        /// <summary>
        /// Get a UserAccount by Id
        /// </summary>
        /// <param name="id"> UserAccountId</param>
        /// <returns> UserAccount </returns>
        public UserAccount GetById(long id)
        {
            string query = $"select * from PTS2_Account where Id = @id";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", id.ToString())
                };

            var dbResult = handler.ExecuteCommand(query, parameters);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out UserAccount UserAccount))
                return UserAccount;
            else
                return default(UserAccount);
        }

        /// <summary>
        /// Insert a UserAccount and returns its Id
        /// </summary>
        /// <param name="obj"> UserAccount </param>
        /// <returns> Id of inserted account </returns>
        public long Insert(UserAccount obj)
        {
            try
            {
                string query = "insert into PTS2_Account(Username, Name, Password, DoctorId, PatientId) OUTPUT INSERTED.Id values(@username, @name, @password, @doctorId, @patientId)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("username", obj.UserName),
                    new KeyValuePair<string, object>("name", obj.Name),
                    new KeyValuePair<string, object>("password", obj.Password),
                    new KeyValuePair<string, object>("doctorId", obj.DoctorId),
                    new KeyValuePair<string, object>("patientId", obj.PatientId),
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Update a UserAccount
        /// </summary>
        /// <param name="obj"> UserAccount </param>
        /// <returns> Bool </returns>
        public bool Update(UserAccount obj)
        {
            try
            {
                string query = "update PTS2_Account set @fields where Id = @id";

                string fields = "";
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", obj.Id)
                };

                if (obj.Name != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[name] = @name";
                    parameters.Add(new KeyValuePair<string, object>("name", obj.Name));
                }
                if (obj.Password != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "password = @password";
                    parameters.Add(new KeyValuePair<string, object>("password", obj.Password));
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
    }
}
