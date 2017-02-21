using System;

namespace dotnet_g23.Models.Domain
{
    public class GADOrganization
    {
        #region Fields
        private String _name;
        private String _location;
        private IOrganizationRole _organizationRole;
        #endregion

        #region Properties
        public int OrganizationId { get; set; }
        public IOrganizationRole OrganizationRole
        {
            get { return _organizationRole; }
            set { _organizationRole = value; }
        }

        public String Name { get { return _name; } private set { _name = value; } }

        public String Location { get { return _location; } private set { _location = value; } }
        #endregion

        #region Constructors
        public GADOrganization(String name, String location, IOrganizationRole organizationRole)
        {
            Name = name;
            Location = location;
            SetOrganizationRole(organizationRole);
        }
        #endregion

        #region Methods
        private void SetOrganizationRole(IOrganizationRole organizationRole)
        {
            OrganizationRole = organizationRole;
        }
        #endregion
    }
}
