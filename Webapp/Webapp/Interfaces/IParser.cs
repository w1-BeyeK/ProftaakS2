using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Interfaces
{
    public interface IParser
    {
        object Parse<T>(object raw) where T : Entity;
        bool TryParse<T>(object raw, out T result) where T : Entity;
    }
}
