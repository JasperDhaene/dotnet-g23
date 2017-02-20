using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Group
    {
        private String _naam;
        private Boolean _isGesloten = true;

        public String Naam{
            get { return _naam; }
            private set {
                if(value.Equals(null) || value.Trim() == String.Empty || value == String.Empty)
                {
                    throw new ArgumentException("Naam mag niet leeg zijn!");
                }
                _naam = value;
            } }

        public Group(String naam)
        {
            Naam = naam;
        }

        public Group(String naam, Boolean isGesloten) : base(naam)
        {
            _isGesloten = isGesloten;
        }
    }
}
