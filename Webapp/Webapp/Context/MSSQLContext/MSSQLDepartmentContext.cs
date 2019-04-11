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
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            // Create result
            List<Department> result = new List<Department>();
            // Set query
            string query = "select * from PTS2_Department where active = 1 order by [name]";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

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
            string query = $"select * from PTS2_Department where active = 1 and Id = {id}";

            var dbResult = handler.ExecuteSelect(query, id);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out Department department))
                return department;
            else
                return default(Department);
        }

        public long Insert(Department obj)
        {
            try
            {
                string query = "insert into PTS2_Department(Name, Active, Description, InstitutionId) OUTPUT INSERTED.Id values(@name, @active, @description, @institutionid)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("name", obj.Name),
                    new KeyValuePair<string, object>("active", obj.Active),
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
            throw new NotImplementedException();
        }
    }
}
