using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class PatientDetailViewModel
    {
        public long Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public long BSN { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }
        public int HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public bool PrivContactPersonName { get; set; }
        public bool PrivContactPersonPhone { get; set; }
        public bool PrivMail { get; set; }
        public bool PrivPhoneNumber { get; set; }
        public bool PrivAdress { get; set; }
        public bool PrivGender { get; set; }
        public bool PrivBirthDate { get; set; }
        public int Age { get; set; }
        public List<TreatmentDetailViewModel> TreatmentDetailViewModels { get; set; }
    }
}
