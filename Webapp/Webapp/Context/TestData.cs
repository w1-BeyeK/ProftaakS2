﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.MemoryContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class TestData
    {
        public TestData()
        {
            MemoryDepartmentContext depC = new MemoryDepartmentContext();
            MemoryDoctorContext docC = new MemoryDoctorContext();
            MemoryInstitutionContext insC = new MemoryInstitutionContext();
            MemoryPatientContext patC = new MemoryPatientContext();
            MemoryTreatmentContext treC = new MemoryTreatmentContext();
            MemoryTreatmentTypeContext typC = new MemoryTreatmentTypeContext();

            insC.institutions.Add(new Institution() { Id = 1, Active = true, Name = "instituut", Country = "Zeeland" });
            insC.institutions.Add(new Institution() { Id = 2, Active = true, Name = "instituutje", Country = "Ruchpen" });
            List<Comment> comments = new List<Comment>
            {
                new Comment("Arm afzagen", "De arm wordt afgezaagd1", new DateTime(2010 / 22 / 22)) { Id = 1 },
                new Comment("Arm afzagen succes", "De arm is afgezaagd2", new DateTime(2011 / 22 / 22)) { Id = 2 },
                new Comment("Arm afzagen succes2", "De arm is afgezaagd3", DateTime.Today) { Id = 3 }
            };

            depC.departments = new List<Department>()
            {
                new Department()
                {
                    Id = 1,
                    Name = "Soepderpoep",
                    Description = "Hier wordt soep gemaakt",
                    InstitutionId = 1,
                    Active = true,
                },
                new Department()
                {
                    Id = 2,
                    Name = "Toedoe",
                    Description = "Hier worden dingen nog gedaan",
                    InstitutionId = 2,
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

            treC.treatments = new List<Treatment>()
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
                },
                new Treatment()
                {
                    Name = "Euthanasie",
                    Id = 4,
                    BeginDate = new DateTime(2019, 04, 01, 11, 32, 21),
                    EndDate = DateTime.Now,
                    Comments = comments,
                    TreatmentType = new TreatmentType("Illegale prik", "Vol zwart verf gevuld"),
                    Doctor = new Doctor(15, "jan", "jan@hotmail.com", "Jan"),
                    Patient = new Patient(12, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye"),
                }
            };
            patC.patients = new List<Patient>()
            {
                new Patient(11, "kevinbeye", "kevin.beye1999@hotmail.com", "Kevin Beye")
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
                    Treatments = treC.treatments,
                    PrivAdress = false,
                    PrivBirthDate = true,
                    PrivContactPersonName = true,
                    PrivContactPersonPhone = false,
                    PrivGender = true,
                    PrivMail = true,
                    PrivPhoneNumber = false
                },
                new Patient(12, "pieterjan", "pieter@jan.nl", "Pieter Jan")
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
                    Treatments = treC.treatments,
                    PrivAdress = true,
                    PrivBirthDate = true,
                    PrivContactPersonName = true,
                    PrivContactPersonPhone = true,
                    PrivGender = true,
                    PrivMail = true,
                    PrivPhoneNumber = false
                },
                new Patient(13, "Catuja", "cat@cykablyat.ru", "Catuja Noboobs")
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
                    Treatments = treC.treatments,
                    PrivAdress = false,
                    PrivBirthDate = false,
                    PrivContactPersonName = true,
                    PrivContactPersonPhone = false,
                    PrivGender = false,
                    PrivMail = true,
                    PrivPhoneNumber = false
                },
                new Patient(14, "michaelv", "michael@catujaspanker.com", "Michaeltje")
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
                    Treatments = treC.treatments,
                    PrivAdress = true,
                    PrivBirthDate = false,
                    PrivContactPersonName = true,
                    PrivContactPersonPhone = true,
                    PrivGender = false,
                    PrivMail = false,
                    PrivPhoneNumber = true
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
                    Treatments = treC.treatments,
                    PrivAdress = false,
                    PrivBirthDate = false,
                    PrivContactPersonName = true,
                    PrivContactPersonPhone = true,
                    PrivGender = false,
                    PrivMail = false,
                    PrivPhoneNumber = false
                }
            };
            docC.doctors = new List<Doctor>()
            {
                new Doctor(11, "kevin<3Catuja", "kevin.beye1999@hotmail.com", "Kevin")
                {
                    Active = true,
                    Birth = DateTime.Now,
                    EmployeeNumber = 11,
                    Function = "HOI",
                    Gender = Gender.Other,
                    Password = "Test123",
                    PhoneNumber = "12345",
                    PrivMail = true,
                    PrivPhoneNumber = false
                },
                new Doctor(12, "Soepeeeee", "sssssss@hotmail.com", "Soep")
                {
                    Active = true,
                    Birth = DateTime.Now,
                    EmployeeNumber = 11,
                    Function = "HOI",
                    Gender = Gender.Male,
                    Password = "Test123",
                    PhoneNumber = "12345",
                    PrivMail = true,
                    PrivPhoneNumber = true
                },
                new Doctor(13, "Hakker", "Hakmoes@hotmail.com", "Hakkie")
                {
                    Active = true,
                    Birth = DateTime.Now,
                    EmployeeNumber = 11,
                    Function = "HOI",
                    Gender = Gender.Female,
                    Password = "Test123",
                    PhoneNumber = "12345",
                    PrivMail = false,
                    PrivPhoneNumber = false
                },
            };
            typC.treatmentTypes = new List<TreatmentType>()
            {
                new TreatmentType() { Id = 9, Name = "kaas", Description = "schimmel groeien", Active = true},
            //    new TreatmentType("Armzagen","Hopsakee arm eraf."),
            //    new TreatmentType("RibRemoven","Zin in een spare ribje?"),
            //    new TreatmentType("VingerVangen","Beter 10 vingers in je hand dan 500 op de grond."),
        };
        }
    }
}
