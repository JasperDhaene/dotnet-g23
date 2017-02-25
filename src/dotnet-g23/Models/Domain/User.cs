using System;
using System.Text.RegularExpressions;

namespace dotnet_g23.Models.Domain
{
    public class User
    {
        #region Fields
        private String _email;
        #endregion

        #region Properties
        public String Email
        {
            get { return _email; }
            set
            {
                Regex regex = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
    + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");
                Match match = regex.Match(value);
                if (match.Success)
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Email address is incorrect, please try again.");
                }
            }
        }
        public int UserId { get; set; }
        public UserRole UserRole { get; set; }
        #endregion

        #region Constructors
        public User(String email, UserRole userRole)
        {
            Email = email;
            UserRole = userRole;
        }
        #endregion
    }
}
