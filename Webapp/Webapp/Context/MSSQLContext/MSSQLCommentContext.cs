using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class MSSQLCommentContext : BaseMSSQLContext, ICommentContext
    {
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
            string query = $"select * from PTS2_Comment where TreatmentId = {treatmentId}";

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

        public long Insert(Comment comment)
        {
            try
            {
                string query = "insert into PTS2_Comment(Title, Description, TreatmentId) OUTPUT INSERTED.Id values(@title, @description, @treatmentid)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                      new KeyValuePair<string, object>("title", comment.Title),
                      new KeyValuePair<string, object>("description", comment.Description),
                      new KeyValuePair<string, object>("treatmentid", comment.TreatmentId),
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
