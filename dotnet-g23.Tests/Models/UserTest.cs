using dotnet_g23.Models.Domain;
using System;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class UserTest
    {
        [Fact]
        public void newUserShouldCreateUserAsParticipantWhenSuccesfull()
        {
            string _email = "rowan.atkinson@student.hogent.be";
            UserRole _participant = new Participant(null);
            User g = new User(_email, _participant);
            Assert.Equal(_email, g.Email);
            Assert.True(g.UserRole == _participant);
        }

        [Fact]
        public void newUserShouldCreateUserAsLectorWhenSuccesfull()
        {
            string _email = "rowan.atkinson@hogent.be";
            UserRole _lector = new Lector();
            User g = new User(_email, _lector);
            Assert.Equal(_email, g.Email);
            Assert.True(g.UserRole == _lector);
        }

        [Fact]
        public void newUserShouldThrowArgumentExceptionCreateUserAsLectorWhenEmailIncorrect()
        {
            string _email = "rowan.atkinson";
            UserRole _lector = new Lector();
            Assert.Throws<ArgumentException>(() => new User(_email, _lector));
        }

        [Fact]
        public void newUserShouldThrowArgumentExceptionCreateUserAsParticipantWhenEmailIncorrect()
        {
            string _email = "student.hogent.be";
            UserRole _participant = new Participant(null);
            Assert.Throws<ArgumentException>(() => new User(_email, _participant));
        }

        [Fact]
        public void ChangeUserRoleShouldChangeRole()
        {
            User g = new User("test@test.be", new Lector());
            Assert.True(g.UserRole.GetType().Name.Equals("Volunteer"));
            g.UserRole = new Participant(null);
            Assert.True(g.UserRole.GetType().Name.Equals("Participant"));
        }
    }
}
