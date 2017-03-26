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
        public int CompanyId { get; private set;  }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Address { get; set; }
        public String Website { get; set; }
        public String Email { get; set; }
        public Byte[] Logo { get; set; }
        public ICollection<Contact> Contacts { get; }
        public Label Label { get; set; }
        #endregion

        #region Constructors
        public Company()
        {
            Contacts = new List<Contact>();
        }

        public Company(string name, string description, string address, string website, string email, Byte[] logo) : this()
        {
            Name = name;
            Description = description;
            Address = address;
            Website = website;
            Email = email;
            Logo = logo;
        }

        #endregion
    }
}
