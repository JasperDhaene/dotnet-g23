using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.GroupViewModels;
using dotnet_g23.Tests.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace dotnet_g23.Tests.Controllers {
    public class GroupControllerTest {

        #region Fields
        private readonly GroupController _controller;
        private DummyApplicationDbContext _context;
        private readonly Participant _participantHogent;
        private readonly Participant _ownerHogent;
        private readonly Participant _ownerGranted;
        #endregion

        #region Constructor
        public GroupControllerTest() {
            _context = new DummyApplicationDbContext();

            Mock<IGroupRepository> groupRepo = new Mock<IGroupRepository>();
            Mock<IParticipantRepository> participantRepo = new Mock<IParticipantRepository>();
            Mock<IInvitationRepository> invRepo = new Mock<IInvitationRepository>();
            Mock<ILabelRepository> lRepo = new Mock<ILabelRepository>();
            Mock<IPostRepository> postRepo = new Mock<IPostRepository>();
            Mock<IHostingEnvironment> hostEnv = new Mock<IHostingEnvironment>();

            groupRepo.Setup(g => g.GetAll()).Returns(_context.Groups);
            groupRepo.Setup(g => g.GetBy(1)).Returns(_context.HogentGroup);

            _controller = new GroupController(groupRepo.Object, participantRepo.Object, invRepo.Object, lRepo.Object, postRepo.Object);
            _controller.TempData = new Mock<ITempDataDictionary>().Object;

            _participantHogent = _context.ParticipantHogent.UserState as Participant;
            _ownerHogent = _context.OwnerHogent.UserState as Participant;
            _ownerGranted = _context.OwnerHogentGranted.UserState as Participant;
        }
        #endregion

        #region Index

        [Fact]
        public void IndexShouldReturnOrganizationOfUser() {
            ViewResult result = _controller.Index(_participantHogent) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            Assert.Equal(_participantHogent.Organization, ind.Organization);
        }

        [Fact]
        public void IndexShouldReturnSubscribedGroupOfUser() {
            ViewResult result = _controller.Index(_ownerHogent) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            Assert.Equal(_ownerHogent.Group, ind.SubscribedGroup);
        }

        [Fact]
        public void IndexNotEmptyInvitedGroupOfUser() {
            ViewResult result = _controller.Index(_participantHogent) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            IEnumerable<Group> groups = ind.InvitedGroups;
            Assert.Empty(groups);
        }

        [Fact]
        public void IndexShouldReturnPossibleOpenGroupsForUserSoNotNull() {
            ViewResult result = _controller.Index(_participantHogent) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            IEnumerable<Group> groups = ind.OpenGroups;
            Assert.NotNull(groups);
        }

        [Fact]
        public void IndexShouldReturnNullForSubscribedGroupOfUserParticipant() {
            ViewResult result = _controller.Index(_participantHogent) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            Assert.Null(ind.SubscribedGroup);
        }

        #endregion

        #region HTTP POST Create

        [Fact]
        public void ParticipantShouldCreateGroup() {
            _controller.Create(_participantHogent, "testGroup", false);
            Assert.Equal("testGroup", _participantHogent.Group.Name);
            Assert.False(_participantHogent.Group.Closed);
        }

        [Fact]
        public void ParticipantRedirectToInviteWhenCreatingGroup() {
            RedirectToActionResult res = _controller.Create(_participantHogent, "testGroup", false) as RedirectToActionResult;
            Assert.Equal("Invite", res.ActionName);
        }

        [Fact]
        public void ParticipantCannotCreateAndRedirectsToCreate() {
            ViewResult res = _controller.Create(_ownerHogent, "test", false) as ViewResult;
            Assert.Equal("Create", res.ViewName);
        }

        #endregion

        #region HTTP GET Show

        [Fact]
        public void ParticipantWithGroupCanSeeSubscribedGroup() {
            ViewResult result = _controller.Show(_ownerHogent, 1) as ViewResult;
            ShowViewModel vm = (ShowViewModel)result?.Model;
            Assert.Equal(_context.HogentGroup, vm.Group);
        }

        [Fact]
        public void ParticipantWithGroupCanSeeInvitationsForGroup() {
            ViewResult result = _controller.Show(_ownerHogent, 1) as ViewResult;
            ShowViewModel vm = (ShowViewModel)result?.Model;
            Assert.Equal(_context.HogentGroup.Invitations, vm.Invitations);
        }

        #endregion

        #region HTTP POST Register

        [Fact]
        public void ParticipantCanRegisterInGroup1() {
            _controller.Register(_participantHogent, 1);
            Assert.Equal(_context.HogentGroup, _participantHogent.Group);
        }

        [Fact]
        public void ParticipantShouldRedirectToIndexOfGroupsBecauseAlreadyInGroup() {
            RedirectToActionResult result = _controller
                .Register(_ownerHogent, 1)
                as RedirectToActionResult;
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void ParticipantShouldRegisterInGroupAndRedirectsToDashboard() {
            RedirectToActionResult result = _controller
                .Register(_participantHogent, 1)
                as RedirectToActionResult;
            Assert.Equal("Dashboard", result.ActionName);
        }

        #endregion

        #region HTTP POST Invite

        [Fact]
        public void InviteShouldRedirectToInviteOfController() {
            ViewResult result = _controller.Invite(_ownerHogent, 1, "participant@hogent.be") as ViewResult;
            Assert.Equal("Invite", result?.ViewName);
        }

        [Fact]
        public void InviteShouldRedirectToInviteOfControllerWhenAlreadyInGroup() {
            ViewResult result = _controller.Invite(_ownerHogent, 1, "owner_approved@hogent.be") as ViewResult;
            Assert.Equal("Invite", result?.ViewName);
        }

        #endregion

        #region HTTP GET Announce

        [Fact]
        public void ParticipantCanShowAnnounceForm() {
            ViewResult res = _controller.Announce(_ownerGranted, 4) as ViewResult;
            AnnounceViewModel vm = (AnnounceViewModel)res?.Model;
            Assert.Equal(_context.Label2, vm.Label);
            Assert.Equal("", vm.Message);
        }

        #endregion

    }
}
