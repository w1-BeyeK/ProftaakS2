using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.InterfaceContext
{
    public interface ICommentContext
    {
        long Insert(Comment comment);
        List<Comment> GetByTreatment(long treatmentId);
    }
}
