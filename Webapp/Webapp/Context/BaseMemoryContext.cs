using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public abstract class BaseMemoryContext
    {
        protected List<Patient> patients = new List<Patient>();
        protected List<Treatment> treatments = new List<Treatment>();
        protected List<Doctor> doctors = new List<Doctor>();
        protected List<Department> departments = new List<Department>();
        protected List<Institution> institutions = new List<Institution>();
        protected List<TreatmentType> treatmentTypes = new List<TreatmentType>();

        //protected static TestContext instance = null;

        //public static TestContext GetInstance()
        //{
        //    if (instance == null)
        //    {
        //        instance = new TestContext();
        //    }
        //    return instance;
        //}

        public BaseMemoryContext()
        {
            List<Comment> comments = new List<Comment>
            {
                new Comment("Arm afzagen", "De arm wordt afgezaagd1", new DateTime(2010 / 22 / 22)),
                new Comment("Arm afzagen succes", "De arm is afgezaagd2", new DateTime(2011 / 22 / 22)),
                new Comment("Arm afzagen succes2", "De arm is afgezaagd3", DateTime.Today)
            };

            departments = new List<Department>()
            {
                new Department()
                {
                    Id = 1,
                    Name = "Soepderpoep",
                    Description = "Hier wordt soep gemaakt",
                    Active = true,
                },
                new Department()
                {
                    Id = 2,
                    Name = "Toedoe",
                    Description = "Hier worden dingen nog gedaan",
                    Active = true,
                },
                new Department()
                {
                    Id = 3,
                    Name = "Slaapbank",
                    Description = "Hier slaapt de slapende slaper",
                    Active = true,
                },
            };

            treatments = new List<Treatment>()
            {
                new Treatment()
                {
                    Name = "Zowarmarollen",
                    Id = 1,
                    BeginDate = new DateTime(2019, 04, 01, 11, 32, 21),
                    EndDate = DateTime.Now,
                    Comments = comments,
                    TreatmentType = new TreatmentType("Arm afzagen", "Arm gaat eraf"),
                    Doctor = new Doctor(11, "jan", "jan@hotmail.com", "Jan"),
                    Patient = new Patient(12, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye"),
                },
                new Treatment()
                {
                    Name = "Swiepen",
                    Id = 2,
                    BeginDate = new DateTime(2019, 04, 01, 11, 32, 21),
                    EndDate = DateTime.Now,
                    Comments = comments,
                    TreatmentType = new TreatmentType("SmeerSmaren", "Arm gaat erin"),
                    Doctor = new Doctor(11, "jan", "jan@hotmail.com", "Jan"),
                    Patient = new Patient(12, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye"),
                },
                new Treatment()
                {
                    Name = "HersenReset",
                    Id = 3,
                    BeginDate = new DateTime(2019, 04, 01, 11, 32, 21),
                    EndDate = DateTime.Now,
                    Comments = comments,
                    TreatmentType = new TreatmentType("Formateren", "Die Dikke reboot"),
                    Doctor = new Doctor(11, "jan", "jan@hotmail.com", "Jan"),
                    Patient = new Patient(12, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye"),
                }
            };
            patients = new List<Patient>()
            {
                new Patient(12, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Male,
                    Password = "Test123",
                    Active = true,
                    Birth = new DateTime(2000, 12, 3),
                    PhoneNumber = "0611061788",
                    BSN = 233619355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = treatments
                },
                new Patient(77, "pieterjan", "pieter@jan.nl", "Pieter Jan")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Other,
                    Password = "Test123",
                    Active = true,
                    Birth = new DateTime(2000, 12, 3),
                    PhoneNumber = "0611061788",
                    BSN = 233619355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = treatments
                },
                new Patient(69, "Catuja", "cat@cykablyat.ru", "Catuja Noboobs")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Female,
                    Password = "Test123",
                    Active = true,
                    Birth = new DateTime(1998, 10, 4),
                    PhoneNumber = "0611061788",
                    BSN = 222439355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = treatments
                },
                new Patient(25, "michaelv", "michael@catujaspanker.com", "Michaeltje")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Male,
                    Password = "Test123",
                    Active = true,
                    Birth = new DateTime(1871, 2, 7),
                    PhoneNumber = "0611061788",
                    BSN = 233619355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = treatments
                },
                new Patient(15, "stijn", "wizz@hotmail.com", "Stijn Driedubbels")
                {
                    Email = "k.beye@student.fontys.nl",
                    Gender = Gender.Male,
                    Password = "Test123",
                    Active = true,
                    Birth = new DateTime(2017, 12, 3),
                    PhoneNumber = "0611061788",
                    BSN = 233619355,
                    ContactPersonName = "Thomas",
                    ContactPersonPhone = "0612345678",
                    HouseNumber = 2,
                    Zipcode = "5258HS",
                    Treatments = treatments
                }
            };
            doctors = new List<Doctor>()
            {
                new Doctor(11, "kevin<3Catuja", "kevin.beye1999@hotmail.com", "Kevin")
                {
                    Active = true,
                    Birth = DateTime.Now,
                    EmployeeNumber = 11,
                    Function = "HOI",
                    Gender = Gender.Other,
                    Password = "Test123",
                    PhoneNumber = "12345"
                },
                new Doctor(12, "Soepeeeee", "sssssss@hotmail.com", "Soep")
                {
                    Active = true,
                    Birth = DateTime.Now,
                    EmployeeNumber = 11,
                    Function = "HOI",
                    Gender = Gender.Male,
                    Password = "Test123",
                    PhoneNumber = "12345"
                },
                new Doctor(13, "Hakker", "Hakmoes@hotmail.com", "Hakkie")
                {
                    Active = true,
                    Birth = DateTime.Now,
                    EmployeeNumber = 11,
                    Function = "HOI",
                    Gender = Gender.Female,
                    Password = "Test123",
                    PhoneNumber = "12345"
                },
            };
            treatmentTypes = new List<TreatmentType>()
            {
                new TreatmentType("Armzagen","Hopsakee arm eraf."),
                new TreatmentType("RibRemoven","Zin in een spare ribje?"),
                new TreatmentType("VingerVangen","Beter 10 vingers in je hand dan 500 op de grond."),
            };
        }
    }
}
