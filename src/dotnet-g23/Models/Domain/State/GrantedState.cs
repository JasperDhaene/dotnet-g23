using System;

namespace dotnet_g23.Models.Domain.State
{
    public class GrantedState : State
    {
        public override Post Announce(Context context, Label label, string message)
        {
            if (label.Post != null)
                throw new StateException("Er bestaat al een nieuwsbericht");

            var post = new Post(message);
            post.Label = label;
            label.Post = post;

            context.CurrentState = new AnnouncedState();

            return post;
        }

        public override void SetupAction(Context context, Group group, string title, string description, DateTime? date)
        {
            var action = new Action(group, title, description, date);
            group.Actions.Add(action);
        }

        public override bool CanSetup()
        {
            return true;
        }
    }
}