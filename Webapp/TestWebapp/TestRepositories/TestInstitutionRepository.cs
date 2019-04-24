﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Webapp.Repository;
using Webapp.Context;
using Webapp.Models.Data;
using Webapp.Context.InterfaceContext;
using Webapp.Context.MemoryContext;

namespace TestWebapp.TestRepositories
{
    
    public class TestInstitutionRepository : RemoveData
    {
        IInstitutionContext context = new MemoryInstitutionContext();
        InstitutionRepository institutionRepository;

        [Fact]
        public void InstitutionRepositoryConstructor()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);

            Assert.NotNull(institutionRepository);
        }

        [Fact]
        public void AddInstitution()
        {
            EmptyLists();
            Administrator admin = new Administrator();
            Institution institution = new Institution("een", 1, "eend", "696969", "Lichtenstein", admin);
            institutionRepository = new InstitutionRepository(context);
            Assert.Equal(3, institutionRepository.Insert(institution));
        }

        [Fact]
        public void Update()
        {
            EmptyLists();
            Administrator admin = new Administrator();
            Institution institution = new Institution("een", 1, "eend", "696969", "Lichtenstein", admin)
            {
                Id = 1
            };
            institutionRepository = new InstitutionRepository(context);
            Assert.True(institutionRepository.Update(institution));
        }

        [Fact]
        public void GetAll()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Assert.Equal(2, institutionRepository.GetAll().Count);
        }

        [Fact]
        public void AddDepartmentToInstitution()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Assert.True(institutionRepository.AddDepartmentToInstitution(1, 1));
        }

        [Fact]
        public void GetById()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Assert.Equal("instituut", institutionRepository.GetById(1).Name);
        }
    }
}
