using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace dotnet_g23.Models.Domain
{
    public class GUser
    {
        #region Fields

        private string _email;

        #endregion

        #region Properties

        public int UserId { get; private set; }
        public UserState UserState { get; set; }

        public string Email
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
        public string Domain => Email?.Split('@').Last();

        #endregion

        #region Constructors

        public GUser()
        {
        }

        public GUser(string email, UserState userState) : this()
        {
            Email = email;
            UserState = userState;
        }

        public GUser(string email) : this(email, null)
        {
        }

        #endregion
    }
}