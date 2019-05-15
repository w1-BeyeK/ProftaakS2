using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.MemoryContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class TestData
    {
        public TestData()
        {
            BaseMemoryContext.institutions.Add(new Institution() { Id = 1, Active = true, Name = "instituut", Country = "Zeeland" });
            BaseMemoryContext.institutions.Add(new Institution() { Id = 2, Active = true, Name = "instituutje", Country = "Ruchpen" });
            List<Comment> comments = new List<Comment>
            {
                new Comment("Arm amputeren 1", "De arm wordt geamputeerd 1", new DateTime(2010 / 22 / 22)) { Id = 1 },
                new Comment("Arm amputeren 2", "De arm is geamputeerd 2", new DateTime(2011 / 22 / 22)) { Id = 2 },
                new Comment("Arm amputeren 3", "De arm is geamputeerd 3", DateTime.Today) { Id = 3 }
            };

            BaseMemoryContext.treatmentTypes = new List<TreatmentType>()
            {
                new TreatmentType() { Id = 9, Name = "kaas", Description = "schimmel groeien", Active = true},
                new TreatmentType() { Id = 8, Name = "Arm amputeren", Description = "Arm gaat eraf", Active = true },
        };

            BaseMemoryContext.departments = new List<Department>()
            {
                new Department()
                {
                    Id = 1,
                    Name = "afdeling 1",
                    Description = "Hier wordt iets gemaakt",
                    InstitutionId = 1,
                    Active = true,
                },
                new Department()
                {
                    Id = 2,
                    Name = "afdeling 2",
                    Description = "Hier worden dingen nog gedaan",
                    InstitutionId = 2,
                    Active = true,
                },
                new Department()
                {
                    Id = 3,
                    Name = "afdeling 3",
                    Description = "Hier een andere afdeling",
                    Active = true,
                },
            };

            BaseMemoryContext.treatments = new List<Treatment>()
            {
                new Treatment()
                {
                    Name = "Arm amputeren",
                    Id = 1,
                    BeginDate = new DateTime(2019, 04, 01, 11, 32, 21),
                    EndDate = DateTime.Now,
                    Comments = comments,
                    Doctor = new Doctor(11, "jan", "jan@hotmail.com", "Jan"),
                    Patient = new Patient(1, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye"),
                    DoctorId = 11,
                    PatientId = 1,
                },
                new Treatment()
                {
                    Name = "Swiepen",
                    Id = 2,
                    BeginDate = new DateTime(2019, 04, 01, 11, 32, 21),
                    EndDate = DateTime.Now,
                    Comments = comments,
                    TreatmentType = BaseMemoryContext.treatmentTypes.Find(t => t.Id == 9),
                    Doctor = new Doctor(11, "jan", "jan@hotmail.com", "Jan"),
                    Patient = new Patient(1, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye"),
                    DoctorId = 11,
                    PatientId = 1,
                },
                new Treatment()
                {
                    Name = "Hersenoperatie",
                    Id = 3,
                    BeginDate = new DateTime(2019, 04, 01, 11, 32, 21),
                    EndDate = DateTime.Now,
                    Comments = comments,
                    TreatmentType = BaseMemoryContext.treatmentTypes.Find(t => t.Id == 8),
                    Doctor = new Doctor(11, "jan", "jan@hotmail.com", "Jan"),
                    Patient = new Patient(12, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye"),
                    DoctorId = 11,
                    PatientId = 12,
                },
                new Treatment()
                {
                    Name = "Euthanasie",
                    Id = 4,
                    BeginDate = new DateTime(2019, 04, 01, 11, 32, 21),
                    EndDate = DateTime.Now,
                    Comments = comments,
                    TreatmentType = BaseMemoryContext.treatmentTypes.Find(t => t.Id == 8),
                    Doctor = new Doctor(15, "jan", "jan@hotmail.com", "Jan"),
                    Patient = new Patient(12, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye"),
                    DoctorId = 15,
                    PatientId = 12,
                }
            };
            BaseMemoryContext.patients = new List<Patient>()
            {
                new Patient(1, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Male,
                    Password = "Test123",
                    PatientId = 1,
                    Active = true,
                    Birth = new DateTime(2000, 12, 3),
                    Phone = "0611061788",
                    BSN = 233619355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = BaseMemoryContext.treatments,
                    PrivAdress = false,
                    PrivBirthDate = true,
                    PrivContactPersonName = true,
                    PrivContactPersonPhone = false,
                    PrivGender = true,
                    PrivMail = true,
                    PrivPhone = false
                },
                new Patient(12, "pieterjan", "pieter@jan.nl", "Pieter Jan")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Other,
                    Password = "Test123",
                    Active = true,
                    Birth = new DateTime(2000, 12, 3),
                    Phone = "0611061788",
                    BSN = 233619355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = BaseMemoryContext.treatments,
                    PrivAdress = true,
                    PrivBirthDate = true,
                    PrivContactPersonName = true,
                    PrivContactPersonPhone = true,
                    PrivGender = true,
                    PrivMail = true,
                    PrivPhone = false
                },
                new Patient(13, "Yasmina", "yas@goolge.com", "Yasmina Ashmila")
                {
                    Email = "y.ashmila@student.fontys.nl",
                    Gender = Gender.Female,
                    Password = "Test123",
                    Active = true,
                    Birth = new DateTime(1998, 10, 4),
                    Phone = "0611061788",
                    BSN = 222439355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = BaseMemoryContext.treatments,
                    PrivAdress = false,
                    PrivBirthDate = false,
                    PrivContactPersonName = true,
                    PrivContactPersonPhone = false,
                    PrivGender = false,
                    PrivMail = true,
                    PrivPhone = false
                },
                new Patient(14, "michaelv", "michael@google.com", "Michaeltje")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Male,
                    Password = "Test123",
                    Active = true,
                    Birth = new DateTime(1871, 2, 7),
                    Phone = "0611061788",
                    BSN = 233619355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = BaseMemoryContext.treatments,
                    PrivAdress = true,
                    PrivBirthDate = false,
                    PrivContactPersonName = true,
                    PrivContactPersonPhone = true,
                    PrivGender = false,
                    PrivMail = false,
                    PrivPhone = true
                },
                new Patient(15, "stijn", "wizz@hotmail.com", "Stijn Driedubbels")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Male,
                    Password = "Test123",
                    Active = true,
                    Birth = new DateTime(2017, 12, 3),
                    Phone = "0611061788",
                    BSN = 233619355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = BaseMemoryContext.treatments,
                    PrivAdress = false,
                    PrivBirthDate = false,
                    PrivContactPersonName = true,
                    PrivContactPersonPhone = true,
                    PrivGender = false,
                    PrivMail = false,
                    PrivPhone = false
                }
            };
            BaseMemoryContext.doctors = new List<Doctor>()
            {
                new Doctor(11, "kevin", "kevin.Wouw@hotmail.com", "Kevin")
                {
                    Active = true,
                    Birth = DateTime.Now,
                    EmployeeNumber = 11,
                    Function = "HOI",
                    Gender = Gender.Other,
                    Password = "Test123",
                    Phone = "12345",
                    PrivMail = true,
                    PrivPhone = false
                },
                new Doctor(12, "Soof", "sofie@hotmail.com", "Sofie")
                {
                    Active = true,
                    Birth = DateTime.Now,
                    EmployeeNumber = 11,
                    Function = "HOI",
                    Gender = Gender.Male,
                    Password = "Test123",
                    Phone = "12345",
                    PrivMail = true,
                    PrivPhone = true
                },
                new Doctor(13, "Hansja", "hans@hotmail.com", "Hans")
                {
                    Active = true,
                    Birth = DateTime.Now,
                    EmployeeNumber = 11,
                    Function = "HOI",
                    Gender = Gender.Female,
                    Password = "Test123",
                    Phone = "12345",
                    PrivMail = false,
                    PrivPhone = false
                },
            };
        }
    }
}
