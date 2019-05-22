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
    public class MSSQLDepartmentContext : BaseMSSQLContext, IDepartmentContext
    {
        public MSSQLDepartmentContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        public bool Delete(Department obj)
        {
            try
            {
                string query = "update PTS2_Department set Active = @active where Id = @id";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", obj.Id),
                    new KeyValuePair<string, object>("active", obj.Active? "1" : "0")
                };

                handler.ExecuteCommand(query, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Department> GetAll()
        {
            // Create result
            List<Department> result = new List<Department>();

            // Set query
            string query = "select * from PTS2_Department where active = @active order by [name]";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                 new KeyValuePair<string, object>("active", true? "1" : "0")
            };

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Department department))
                    result.Add(department);
            }

            return result;
        }

        public Department GetById(long id)
        {
            string query = $"select * from PTS2_Department where active = @active and Id = @id";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                 new KeyValuePair<string, object>("id", id),
                 new KeyValuePair<string, object>("active", true? "1" : "0")
            };

            var dbResult = handler.ExecuteSelect(query, parameters);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out Department department))
                return department;
            else
                return default(Department);
        }

        public List<Department> GetForDoctor(long doctorId)
        {
            List<Department> result = new List<Department>();

            string query = $"select * from PTS2_Department where Id in (select dd.DepartmentId FROM PTS2_Department_Doctor dd where dd.DoctorId = @doctorId)";
            
            var dbResult = handler.ExecuteSelect(query, doctorId) as DataTable;
            
            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Department department))
                    result.Add(department);
            }

            return result;
        }

        public long Insert(Department obj)
        {
            try
            {
                string query = "insert into PTS2_Department(Name, Active, Description, InstitutionId) OUTPUT INSERTED.Id values(@name, @active, @description, @institutionid)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("name", obj.Name),
                    new KeyValuePair<string, object>("active", true),
                    new KeyValuePair<string, object>("description", obj.Description),
                    new KeyValuePair<string, object>("institutionid", obj.InstitutionId),
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Department obj)
        {
            try
            {
                string query = "update PTS2_Department set @fields where Id = @id";

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
                if (obj.Description != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "description = @description";
                    parameters.Add(new KeyValuePair<string, object>("description", obj.Description));
                }

                if(obj.InstitutionId > 0)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "institutionId = @institutionId";
                    parameters.Add(new KeyValuePair<string, object>("institutionId", obj.InstitutionId));
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
