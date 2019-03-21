using System;
using System.Text;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestInstitution
    {
        [Fact]
        public void InstitutionConstructor()
        {
            string name = "Ziekenhuis Gezond";
            int houseNumber = 1;
            string zipcode = "5022 DM";
            string phoneNumber = "0885080000";
            string country = "Nederland";

            Institution institution = new Institution(name, houseNumber, zipcode, phoneNumber, country);

            Assert.Equal(name, institution.Name);
            Assert.Equal(houseNumber, institution.HouseNumber);
            Assert.Equal(zipcode, institution.Zipcode);
            Assert.Equal(phoneNumber, institution.PhoneNumber);
            Assert.Equal(country, institution.Country);
        }
    }
}
