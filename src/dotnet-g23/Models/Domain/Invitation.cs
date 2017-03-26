namespace dotnet_g23.Models.Domain
{
    public class Invitation
    {
        #region Properties

        public int InvitationId { get; private set; }
        public Participant Participant { get; private set; }
        public Group Group { get; private set; }

        #endregion

        #region Constructors

        public Invitation()
        {
        }

        public Invitation(Group fromGroup, Participant toParticipant) : this()
        {
            Group = fromGroup;
            Participant = toParticipant;
        }

        #endregion
    }
}