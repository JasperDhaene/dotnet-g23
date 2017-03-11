using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public abstract class State
    {
        #region Properties
        public int StateId { get; set; }
        public Context Context { get; set; }
        public int Order { get; }
        #endregion

        #region Constructors
        protected State(int order)
        {
            Order = order;
        }
        #endregion

        #region Methods
        public virtual void HandleNext()
        {
            throw new StateException();
        }

        public virtual void HandlePrevious()
        {
            throw new StateException();
        }
        #endregion
    }
}
