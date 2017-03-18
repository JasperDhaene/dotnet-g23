using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using dotnet_g23.Models.Domain.State;

namespace dotnet_g23.Models.Domain {
    public class Group {
        #region Fields
        private String _name;
        #endregion

        #region Properties
        public int GroupId { get; private set; }
        public Organization Organization { get; set; }
        public ICollection<Participant> Participants { get; }
        public Lector Lector { get; private set; }
        public ICollection<Invitation> Invitations { get; set; }
        public Motivation Motivation { get; set; }
        public Label Label { get; set; }

        // Memory-only property
        [NotMapped]
        public Context Context { get; set; }

        // Database serialisation property
        public String StateContext {
            get { return Context.SerializableState; }
            set { Context.SerializableState = value; }
        }

        public String Name {
            get { return _name; }
            private set {
                if (value == null || value.Trim() == String.Empty || value == String.Empty) {
                    throw new GoedBezigException("Naam mag niet leeg zijn");
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
            Context = new Context();
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
        public void Invite(Participant participant)
        {
            Context.Invite(this, participant);
        }

        public void Register(Participant participant)
        {
            Context.Register(this, participant);
        }
        public void Submit()
        {
            Context.Submit(this);
        }

        public void Grant(Company company)
        {
            Context.Grant(this, company);
        }
        #endregion
    }
}