using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class AnnouncedState : State
    {
        public override Post Announce(Context context, Label label, String message, Byte[] logo)
        {
            throw new StateException("Er werd al een bericht gepubliceerd");
        }

        public override void setupAction(Context context, Group group,String title, String description, DateTime date)
        {
            Action action = new Action(group,title,description,date);
            group.Actions.Add(action);
        }

        public override Boolean CanSetup() { return true; }
    }
}
