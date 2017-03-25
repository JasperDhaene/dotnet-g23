using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.GroupViewModels;
using dotnet_g23.Tests.Data;
using Microsoft.AspNetCore.Hosting;
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
        private readonly Participant _ParticipantHogent;
        private readonly Participant _OwnerHogent;
        private DummyApplicationDbContext context;
        #endregion

        #region Constructor
        public GroupControllerTest() {
            context = new DummyApplicationDbContext();

            Mock<IGroupRepository> GroupRepo = new Mock<IGroupRepository>();
            Mock<IParticipantRepository> ParticipantRepo = new Mock<IParticipantRepository>();
            Mock<IInvitationRepository> InvRepo = new Mock<IInvitationRepository>();
            Mock<ILabelRepository> LRepo = new Mock<ILabelRepository>();
            Mock<IPostRepository> PostRepo = new Mock<IPostRepository>();
            Mock<IHostingEnvironment> HostEnv = new Mock<IHostingEnvironment>();

            GroupRepo.Setup(g => g.GetAll()).Returns(context.Groups);
            GroupRepo.Setup(g => g.GetBy(1)).Returns(context.HogentGroup);
            GroupRepo.Setup(g => g.GetBy(2)).Returns(context.HogentGroupSubmitted);
            GroupRepo.Setup(g => g.GetBy(3)).Returns(context.HogentGroupApproved);
            GroupRepo.Setup(g => g.GetBy(4)).Returns(context.HogentGroupGranted);
            GroupRepo.Setup(g => g.GetBy(5)).Returns(context.HogentGroupAnnounced);

            ParticipantRepo.Setup(g => g.GetAll()).Returns(context.Participants);
            GroupRepo.Setup(g => g.GetBy(1)).Returns(context.HogentGroup);
            GroupRepo.Setup(g => g.GetBy(2)).Returns(context.HogentGroupSubmitted);
            GroupRepo.Setup(g => g.GetBy(3)).Returns(context.HogentGroupApproved);
            GroupRepo.Setup(g => g.GetBy(4)).Returns(context.HogentGroupGranted);
            GroupRepo.Setup(g => g.GetBy(5)).Returns(context.HogentGroupAnnounced);

            _controller = new GroupController(Grouprepo.Object, ParticipantRepo.Object, InvRepo.Object, LRepo.Object, PostRepo.Object, HostEnv.Object);
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
        public void IndexNotNullInvitedGroupOfUser() {
            ViewResult result = _controller.Index(_participant) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            IEnumerable<Group> groups = ind.InvitedGroups;
            Assert.NotNull(groups);
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
            Assert.Equal("Index", result.ActionName);
        }

        #endregion

        #region HTTP POST Create
        [Fact]
        public void ParticipantShouldCreateGroup() {
            RedirectToActionResult result = _controller.Create(_participant, "testGroup", true) as RedirectToActionResult;
            Assert.Equal("Invite", result.ActionName);
        }

        [Fact]
        public void ParticipantCannotCreateGroupBecauseAlreadyInGroupAndRedirectToIndex() {
            RedirectToActionResult result = _controller.Create(_participant2, "test2", false) as RedirectToActionResult;
            Assert.Equal("Index", result.ActionName);
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
