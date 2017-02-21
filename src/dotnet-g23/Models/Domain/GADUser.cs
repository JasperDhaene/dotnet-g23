using System;
using System.Collections.Generic;
using System.Linq;
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
            set { _email = value; }
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
