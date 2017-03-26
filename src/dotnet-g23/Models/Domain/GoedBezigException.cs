using System;

namespace dotnet_g23.Models.Domain
{
    public class GoedBezigException : Exception
    {
        #region Constructors

        public GoedBezigException(string message) : base(message)
        {
        }

        #endregion
    }
}