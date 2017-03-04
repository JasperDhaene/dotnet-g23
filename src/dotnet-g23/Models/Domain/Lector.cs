using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Lector : UserState
    {
        #region Properties
        public ICollection<Participant> Participants { get; set; }
        public Group Group { get; set; }
        #endregion
    }
}
