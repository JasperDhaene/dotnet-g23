using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Contact
    {
        #region Properties
        public int ContactId { get; private set; }
        public String Title { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public Company Company { get; private set; }
        public String Function { get; set; }
        #endregion
    }
}
