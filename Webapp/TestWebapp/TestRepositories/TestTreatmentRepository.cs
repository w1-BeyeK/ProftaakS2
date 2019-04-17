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
    
    public class TestTreatmentRepository
    {
        ITreatmentContext context = new MemoryTreatmentContext();
        TreatmentRepository treatmentRepository;

        [Fact]
        public void TreatmentRepositoryConstructor()
        {
            treatmentRepository = new TreatmentRepository(context);

            Assert.NotNull(treatmentRepository);
        }

        [Fact]
        public void Add()
        {
            Treatment treatment = new Treatment(1, "een", DateTime.Today, DateTime.Today);
            treatmentRepository = new TreatmentRepository(context);
            Assert.Equal(1, treatmentRepository.Add(treatment, 1, 1, 1));
        }

        [Fact]
        public void Update()
        {
            Treatment treatment = new Treatment(1, "een", DateTime.Today, DateTime.Today);
            treatmentRepository = new TreatmentRepository(context);
            Assert.True(treatmentRepository.Update(treatment));
        }

        [Fact]
        public void GetByDoctor()
        {
            treatmentRepository = new TreatmentRepository(context);
            Assert.Equal(2, treatmentRepository.GetByDoctor(1).Count);
        }

        [Fact]
        public void GetByPatient()
        {
            treatmentRepository = new TreatmentRepository(context);
            Assert.Equal(2, treatmentRepository.GetByPatient(1).Count);
        }

        [Fact]
        public void GetById()
        {
            treatmentRepository = new TreatmentRepository(context);
            Assert.Equal("treatment", treatmentRepository.GetById(1).Name);
        }
    }
}