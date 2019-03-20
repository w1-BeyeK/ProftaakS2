﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public Role(int id, string name, DateTime createdDate)
        {
            Id = id;
            Name = name;
            CreatedDate = createdDate;
        }
    }
}