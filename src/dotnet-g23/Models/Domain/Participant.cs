using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Participant : UserState
    {
        #region Properties
        public Organization Organization { get; set; }
        public Group Group { get; set; }
        public Lector Lector { get; private set; }
        public ICollection<Invitation> Invitations { get; }
        #endregion

        #region Constructors
        public Participant()
        {
            Invitations = new List<Invitation>();
        }
        public Participant(Organization organization)
        {
            Organization = organization;
        }
        #endregion
    }
}
