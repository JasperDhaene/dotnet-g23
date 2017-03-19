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
            throw new StateException($"Operation not supported in { GetType() }");
        }

        public virtual void Register(Context context, Group group, Participant participant)
        {
            throw new StateException($"Operation not supported in { GetType() }");
        }

        public virtual void Submit(Context context, Group group)
        {
            throw new StateException($"Operation not supported in { GetType() }");
        }

        public virtual void Grant(Context context, Group group, Company company)
        {
            throw new StateException($"Operation not supported in { GetType() }");
        }

        public virtual void Announce(Context context, Group group, String message)
        {
            throw new StateException($"Operation not supported in { GetType() }");
        }
        #endregion
    }
}
