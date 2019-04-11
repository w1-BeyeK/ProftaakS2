using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class MSSQLCommentContext : BaseMSSQLContext, ICommentContext
    {
        //TODO : Change Queries!!!
        public MSSQLCommentContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <returns>List of comments</returns>
        public List<Comment> GetByTreatmentId(long treatmentId)
        {
            // Create result
            List<Comment> result = new List<Comment>();
            // Set query
            string query = "select * from PTS2_TreatmentType where active = 1";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Comment comment))
                    result.Add(comment);
            }

            return result;
        }

        public bool Insert(Comment comment, long treatmentId)
        {
            try
            {
                string query = "insert into PTS2_TreatmentType(DepartmentId, Name, Description, Active) OUTPUT INSERTED.Id values(@departmentId, @name, @description, @active)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    //new KeyValuePair<string, object>("name", comment.Name),
                    //new KeyValuePair<string, object>("departmentId", comment.DepartmentId),
                    //new KeyValuePair<string, object>("description", comment.Description),
                    //new KeyValuePair<string, object>("active", "1"),
                };

                //TODO : You don't want an id...
                return false;
                long id = (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
