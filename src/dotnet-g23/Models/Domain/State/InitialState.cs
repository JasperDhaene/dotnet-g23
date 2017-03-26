using System.Linq;

namespace dotnet_g23.Models.Domain.State
{
    public class InitialState : State
    {
        public override void Invite(Context context, Group group, Participant participant)
        {
            if (participant == null)
                throw new StateException("Gebruiker niet gevonden in het systeem");

            if (participant.Invitations.Any(i => i.Group == group))
                throw new StateException("Gebruiker is reeds uitgenodigd tot de groep");

            if (participant.User.Domain != group.Organization.Domain)
                throw new StateException("Gebruiker behoort niet tot hetzelfde domein als de organisatie");

            if (participant.Group != null)
                throw new StateException("Gebruiker behoort al tot een groep");

            var invitation = new Invitation(group, participant);
            participant.Invitations.Add(invitation);
        }

        public override void Register(Context context, Group group, Participant participant)
        {
            if (participant == null)
                throw new StateException("Gebruiker niet gevonden in het systeem");

            if (group == null)
                throw new StateException("Group niet gevonden in het systeem");

            if (participant.Group != null)
                throw new StateException("U behoort al tot een groep");

            if (group.Closed && participant.Invitations.All(i => i.Group != group))
                throw new StateException($"U bent niet uitgenodigd tot de groep '{group.Name}'");

            participant.Group = group;
            group.Participants.Add(participant);
        }

        public override void Submit(Context context, Group group)
        {
            if (group.Motivation == null)
                throw new StateException("Motivatie moet aanwezig zijn");

            context.CurrentState = new SubmittedState();
        }

        public override void Save(Context context, Group group, Motivation motivation)
        {
            group.Motivation = motivation;
        }

        public override bool CanInvite()
        {
            return true;
        }
    }
}