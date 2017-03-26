using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public abstract class UserState
    {
        #region Properties
        public int UserStateId { get; private set; }
        public GUser User { get; set; }
        public int UserForeignKey { get; private set; }
        #endregion
    }
}
