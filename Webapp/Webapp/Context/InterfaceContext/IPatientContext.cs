﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.InterfaceContext
{
    public interface IPatientContext : IUniversalGenerics<Patient>
    {
        List<Patient> GetByDoctor(long id);
        long GetPatientIdByTreatmentId(long id);
    }
}
