using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface ITreatmentContext : IUniversalContext<Treatment>
    { 
        List<Treatment> GetByDoctor(long id);
        List<Treatment> GetByPatient(long id);
    }
}
