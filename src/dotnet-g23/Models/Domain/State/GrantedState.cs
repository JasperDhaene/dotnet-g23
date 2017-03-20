using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class GrantedState : State
    {
        public override void Announce(Context context, Label label, String message)
        {
            Post post = new Post(message, null);
            post.Label = label;

            context.CurrentState = new AnnouncedState();
        }
    }
}
