using dotnet_g23.Models.Domain;
using System;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class GADUserTest
    {
        [Fact]
        public void newGADUserShouldCreateGADUserAsVolunteerWhenSuccesfull()
        {
            string _email = "rowan.atkinson@student.hogent.be";
            UserRole _volunteer = new Volunteer();
            User g = new User(_email, _volunteer);
            Assert.Equal(_email, g.Email);
            Assert.True(g.UserRole == _volunteer);
        }

        [Fact]
        public void newGADUserShouldCreateGADUserAsParticipantWhenSuccesfull()
        {
            string _email = "rowan.atkinson@student.hogent.be";
            UserRole _participant = new Participant();
            User g = new User(_email, _participant);
            Assert.Equal(_email, g.Email);
            Assert.True(g.UserRole == _participant);
        }

        [Fact]
        public void newGADUserShouldCreateGADUserAsLectorWhenSuccesfull()
        {
            string _email = "rowan.atkinson@hogent.be";
            UserRole _lector = new Volunteer();
            User g = new User(_email, _lector);
            Assert.Equal(_email, g.Email);
            Assert.True(g.UserRole == _lector);
        }

        [Fact]
        public void newGADUserShouldThrowArgumentExceptionCreateGADUserAsLectorWhenEmailIncorrect()
        {
            string _email = "rowan.atkinson";
            UserRole _lector = new Volunteer();
            Assert.Throws<ArgumentException>(() => new User(_email, _lector));
        }

        [Fact]
        public void newGADUserShouldThrowArgumentExceptionCreateGADUserAsParticipantWhenEmailIncorrect()
        {
            string _email = "student.hogent.be";
            UserRole _participant = new Participant();
            Assert.Throws<ArgumentException>(() => new User(_email, _participant));
        }

        [Fact]
        public void ChangeUserRoleShouldChangeRole()
        {
            User g = new User("test@test.be", new Volunteer());
            Assert.True(g.UserRole.GetType().Name.Equals("Volunteer"));
            g.SetUserRole(new Participant());
            Assert.True(g.UserRole.GetType().Name.Equals("Participant"));
        }
    }
}
