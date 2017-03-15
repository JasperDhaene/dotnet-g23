using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Company
    {
        #region Properties
        public int CompanyId { get; private set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Address { get; set; }
        public String Website { get; set; }
        public String Email { get; set; }
        public ICollection<Contact> Contacts { get; private set; }
        public Label Label { get; private set; }
        #endregion

        #region Constructors
        public Company()
        {
            Contacts = new List<Contact>();
        }

        public Company(string name, string description, string address, string website, string email) : this()
        {
            Name = name;
            Description = description;
            Address = address;
            Website = website;
            Email = email;
        }

        #endregion
    }
}
