using System;

namespace dotnet_g23.Models.Domain
{
    public class GADOrganization
    {
        private String _naam;
        private String _locatie;
        private IOrganizationRole _organizationRole;

        public IOrganizationRole OrganizationRole
        {
            get { return _organizationRole; }
            set { _organizationRole = value; }
        }

        public String Naam { get { return _naam; } private set { _naam = value; } }

        public String Locatie { get { return _locatie; } private set { _locatie = value; } }

        public GADOrganization(String naam, String locatie, IOrganizationRole organizationRole)
        {
            Naam = naam;
            Locatie = locatie;
            SetOrganizationRole(organizationRole);
        }

        private void SetOrganizationRole(IOrganizationRole organizationRole)
        {
            OrganizationRole = organizationRole;
        }
    }
}
