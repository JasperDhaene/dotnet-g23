using System.Collections.Generic;

namespace dotnet_g23.Models.Domain
{
    public class Company
    {
        #region Properties

        public int CompanyId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
        public ICollection<Contact> Contacts { get; }
        public Label Label { get; set; }

        #endregion

        #region Constructors

        public Company()
        {
            Contacts = new List<Contact>();
        }

        public Company(string name, string description, string address, string website, string email, byte[] logo)
            : this()
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