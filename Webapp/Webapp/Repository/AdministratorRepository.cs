﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class AdministratorRepository : BaseRepository
    {
        public AdministratorRepository(IContext context) : base(context)
        {
        }
    }
}
