using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;

namespace Webapp.Context
{
    public abstract class BaseMSSQLContext
    {
        /// <summary>
        /// Datarow to object X parser
        /// </summary>
        protected readonly IParser parser;

        /// <summary>
        /// Handler that executes your command or select query
        /// </summary>
        protected readonly IHandler handler;

        /// <summary>
        /// Constructor with default parameters
        /// </summary>
        /// <param name="parser">Object parser</param>
        /// <param name="handler">Query handler</param>
        protected BaseMSSQLContext(IParser parser, IHandler handler)
        {
            this.parser = parser;
            this.handler = handler;
        }
    }
}
