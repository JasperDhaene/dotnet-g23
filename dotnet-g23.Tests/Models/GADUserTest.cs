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
            GADUser g = new GADUser(_email, _volunteer);
            Assert.Equal(_email, g.Email);
            Assert.True(g.UserRole == _volunteer);
        }

        [Fact]
        public void newGADUserShouldCreateGADUserAsParticipantWhenSuccesfull()
        {
            string _email = "rowan.atkinson@student.hogent.be";
            UserRole _participant = new Participant();
            GADUser g = new GADUser(_email, _participant);
            Assert.Equal(_email, g.Email);
            Assert.True(g.UserRole == _participant);
        }

        [Fact]
        public void newGADUserShouldCreateGADUserAsLectorWhenSuccesfull()
        {
            string _email = "rowan.atkinson@hogent.be";
            UserRole _lector = new Volunteer();
            GADUser g = new GADUser(_email, _lector);
            Assert.Equal(_email, g.Email);
            Assert.True(g.UserRole == _lector);
        }

        [Fact]
        public void newGADUserShouldThrowArgumentExceptionCreateGADUserAsLectorWhenEmailIncorrect()
        {
            string _email = "rowan.atkinson";
            UserRole _lector = new Volunteer();
            Assert.Throws<ArgumentException>(() => new GADUser(_email, _lector));
        }

        [Fact]
        public void newGADUserShouldThrowArgumentExceptionCreateGADUserAsParticipantWhenEmailIncorrect()
        {
            string _email = "student.hogent.be";
            UserRole _participant = new Participant();
            Assert.Throws<ArgumentException>(() => new GADUser(_email, _participant));

        }
    }
}
