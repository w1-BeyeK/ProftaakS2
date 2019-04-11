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
    public class MSSQLInstitutionContext : BaseMSSQLContext, IInstitutionContext
    {
        public MSSQLInstitutionContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        public bool Delete(Institution obj)
        {
            throw new NotImplementedException();
        }

        public List<Institution> GetAll()
        {
            // Create result
            List<Institution> result = new List<Institution>();
            // Set query
            string query = "select * from PTS2_Institution order by [name]";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Institution institution))
                    result.Add(institution);
            }

            return result;
        }

        public Institution GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Institution obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Institution obj)
        {
            throw new NotImplementedException();
        }
    }
}
