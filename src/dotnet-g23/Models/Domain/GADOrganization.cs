using System;

namespace dotnet_g23.Models.Domain
{
    public class GADOrganization
    {
        #region Fields
        private String _name;
        private String _location;
        private OrganizationRole _organizationRole;
        #endregion

        #region Properties
        public int OrganizationId { get; set; }
        public OrganizationRole OrganizationRole
        {
            get { return _organizationRole; }
            set { _organizationRole = value; }
        }

        public String Name {
            get { return _name; }
            private set
            {
                if (value.Equals(null) || value.Trim() == String.Empty || value == String.Empty)
                {
                    throw new ArgumentException("Name can not be empty!");
                }
                _name = value;
            }
        }
        public string Location {
            get { return _location; }
            private set
            {
                if (value.Equals(null) || value.Trim() == String.Empty || value == String.Empty)
                {
                    throw new ArgumentException("Location can not be empty!");
                }
                _location = value;
            }
        }
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
