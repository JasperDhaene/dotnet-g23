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
            Organization organization = new Organization(_name, _location, role);
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
            Organization organization = new Organization(_name, _location, role);
            Assert.Equal(_location, organization.Location);
            Assert.Equal(_name, organization.Name);
            Assert.Equal(role, organization.OrganizationRole);
        }

        [Fact]
        public void ConstructorShouldNotCreateNewGADOrganizationBecauseNameIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Organization(null, "Ieper", new GBOrganization()));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewGADOrganizationBecauseNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Organization("", "Ieper", new GBOrganization()));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewGADOrganizationBecauseNameIsSpaces()
        {
            Assert.Throws<ArgumentException>(() => new Organization("            ", "Ieper", new GBOrganization()));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewGADOrganizationBecauseLocationIsSpaces()
        {
            Assert.Throws<ArgumentException>(() => new Organization("Organization", "          ", new GBOrganization()));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewGADOrganizationBecauseLocationIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Organization("Organization", "", new GBOrganization()));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewGADOrganizationBecauseLocationIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Organization(null, null, new GBOrganization()));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewGADOrganizationBecauseBothArgumentsAreSpaces()
        {
            Assert.Throws<ArgumentException>(() => new Organization("           ", "          ", new GBOrganization()));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewGADOrganizationBecauseBothArgumentsAreEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Organization("", "", new GBOrganization()));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewGADOrganizationBecauseBothArgumentsAreNull()
        {
            Assert.Throws<ArgumentException>(() => new Organization(null, null, new GBOrganization()));
        }

        [Fact]
        public void ChangeOrganizationRoleShouldChangeRole()
        {
            Organization g = new Organization("Test", "Gent", new Organization());
            Assert.True(g.OrganizationRole.GetType().Name.Equals("Organization"));
            g.SetOrganizationRole(new GBOrganization());
            Assert.True(g.OrganizationRole.GetType().Name.Equals("GBOrganization"));
        }
    }
}
