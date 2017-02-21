using System;

namespace dotnet_g23.Models.Domain
{
    public class GADOrganization
    {
        private String _name;
        private String _location;
        private IOrganizationRole _organizationRole;

        public IOrganizationRole OrganizationRole
        {
            get { return _organizationRole; }
            set { _organizationRole = value; }
        }

        public String Name { get { return _name; } private set { _name = value; } }

        public String Location { get { return _location; } private set { _location = value; } }

        public GADOrganization(String name, String location, IOrganizationRole organizationRole)
        {
            Name = name;
            Location = location;
            SetOrganizationRole(organizationRole);
        }

        private void SetOrganizationRole(IOrganizationRole organizationRole)
        {
            OrganizationRole = organizationRole;
        }
    }
}
