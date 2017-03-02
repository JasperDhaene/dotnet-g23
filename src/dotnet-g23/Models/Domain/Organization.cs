using System;
using System.Collections.Generic;

namespace dotnet_g23.Models.Domain
{
    public class Organization
    {
        #region Fields
        private String _name;
        private String _location;
        #endregion

        #region Properties
        public int OrganizationId { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Participant> Participants { get; set; }

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

        public Organization()
        {
            
        }

        public Organization(String name, String location)
        {
            Name = name;
            Location = location;
        }
        #endregion
    }
}
