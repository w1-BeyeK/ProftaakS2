using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryCommentContext : ICommentContext
    {
        public List<Comment> Insert(Comment comment)
        {
            if (BaseMemoryContext.treatments.Exists(t => t.Id == comment.TreatmentId))
            {
                if (BaseMemoryContext.treatments.Find(t => t.Id == comment.TreatmentId).Comments.Count > 0)
                {
                    BaseMemoryContext.treatments.Find(t => t.Id == comment.TreatmentId).Comments.OrderBy(c => c.Id);
                    comment.Id = BaseMemoryContext.treatments.Find(t => t.Id == comment.TreatmentId).Comments.Last().Id + 1;
                }
                else
                {
                    comment.Id = 1;
                }
                BaseMemoryContext.treatments.Find(t => t.Id == comment.TreatmentId).Comments.Add(comment);
                return new List<Comment>(BaseMemoryContext.treatments.Find(t => t.Id == comment.TreatmentId).Comments.ToList());
            }
            return null;
        }

        List<Comment> ICommentContext.GetByTreatment(long id)
        {
            return BaseMemoryContext.treatments.Find(t => t.Id == id).Comments;
        }
    }
}
