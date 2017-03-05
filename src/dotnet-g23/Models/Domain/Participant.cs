using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Participant : UserState
    {
        #region Properties
        public Group Group { get; set; }
        public Lector Lector { get; set; }
        public Organization Organization { get; set; }
        #endregion

        #region Constructors
        public Participant()
        {
        }
        public Participant(Organization organization)
        {
            Organization = organization;
        }
        #endregion
    }
}
