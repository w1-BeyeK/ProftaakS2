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
            return context.AddComment(comment, treatmentId);
        }
    }
}
