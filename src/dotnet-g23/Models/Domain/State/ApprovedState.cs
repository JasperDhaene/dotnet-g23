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

        public override void Grant(Context context, Group group, Company company)
        {
            if (company.Label != null)
                throw new StateException($"Bedrijf '{ company.Name }' beschikt al over een Goed Bezig-label");

            Label label = new Label(group, company);

            group.Label = label;
            company.Label = label;
        }
    }
}
