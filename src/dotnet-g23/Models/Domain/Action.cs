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
        public int ActionId { get; private set; }
        public String Title { get; set; }
        public String Description {
            get {
                return _description;
            }
            set {
                if (value.Equals(null) || value.Equals("") || value.Trim(' ').Equals(""))
                    throw new GoedBezigException("Omschrijving mag niet leeg zijn!");
                _description = value;
            }
        }

        public DateTime? Date { get;  set; } //TODO: private set? Don't know difference

        public Group Group { get; private set; }
        #endregion

        #region Constructors
        public Action()
        {
        }

        public Action(Group group, string title, string description) : this()
        {
            Group = group;
            Title = title;
            Description = description;
            Date = null;
        } 

        public Action(Group group, string title, string description, DateTime? date) : this()
        {
            Title = title;
            Description = description;
            Date = date;
        } 
        #endregion
    }
}
