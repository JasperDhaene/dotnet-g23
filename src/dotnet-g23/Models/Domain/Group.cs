using System;
using System.Collections.Generic;

namespace dotnet_g23.Models.Domain
{
    public class Group
    {
        #region Fields
        private String _name;
        private Boolean _closed;
        #endregion

        #region Properties
        public int GroupId { get; set; }
        public String Name
        {
            get { return _name; }
            private set {
                if(value.Equals(null) || value.Trim() == String.Empty || value == String.Empty)
                {
                    throw new ArgumentException("Name can not be empty!");
                }
                _name = value;
            }
        }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Lector> Lectors { get; set; }
        public GBOrganization GBOrganization { get; set; }
        #endregion

        #region Constructors
        public Group(String name)
        {
            Name = name;
            _closed = true;
        }

        public Group(String name, Boolean closed) : this(name)
        {
            _closed = closed;
        }
        #endregion

        public Boolean IsClosed()
        {
            return _closed;
        }
    }
}
