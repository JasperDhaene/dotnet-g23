using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet_g23.Models.Domain.State;

namespace dotnet_g23.Models.Domain
{
    public class Group
    {
        #region Fields

        private string _name;

        #endregion

        #region Properties

        public int GroupId { get; private set; }
        public Organization Organization { get; set; }
        public ICollection<Participant> Participants { get; }
        public Lector Lector { get; private set; }
        public ICollection<Invitation> Invitations { get; }
        public Motivation Motivation { get; set; }
        public Label Label { get; set; }
        public ICollection<Action> Actions { get; }

        // Memory-only property
        [NotMapped]
        public Context Context { get; set; }

        // Database serialisation property
        public string StateContext
        {
            get { return Context.SerializableState; }
            set { Context.SerializableState = value; }
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if ((value == null) || (value.Trim() == string.Empty) || (value == string.Empty))
                    throw new GoedBezigException("Naam mag niet leeg zijn");
                _name = value;
            }
        }

        public bool Closed { get; set; }

        #endregion

        #region Constructors

        public Group()
        {
            Participants = new List<Participant>();
            Invitations = new List<Invitation>();
            Actions = new List<Action>();
            Context = new Context();
        }

        public Group(string name) : this()
        {
            Name = name;
            Closed = false;
        }

        public Group(string name, bool closed) : this(name)
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

        public void Save(Motivation motivation)
        {
            Context.Save(this, motivation);
        }

        public void Grant(Company company)
        {
            Context.Grant(this, company);
        }

        public Post Announce(string message)
        {
            return Context.Announce(Label, message);
        }

        public void SetupAction(string title, string description, DateTime? date = null)
        {
            Context.SetupAction(this, title, description, date);
        }

        public bool CanInvite()
        {
            return Context.CanInvite();
        }

        public bool CanSetup()
        {
            return Context.CanSetup();
        }

        #endregion
    }
}