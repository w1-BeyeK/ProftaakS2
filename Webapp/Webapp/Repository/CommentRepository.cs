using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class CommentRepository : BaseRepository
    {
        public CommentRepository(IContext context) : base(context)
        {
        }

        /// <summary>
        /// Doctor adds a comment
        /// </summary>
        public bool AddComment(Comment comment, long treatmentId)
        {
            return Context.AddComment(comment, treatmentId);
        }

        /// <summary>
        /// Get all comments of a treatment
        /// </summary>
        public List<Comment> GetAllCommentsByTreatmentId(long treatmentId)
        {
            return Context.GetAllCommentsByTreatmentId(treatmentId);
        }
    }
}
