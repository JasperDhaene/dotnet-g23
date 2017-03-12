using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet_g23.Models.Domain.State;

namespace dotnet_g23.Models.Domain
{
    public class Group
    {
        #region Fields
        private String _name;
        #endregion

        #region Properties
        public int GroupId { get; private set; }
        public Organization Organization { get; private set; }
        public ICollection<Participant> Participants { get; }
        public Lector Lector { get; private set; }
        public ICollection<Invitation> Invitations { get; set; }
        public Motivation Motivation { get; set; }

        // Memory-only property
        [NotMapped]
        public Context Context { get; set; }

        // Database serialisation
        /*public int StateContext;

        public int ContextForeignKey { get; private set; }*/

        public String Name
        {
            get { return _name; }
            private set {
                if(value == null || value.Trim() == String.Empty || value == String.Empty)
                {
                    throw new ArgumentException("Naam kan niet leeg zijn");
                }
                _name = value;
            }
        }
        public Boolean Closed { get; set; }
        #endregion

        #region Constructors
        public Group()
        {
            Participants = new List<Participant>();
            Invitations = new List<Invitation>();
            // TODO: assign Lector
        }
        public Group(String name) : this()
        {
            Name = name;
            Closed = false;
            Context = new Context();
        }

        public Group(String name, Boolean closed) : this(name)
        {
            Closed = closed;
        }
		#endregion

		#region Methods

        public void Invite(Participant participant)
        {
            Invitation invitation = new Invitation(this, participant, $"U bent uitgenodigd om toe te treden tot de groep '${Name}'");
        }
	    public void Register(Participant participant)
	    {
		    participant.Group = this;
			Participants.Add(participant);
	    }
		#endregion
	}
}
