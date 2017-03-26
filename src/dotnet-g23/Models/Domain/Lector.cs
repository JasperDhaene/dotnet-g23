using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Lector : UserState
    {
        #region Properties

        public ICollection<Participant> Participants { get; }
        public ICollection<Group> Groups { get; }

        #endregion

        #region Constructors

        public Lector()
        {
            Participants = new List<Participant>();
            Groups = new List<Group>();
        }

        #endregion
    }
}