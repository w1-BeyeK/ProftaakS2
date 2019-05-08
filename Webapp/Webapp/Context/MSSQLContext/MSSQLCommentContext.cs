﻿using System;
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
        public List<Comment> GetByTreatment(long treatmentId)
        {
            // Create result
            List<Comment> result = new List<Comment>();
            // Set query
            string query = $"select * from PTS2_Comment where TreatmentId = @treatmentId";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                      new KeyValuePair<string, object>("treatmentId", treatmentId.ToString())
                };

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteCommand(query, parameters) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Comment comment))
                    result.Add(comment);
            }

            return result;
        }

        public List<Comment> Insert(Comment comment)
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
