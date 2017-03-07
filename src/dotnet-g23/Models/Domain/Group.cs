using System;
using System.Collections.Generic;

namespace dotnet_g23.Models.Domain
{
    public class Group
    {
        #region Fields
        private String _name;
        #endregion

        #region Properties
        public int GroupId { get; private set; }
        public String Name
        {
            get { return _name; }
            private set {
                if(value == null || value.Trim() == String.Empty || value == String.Empty)
                {
                    throw new ArgumentException("Name can not be empty!");
                }
                _name = value;
            }
        }
        public Boolean Closed { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Lector> Lectors { get; set; }
        public Organization Organization { get; set; }
        public Motivation Motivation { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
        #endregion

        #region Constructors
        public Group()
        {
            Participants = new List<Participant>();
            Lectors = new List<Lector>();
            Invitations = new List<Invitation>();
        }
        public Group(String name) : this()
        {
            Name = name;
            Closed = false;
        }

        public Group(String name, Boolean closed) : this(name)
        {
            Closed = closed;
        }
		#endregion

		#region Methods

        public void Invite(Participant user)
        {
            Invitation invitation = new Invitation(this, user.User, $"You have been invited to the group ${Name}!");
        }
	    public void Register(Participant user)
	    {
		    user.Group = this;
			Participants.Add(user);
	    }
		#endregion
	}
}
