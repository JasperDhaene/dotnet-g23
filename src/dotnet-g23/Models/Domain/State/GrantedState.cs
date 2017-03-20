using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class GrantedState : State
    {
        public override Post Announce(Context context, Label label, String message, byte[] logo)
        {
            Post post = new Post(message, logo);
            post.Label = label;
            label.Post = post;

            context.CurrentState = new AnnouncedState();

            return post;
        }
    }
}
