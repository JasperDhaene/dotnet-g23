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

namespace dotnet_g23.Tests.Controllers {
    public class GroupControllerTest {
        #region Fields
        private readonly GroupController _controller;
        private readonly Participant _participant;
        private readonly Participant _participant2;
        private DummyApplicationDbContext context;
        #endregion

        #region Constructor
        public GroupControllerTest() {
            context = new DummyApplicationDbContext();

            Mock<IParticipantRepository> ParticipantRepo = new Mock<IParticipantRepository>();
            Mock<IGroupRepository> Grouprepo = new Mock<IGroupRepository>();

            Grouprepo.Setup(o => o.GetAll()).Returns(context.Groups);

            Grouprepo.Setup(o => o.GetBy(1)).Returns(context.Groups.First());
            Grouprepo.Setup(o => o.GetBy(1)).Returns(context.Groups.Skip(1).First());

            _controller = new GroupController(Grouprepo.Object, ParticipantRepo.Object);
            _controller.TempData = new Mock<ITempDataDictionary>().Object;

            _participant2 = context.Tuur.UserState as Participant;
            _participant = context.Preben2.UserState as Participant;
        }
        #endregion

        #region Index
        [Fact]
        public void IndexShouldReturnSubscribedGroupOfUser() {
            ViewResult result = _controller.Index(_participant2) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            //Assert.Equal(_participant2.Organization, ind.Organization);
            Group group = ind.SubscribedGroup;
            Assert.Equal(_participant2.Group, group);
        }

        [Fact]
        public void IndexShouldReturnOpenGroupOfUser() {
            ViewResult result = _controller.Index(_participant) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            IEnumerable<Group> groups = ind.InvitedGroups;
            Assert.Equal(_participant.Invitations?.Select(n => n.Group), groups);
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

        public void ParticipantShouldRedirectToIndexOfGroupsBecauseAlreadyInGroup() {
            RedirectToActionResult result = _controller
                .Register(_participant, context.Groups.First().GroupId) 
                as RedirectToActionResult;
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void ParticipantShouldRegisterInGroup() {
            RedirectToActionResult result = _controller
                .Register(_participant2, context.Groups.First().GroupId)
                as RedirectToActionResult;
            Assert.Equal("Show", result.ActionName);
        }
        #endregion

        #region HTTP POST Create
        [Fact]
        public void ParticipantShouldCreateGroup() {
            RedirectToActionResult result = _controller.Create(_participant, "testGroup", true) as RedirectToActionResult;
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void ParticipantCannotCreateGroupBecauseAlreadyInGroup() {
            RedirectToActionResult result = _controller.Create(_participant2, "test2", false) as RedirectToActionResult;
            Assert.Equal("Invite", result.ActionName);
        }
        #endregion

        #region HTTP GET Invite
        [Fact]
        public void InviteParticipantToGroup() {
            ViewResult result = _controller.Invite(_participant2, context.Groups.First().GroupId) as ViewResult;
            Assert.Equal("Invite", result?.ViewName);
        }
        #endregion

        #region HTTP POST Invite
        [Fact]
        public void InviteShouldReturnGroupSearchedById() {
            ViewResult result = _controller.Invite(_participant2, context.Groups.First().GroupId, "test.test@hogent.be") as ViewResult;
            Assert.Equal("Invite", result?.ViewName);
        }
        #endregion
    }
}
