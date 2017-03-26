using System;

namespace dotnet_g23.Models.Domain.State
{
    public class AnnouncedState : State
    {
        public override Post Announce(Context context, Label label, string message)
        {
            throw new StateException("Er werd al een bericht gepubliceerd");
        }

        public override void SetupAction(Context context, Group group, string title, string description, DateTime? date)
        {
            new GrantedState().SetupAction(context, group, title, description, date);
        }

        public override bool CanSetup()
        {
            return true;
        }
    }
}