using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class GADUser
    {
        #region Fields
        private String _email;
        private UserRole _userRole;
        #endregion

        #region Properties
        public int UserId { get; set; }

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

        public UserRole UserRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }
        #endregion

        #region Constructors
        public GADUser(String email, UserRole userRole)
        {
            Email = email;
            SetUserRole(userRole);
        }
        #endregion

        #region Methods
        private void SetUserRole(UserRole userRole)
        {
            UserRole = userRole;
        }
        #endregion
    }
}
