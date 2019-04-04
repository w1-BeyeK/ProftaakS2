using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;

namespace Webapp.Repository
{
    public abstract class BaseRepository
    {
        protected readonly IContext context;

        protected BaseRepository(IContext context)
        {
            this.context = context;
        }
    }
}
