using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State {
    public abstract class State {
        #region Methods
        public virtual void HandleNext(Context context) {
            throw new StateException();
        }

        public virtual void HandlePrevious(Context context) {
            throw new StateException();
        }
        #endregion
    }
}