using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class CommentTestContext : BaseTestContext, ICommentContext
    {
        public bool Insert(Comment comment, long treatmentId)
        {
            if (treatments.Exists(t => t.Id == treatmentId))
            {
                treatments.Find(t => t.Id == treatmentId).Comments.Add(comment);
                return true;
            }
            return false;
        }

        public List<Comment> GetAllCommentsByTreatmentId(long id)
        {
            return treatments.Find(t => t.Id == id).Comments;
        }
    }
}
