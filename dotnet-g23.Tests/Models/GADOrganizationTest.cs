using dotnet_g23.Models.Domain;
using System;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class GADOrganizationTest
    {
        [Fact]
        public void GADOrganizationConstructorShoudCreateNewOrganization()
        {
            string _name = "Organization";
            string _location = "Gent";
            OrganizationRole role = new Organization();
            GADOrganization organization = new GADOrganization(_name, _location, role);
            Assert.Equal(_location, organization.Location);
            Assert.Equal(_name, organization.Name);
            Assert.Equal(role, organization.OrganizationRole);
        }

        [Fact]
        public void GADOrganizationConstructorShoudCreateNewGBOrganization()
        {
            string _name = "GBOrganization";
            string _location = "Gent";
            OrganizationRole role = new GBOrganization();
            GADOrganization organization = new GADOrganization(_name, _location, role);
            Assert.Equal(_location, organization.Location);
            Assert.Equal(_name, organization.Name);
            Assert.Equal(role, organization.OrganizationRole);
        }


    }
}
