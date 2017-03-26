using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class GoedBezigException : Exception
    {
        #region Constructors

        public GoedBezigException(String message) : base(message)
        {
        }

        #endregion
    }
}