using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class GrantedState : State
    {
        public override Post Announce(Context context, Label label, String message)
        {
            Post post = new Post(message, Encoding.ASCII.GetBytes("FUCK YOU PREBEN"));
            post.Label = label;
            label.Post = post;

            context.CurrentState = new AnnouncedState();

            return post;
        }
    }
}
