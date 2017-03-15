using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Event : Action
    {
        public DateTime Date { get;  set; }

        #region Constructor
        public Event() : base() { }

        public Event(string titel, string description, DateTime date) : base(titel, description) {
            Date = date;
        } 
        #endregion
    }
}
