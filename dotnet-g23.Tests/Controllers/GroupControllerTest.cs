using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.GroupViewModels;
using dotnet_g23.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_g23.Tests.Controllers
{
    public class GroupControllerTest
    {
        #region Fields
        private readonly GroupController _controller;
        private readonly Participant _participant;
        private readonly Participant _participant2;
        private DummyApplicationDbContext context; 
        #endregion

        #region Constructor
        public GroupControllerTest() {
            context = new DummyApplicationDbContext();

            Mock<IUserRepository> Userrepo = new Mock<IUserRepository>();
            Mock<IGroupRepository> Grouprepo = new Mock<IGroupRepository>();

            Grouprepo.Setup(o => o.GetAll()).Returns(context.Groups);

            Grouprepo.Setup(o => o.GetBy(1)).Returns(context.Groups.First());
            Grouprepo.Setup(o => o.GetBy(1)).Returns(context.Groups.Skip(1).First());

            _controller = new GroupController(Grouprepo.Object, Userrepo.Object);
            _controller.TempData = new Mock<ITempDataDictionary>().Object;

            _participant = context.Tuur.UserState as Participant;
            _participant2 = context.Preben2.UserState as Participant;
        }
        #endregion

        #region Index
        [Fact]
        public void IndexShouldReturnSubscribedGroupOfUser() {
            ViewResult result = _controller.Index(_participant) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            Group group = ind.SubscribedGroup;
            Assert.Equal(_participant.Group, group);
        }

        [Fact]
        public void IndexShouldReturnOpenGroupOfUser() {
            ViewResult result = _controller.Index(_participant) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            IEnumerable<Group> groups = ind.InvitedGroups;
            Assert.Equal(_participant.User.Invitations?.Select(n => n.Group), groups);
        }

        [Fact]
        public void IndexShouldReturnClosedGroupOfUser() {
            ViewResult result = _controller.Index(_participant) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            IEnumerable<Group> groups = ind.OpenGroups;
            Assert.Equal(_participant.Organization.Groups?.Where(g => !g.Closed), groups);
        }
        #endregion

        #region HTTP POST Register
        [Fact]
        public void ParticipantShouldRegisterInGroup() {
            RedirectToActionResult result = _controller.Register(_participant, context.Groups.Skip(1).First().GroupId) as RedirectToActionResult;
            Assert.Equal((context.Tuur.UserState as Participant).Group, _participant.Group);
            Assert.Equal("Show", result.ActionName);
            Assert.Equal("Groups", result.ControllerName);
        }

        public void ParticipantShouldRedirectToIndexOfGroupsBecauseAlreadyInGroup() {
            RedirectToActionResult result = _controller.Register(_participant2, context.Groups.First().GroupId) as RedirectToActionResult;
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Groups", result.ControllerName);
        }
        #endregion

        #region HTTP GET Show
        [Fact]
        public void ShowShouldShowGroupOfParticipant() {
            _controller.Show(_participant2, context.Groups.First().GroupId);
            Assert.Equal(context.Groups.First(), _participant2.Group);
        }
        #endregion
    }
}
