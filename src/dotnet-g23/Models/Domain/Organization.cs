using System;
using System.Collections.Generic;
using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain.Repositories;
using System.Linq;

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
        public ICollection<Participant> Participants { get; }
        public ICollection<Group> Groups { get; }
        public ICollection<Post> Posts { get; }

        public String Name {
            get { return _name; }
            private set
            {
                if (value.Equals(null) || value.Trim() == String.Empty || value == String.Empty)
                {
                    throw new GoedBezigException("Naam mag niet leeg zijn");
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
                    throw new GoedBezigException("Locatie mag niet leeg zijn");
                }
                _location = value;
            }
        }
		public string Domain {
			get { return _domain; }
			private set {
				if (value.Equals(null) || value.Trim() == String.Empty || value == String.Empty) {
					throw new GoedBezigException("Domein mag niet leeg zijn");
				}
				_domain = value;
			}
		}
		#endregion

		#region Constructors
        public Organization()
        {
            Participants = new List<Participant>();
            Groups = new List<Group>();
        }
        
        public Organization(String name, String location, String domain): this()
        {
            Name = name;
            Location = location;
	        Domain = domain;
        }
		#endregion

	    #region Methods
	    public void Register(GUser user)
	    {
            if (user.Domain != Domain)
                throw new GoedBezigException("Gebruiker behoort niet tot hetzelfde domein als de organisatie");

	        if (user.UserState != null)
	            throw new GoedBezigException("Gebruiker behoort al tot een organisatie");

            user.UserState = new Participant(this);
	    }

		public Group CreateGroup(Participant participant, String name, Boolean closed) {
		    if (participant.Group != null)
		        throw new GoedBezigException("U bent reeds ingeschreven in een groep");

            if (Groups.Any(g => g.Name == name))
                throw new GoedBezigException($"De naam '{name}' is al in gebruik binnen deze organisatie");

            Group group = new Group(name, closed);

            Groups.Add(group);
		    group.Organization = this;

            // Registering with a closed group requires an invitation
            if (closed)
                group.Invite(participant);

            // TODO: invitation doesn't get destroyed (because that usually happens in the controller)

            group.Register(participant);
		    return group;
		}
		#endregion
	}
}
