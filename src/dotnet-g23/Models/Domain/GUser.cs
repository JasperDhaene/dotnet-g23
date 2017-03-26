using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace dotnet_g23.Models.Domain
{
    public class GUser
    {
        #region Fields

        private String _email;

        #endregion

        #region Properties

        public int UserId { get; private set; }
        public UserState UserState { get; set; }

        public String Email
        {
            get { return _email; }
            set
            {
                if (!value.Contains('@'))
                    throw new GoedBezigException("Ongeldig emailadres");
                _email = value;
            }
        }

        [NotMapped]
        public String Domain => Email?.Split('@').Last();

        #endregion

        #region Constructors

        public GUser()
        {
        }

        public GUser(String email, UserState userState) : this()
        {
            Email = email;
            UserState = userState;
        }

        public GUser(String email) : this(email, null)
        {
        }

        #endregion
    }
}