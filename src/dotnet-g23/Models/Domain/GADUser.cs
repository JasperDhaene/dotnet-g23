using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class GADUser
    {
        private String _email;
        private IUserRole _userRole;

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

        public GADUser(String email, IUserRole userRole)
        {
            Email = email;
            SetUserRole(userRole);
        }

        private void SetUserRole(IUserRole userRole)
        {
            UserRole = userRole;
        }
    }
}
