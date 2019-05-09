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
            this.context = context ?? throw new NullReferenceException("De commentaarContext is leeg.");
        }

        /// <summary>
        /// Doctor adds a comment
        /// </summary>
        public List<Comment> Insert(Comment comment)
        {
            if(comment == null)
            {
                throw new NullReferenceException("Het commentaar is leeg.");
            }
            return context.Insert(comment);
        }

        /// <summary>
        /// Get all comments of a treatment
        /// </summary>
        public List<Comment> GetByTreatment(long treatmentId)
        {
            if(treatmentId < 1)
            {
                throw new NullReferenceException("Het behandelingId is leeg.");
            }
            return context.GetByTreatment(treatmentId);
        }
    }
}
