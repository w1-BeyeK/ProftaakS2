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
        /// Gets all coments from a treatment
        /// </summary>
        /// <param name="treatmentId"> TreatmentId </param>
        /// <returns> List of comments </returns>
        public List<Comment> GetByTreatment(long treatmentId)
        {
            // Create result
            List<Comment> result = new List<Comment>();
            // Set query
            string query = $"select * from PTS2_Comment where TreatmentId = @treatmentId";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                      new KeyValuePair<string, object>("treatmentId", treatmentId)
                };

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

            if (dbResult == null)
            {
                return new List<Comment>();
            }

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Comment comment))
                    result.Add(comment);
            }

            

            return result;
        }

        /// <summary>
        /// Inserts a Comment
        /// </summary>
        /// <param name="comment"> Comment </param>
        /// <returns> List of Comments </returns>
        public List<Comment> Insert(Comment comment)
        {
            if(string.IsNullOrWhiteSpace(comment.Title))
            {
                return GetByTreatment(comment.TreatmentId);
            }

            try
            {
                string query = "insert into PTS2_Comment(Title, Description, TreatmentId) values(@title, @description, @treatmentid)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                      new KeyValuePair<string, object>("title", comment.Title),
                      new KeyValuePair<string, object>("description", comment.Description),
                      new KeyValuePair<string, object>("treatmentid", comment.TreatmentId),
                };

                handler.ExecuteCommand(query, parameters);
                return GetByTreatment(comment.TreatmentId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
