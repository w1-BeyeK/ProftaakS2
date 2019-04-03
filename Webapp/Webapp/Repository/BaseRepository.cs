using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;

namespace Webapp.Repository
{
    public abstract class BaseRepository
    {
        public IContext Context { get; private set; }

        protected BaseRepository(IContext context)
        {
            Context = context;
        }
    }
}
