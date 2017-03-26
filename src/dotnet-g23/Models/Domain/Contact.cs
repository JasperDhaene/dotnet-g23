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
        public String Function { get; set; }
        public String Email { get; set; }
        public Company Company { get; private set; }

        #endregion

        #region Constructors

        public Contact()
        {
        }

        public Contact(string title, string firstName, string lastName, string function, string email, Company company)
            : this()
        {
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            Function = function;
            Email = email;
            Company = company;
        }

        #endregion
    }
}