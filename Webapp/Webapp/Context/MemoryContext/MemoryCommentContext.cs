using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryCommentContext : BaseMemoryContext, ICommentContext
    {
        public List<Comment> Insert(Comment comment)
        {
            treatments.Find(t => t.Id == comment.TreatmentId).Comments.Add(comment);
            return new List<Comment>(treatments.Find(t => t.Id == comment.TreatmentId).Comments.ToList());
        }

        public List<Comment> GetByTreatment(long id)
        {
            return treatments.Find(t => t.Id == id).Comments;
        }
    }
}
