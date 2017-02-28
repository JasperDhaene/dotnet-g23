using System;
using dotnet_g23.Models.Domain;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class UserTest
    {
        [Fact]
        public void UserHasValidEmail()
        {
            string email = "foo@bar";
            User user = new User(email, null);

            Assert.Equal(email, user.Email);
        }

        [Fact]
        public void UserThrowsExceptionOnInvalidEmail()
        {
            string email = "foobar";

            Assert.Throws<ArgumentException>(() => new User(email, null));
        }
    }
}
