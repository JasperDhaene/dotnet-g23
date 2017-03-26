using System;

namespace dotnet_g23.Models.Domain.State
{
    public abstract class State
    {
        #region Methods

        public virtual void Invite(Context context, Group group, Participant participant)
        {
            throw new StateException($"Operation not supported in {GetType()}: Invite");
        }

        public virtual void Register(Context context, Group group, Participant participant)
        {
            throw new StateException($"Operation not supported in {GetType()}: Register");
        }

        public virtual void Submit(Context context, Group group)
        {
            throw new StateException($"Operation not supported in {GetType()}: Submit");
        }

        public virtual void Save(Context context, Group group, Motivation motivation)
        {
            throw new StateException($"Operation not supported in {GetType()}: Submit");
        }

        public virtual void Grant(Context context, Group group, Company company)
        {
            throw new StateException($"Operation not supported in {GetType()}: Grant");
        }

        public virtual Post Announce(Context context, Label label, string message)
        {
            throw new StateException($"Operation not supported in {GetType()}: Announce");
        }

        public virtual void SetupAction(Context context, Group group, string title, string description, DateTime? date)
        {
            throw new StateException($"Operation not supported in {GetType()}: SetupAction");
        }

        public virtual bool CanInvite()
        {
            return false;
        }

        public virtual bool CanSetup()
        {
            return false;
        }

        #endregion
    }
}