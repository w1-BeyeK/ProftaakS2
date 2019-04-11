using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class CommentRepository
    {
        protected readonly IContext context;

        public CommentRepository(IContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Doctor adds a comment
        /// </summary>
        public bool AddComment(Comment comment, long treatmentId)
        {
            return context.AddComment(comment, treatmentId);
        }

        /// <summary>
        /// Get all comments of a treatment
        /// </summary>
        public List<Comment> GetAllCommentsByTreatmentId(long treatmentId)
        {
            return context.GetAllCommentsByTreatmentId(treatmentId);
        }
    }
}
