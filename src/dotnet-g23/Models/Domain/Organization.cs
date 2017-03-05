using System;
using System.Collections.Generic;
using dotnet_g23.Controllers;
using dotnet_g23.Helpers;

namespace dotnet_g23.Models.Domain
{
    public class Organization
    {
        #region Fields
        private String _name;
        private String _location;
		private String _domain;
		#endregion

		#region Properties
		public int OrganizationId { get; private set; }
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
		public string Domain {
			get { return _domain; }
			private set {
				if (value.Equals(null) || value.Trim() == String.Empty || value == String.Empty) {
					throw new ArgumentException("Domain can not be empty!");
				}
				_domain = value;
			}
		}
		#endregion

		#region Constructors
        public Organization()
        {
        }

        public Organization(String name, String location, String domain)
        {
            Name = name;
            Location = location;
	        Domain = domain;
        }
		#endregion

	    #region Methods
	    public void Register(GUser user)
	    {
            if (!MailHelper.GetMailDomain(user.Email).Equals(Domain))
                throw new ArgumentException("Gebruiker behoort niet tot hetzelfde domein als de organisatie");

            user.UserState = new Participant(this);
	    }

		public void CreateGroup(Participant user, string name) {
			Group group = new Group(name);
			group.Register(user);
			Groups.Add(group);
		}
		#endregion
	}
}
