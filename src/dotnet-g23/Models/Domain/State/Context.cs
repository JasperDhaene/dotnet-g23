using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class Context
    {
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

        #region Constructors
        public Context()
        {
            CurrentState = new InitialState();
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

        public void Grant(Group group, Company company)
        {
            CurrentState.Grant(this, group, company);
        }
        #endregion
    }
}
