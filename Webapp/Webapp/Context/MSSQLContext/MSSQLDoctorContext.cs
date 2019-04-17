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
    public class MSSQLDoctorContext : BaseMSSQLContext, IDoctorContext
    {
        //TODO : Change Queries!!!
        public MSSQLDoctorContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        public Doctor GetById(long id)
        {
            string query = $"select * from PTS2_Doctor where Id = {id}";

            var dbResult = handler.ExecuteSelect(query, id);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out Doctor doctor))
                return doctor;
            else
                return default(Doctor);
        }

        /// <summary>
        /// Get all doctors
        /// </summary>
        /// <returns>List of doctors</returns>
        public List<Doctor> GetAll()
        {
            // Create result
            List<Doctor> result = new List<Doctor>();
            // Set query
            string query = "select * from PTS2_Doctor where active = 1";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Doctor doctor))
                    result.Add(doctor);
            }

            return result;
        }

        public long Insert(Doctor doctor)
        {
            try
            {
                string query = "insert into PTS2_Doctor(DepartmentId, Name, Description, Active) OUTPUT INSERTED.Id values(@departmentId, @name, @description, @active)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    //new KeyValuePair<string, object>("name", doctor.Name),
                    //new KeyValuePair<string, object>("departmentId", doctor.DepartmentId),
                    //new KeyValuePair<string, object>("description", doctor.Description),
                    //new KeyValuePair<string, object>("active", "1"),
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Doctor doctor)
        {
            try
            {
                string query = "update PTS2_Doctor set @fields where Id = @id";

                string fields = "";
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", doctor.Id)
                };

                if (doctor.Name != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[name] = @name";
                    parameters.Add(new KeyValuePair<string, object>("name", doctor.Name));
                }
                if (!string.IsNullOrWhiteSpace(fields))
                    fields += ",";
                fields += "active = @active";
                parameters.Add(new KeyValuePair<string, object>("active", doctor.Active ? "1" : "0"));

                query = query.Replace("@fields", fields);

                handler.ExecuteCommand(query, parameters);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Delete(Doctor doctor)
        {
            try
            {
                string query = "update PTS2_Doctor set Active = 0 where Id = @id";

                handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", doctor.Id)
                });
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<Doctor> GetByDepartment(long id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetByInstitution(long id)
        {
            throw new NotImplementedException();
        }

        public bool AddToDepartment(long departmentId, long doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
