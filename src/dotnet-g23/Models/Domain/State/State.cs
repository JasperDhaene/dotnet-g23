using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public abstract class State
    {
        #region Methods
        public virtual void Invite(Context context, Group group, Participant participant)
        {
            throw new StateException();
        }
        #endregion
    }
}
