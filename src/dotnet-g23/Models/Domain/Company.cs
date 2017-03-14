using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Company
    {
        #region Properties
        public int CompanyId { get; private set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Website { get; set; }
        public String Email { get; set; }
        public ICollection<Contact> Contacts { get; private set; }
        #endregion

        #region Constructors
        public Company()
        {
            Contacts = new List<Contact>();
        }
        #endregion
    }
}
