namespace dotnet_g23.Models.Domain
{
    public class Contact
    {
        #region Properties

        public int ContactId { get; private set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Function { get; set; }
        public string Email { get; set; }
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