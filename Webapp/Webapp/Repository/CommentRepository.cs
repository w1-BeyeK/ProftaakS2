using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context;
using Webapp.Context.InterfaceContext;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class CommentRepository
    {
        //global instances
        protected readonly ICommentContext context;

        public CommentRepository(ICommentContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Doctor adds a comment
        /// </summary>
        public long Add(Comment comment)
        {
            return context.Insert(comment);
        }

        /// <summary>
        /// Get all comments of a treatment
        /// </summary>
        public List<Comment> GetByTreatment(long treatmentId)
        {
            return context.GetByTreatment(treatmentId);
        }
    }
}
