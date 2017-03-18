namespace dotnet_g23.Models.Domain.State
{
    public class ApprovedState : State
    {
        public override void Invite(Context context, Group group, Participant participant)
        {
            throw new StateException($"Motivatie van groep '{ group.Name }' is al goedgekeurd");
        }

        public override void Register(Context context, Group group, Participant participant)
        {
            throw new StateException($"Motivatie van groep '{ group.Name }' is al goedgekeurd");
        }
    }
}
