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
        public Label Label { get; private set; }

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

        public void Register(Participant participant) {
            if (participant.Group != null)
                throw new GoedBezigException("U behoort al tot een groep");

            if (Closed && participant.Invitations.All(i => i.Group != this))
                throw new GoedBezigException($"U bent niet uitgenodigd tot de groep '{ Name }'");

            if (!(Context.CurrentState is InitialState) && !(Context.CurrentState is SubmittedState))
                throw new GoedBezigException($"Motivatie van groep '{ Name }' is al goedgekeurd");

            participant.Group = this;
            Participants.Add(participant);
        }
        public void Submit()
        {
            if (Motivation.MotivationText.Length < 100 || Motivation.MotivationText.Length > 250)
                throw new GoedBezigException("Motivatie moet tussen 100 en 250 tekens lang zijn");

            // TODO: Context.Submit();
        }

        public void Grant(Company company)
        {
            if (company.Label != null)
                throw new GoedBezigException($"Bedrijf '{ company.Name }' beschikt al over een Goed Bezig-label");

            Label = new Label(this, company);
            company.Label = Label;
        }
        #endregion
    }
}