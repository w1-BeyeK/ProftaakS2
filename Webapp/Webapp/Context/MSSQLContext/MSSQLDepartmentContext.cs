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
            throw new NotImplementedException();
        }

        public long Insert(Department obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Department obj)
        {
            throw new NotImplementedException();
        }
    }
}
