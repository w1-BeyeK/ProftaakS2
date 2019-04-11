﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface IPatientContext : IUniversalContext<Patient>
    {
        List<Patient> GetByDoctor(long id);
    }
}
