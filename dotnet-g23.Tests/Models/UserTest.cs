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
            string email = "foo@bar.be";
            GUser user = new GUser(email, null);

            Assert.Equal(email, user.Email);
        }

        [Fact]
        public void UserThrowsExceptionOnInvalidEmail()
        {
            string email = "foobar";

            Assert.Throws<ArgumentException>(() => new GUser(email, null));
        }

        [Fact]
        public void UserThrowsExceptionOnMissingAt() {
            string email = "foobar.be";

            Assert.Throws<ArgumentException>(() => new GUser(email, null));
        }

        [Fact]
        public void UserThrowsExceptionOnMissingServiceProvider() {
            string email = "foobar@";

            Assert.Throws<ArgumentException>(() => new GUser(email, null));
        }
    }
}
