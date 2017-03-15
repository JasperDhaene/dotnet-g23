using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Action
    {
        #region Attribute
        private String _description;
        #endregion

        #region Properties
        public String Titel { get; set; }
        public String Description {
            get {
                return _description;
            }
            set {
                if (value.Equals(null) || value.Equals("") || value.Trim(' ').Equals(""))
                    throw new ArgumentException("Omschrijving mag niet leeg zijn!");
                _description = value;
            }
        } 
        #endregion

        #region Constructors
        public Action() {

        }

        public Action(string titel, string description) {
            Titel = titel;
            Description = description;
        } 
        #endregion
    }
}
