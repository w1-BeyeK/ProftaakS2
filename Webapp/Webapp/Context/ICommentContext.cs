using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface ICommentContext
    {
        bool Insert(Comment comment, long treatmentId);
        List<Comment> GetByTreatmentId(long treatmentId);
    }
}
