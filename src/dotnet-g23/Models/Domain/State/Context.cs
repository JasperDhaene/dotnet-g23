﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class Context
    {
        #region Properties

        public State CurrentState { get; set; }
        #endregion

        #region Constructors
        public Context()
        {
            this.CurrentState = new InitialState();
        }
        #endregion

        #region Methods
        public void NextState()
        {
            CurrentState.HandleNext(this);
        }

        public void PreviousState()
        {
            CurrentState.HandlePrevious(this);
        }
        #endregion
    }
}
