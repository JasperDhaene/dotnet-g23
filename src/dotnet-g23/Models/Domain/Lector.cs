using System.Collections.Generic;

namespace dotnet_g23.Models.Domain
{
    public class Lector : UserState
    {
        #region Constructors

        public Lector()
        {
            Participants = new List<Participant>();
            Groups = new List<Group>();
        }

        #endregion

        #region Properties

        public ICollection<Participant> Participants { get; }
        public ICollection<Group> Groups { get; }

        #endregion
    }
}