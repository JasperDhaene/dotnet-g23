using System;

namespace dotnet_g23.Models.Domain
{
    public class GADOrganization
    {
        #region Fields
        private String _name;
        private OrganizationRole _organizationRole;
        #endregion

        #region Properties
        public int OrganizationId { get; set; }
        public OrganizationRole OrganizationRole
        {
            get { return _organizationRole; }
            set { _organizationRole = value; }
        }

        public String Name { get { return _name; } private set { _name = value; } }
        public string Location { get; set; }
        #endregion

        #region Constructors
        public GADOrganization(String name, String location, OrganizationRole organizationRole)
        {
            Name = name;
            Location = location;
            SetOrganizationRole(organizationRole);
        }
        #endregion

        #region Methods
        private void SetOrganizationRole(OrganizationRole organizationRole)
        {
            OrganizationRole = organizationRole;
        }
        #endregion
    }
}
