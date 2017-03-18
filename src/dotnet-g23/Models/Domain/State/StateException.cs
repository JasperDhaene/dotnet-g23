using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class StateException : GoedBezigException
    {
        public StateException(string message = null) : base(message)
        {
        }
    }
}
