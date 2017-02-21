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
        private IUserRole _userRole;
        #endregion

        #region Properties
        public int UserId { get; set; }

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public IUserRole UserRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }
        #endregion

        #region Constructors
        public GADUser(String email, IUserRole userRole)
        {
            Email = email;
            SetUserRole(userRole);
        }
        #endregion

        #region Methods
        private void SetUserRole(IUserRole userRole)
        {
            UserRole = userRole;
        }
        #endregion
    }
}
