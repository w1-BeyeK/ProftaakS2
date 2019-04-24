using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public static class BaseMemoryContext
    {
        public static List<Department> departments = new List<Department>();
        public static List<Doctor> doctors = new List<Doctor>();
        public static List<Institution> institutions = new List<Institution>();
        public static List<Patient> patients = new List<Patient>();
        public static List<Treatment> treatments = new List<Treatment>();
        public static List<TreatmentType> treatmentTypes = new List<TreatmentType>();
    }
}
