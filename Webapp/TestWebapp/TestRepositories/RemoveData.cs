using System;
using System.Collections.Generic;
using System.Text;
using Webapp.Context.MemoryContext;
using Webapp.Models.Data;

namespace TestWebapp.TestRepositories
{
    public class RemoveData
    {
        public void EmptyLists()
        {
            BaseMemoryContext.departments = new List<Department>();
            BaseMemoryContext.doctors = new List<Doctor>();
            BaseMemoryContext.institutions = new List<Institution>();
            BaseMemoryContext.patients = new List<Patient>();
            BaseMemoryContext.treatments = new List<Treatment>();
            BaseMemoryContext.treatmentTypes = new List<TreatmentType>();

            TestData testData = new TestData();
        }
    }
}
