using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class GrantedState : State
    {
        public override void Announce(Context context, Group group, String message)
        {
            Label label = group.Label;
            Motivation motivation = group.Motivation;

            /*
            Post post = new Post(label, message, label.Company);
            */

            context.CurrentState = new AnnouncedState();
        }
    }
}
