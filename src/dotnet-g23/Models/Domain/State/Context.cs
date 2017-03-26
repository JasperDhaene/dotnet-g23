using System;

namespace dotnet_g23.Models.Domain.State
{
    public class Context
    {
        #region Constructors

        public Context()
        {
            CurrentState = new InitialState();
        }

        #endregion

        #region Properties

        public State CurrentState { get; set; }

        public string SerializableState
        {
            // Serialize State to string
            get { return CurrentState.GetType().AssemblyQualifiedName; }

            // Deserialize string to State
            set { CurrentState = Activator.CreateInstance(Type.GetType(value)) as State; }
        }

        #endregion

        #region Methods

        public void Invite(Group group, Participant participant)
        {
            CurrentState.Invite(this, group, participant);
        }

        public void Register(Group group, Participant participant)
        {
            CurrentState.Register(this, group, participant);
        }

        public void Submit(Group group)
        {
            CurrentState.Submit(this, group);
        }

        public void Save(Group group, Motivation motivation)
        {
            CurrentState.Save(this, group, motivation);
        }

        public void Grant(Group group, Company company)
        {
            CurrentState.Grant(this, group, company);
        }

        public Post Announce(Label label, string message)
        {
            return CurrentState.Announce(this, label, message);
        }

        public void SetupAction(Group group, string title, string description, DateTime? date)
        {
            CurrentState.SetupAction(this, group, title, description, date);
        }

        public bool CanInvite()
        {
            return CurrentState.CanInvite();
        }

        public bool CanSetup()
        {
            return CurrentState.CanSetup();
        }

        #endregion
    }
}