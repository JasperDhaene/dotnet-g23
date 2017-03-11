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
        public ICollection<Invitation> Invitations { get; }

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
                    throw new ArgumentException("Incorrect emailadres, gelieve opnieuw te proberen.");
                }
            }
        }

        [NotMapped]
        public String Domain => Email?.Split('@').Last();

        #endregion

        #region Constructors
        public GUser()
        {
            Invitations = new List<Invitation>();
        }
        public GUser(String email, UserState userState): this()
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
