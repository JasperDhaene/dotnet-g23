using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public abstract class UserRole
    {
        #region Properties
        public int UserRoleId { get; set; }
        public User User { get; set; }
        #endregion
    }
}
