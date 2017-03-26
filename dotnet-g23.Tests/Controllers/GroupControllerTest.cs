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
        private DummyApplicationDbContext context;
        private readonly Participant _ParticipantHogent;
        private readonly Participant _OwnerHogent;
        private readonly Participant _OwnerGranted;
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

            _controller = new GroupController(GroupRepo.Object, ParticipantRepo.Object, InvRepo.Object, LRepo.Object, PostRepo.Object, HostEnv.Object);
            _controller.TempData = new Mock<ITempDataDictionary>().Object;

            _ParticipantHogent = context.ParticipantHogent.UserState as Participant;
            _OwnerHogent = context.OwnerHogent.UserState as Participant;
            _OwnerGranted = context.OwnerHogentGranted.UserState as Participant;
        }
        #endregion

        #region Index

        [Fact]
        public void IndexShouldReturnOrganizationOfUser() {
            ViewResult result = _controller.Index(_ParticipantHogent) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            Assert.Equal(_ParticipantHogent.Organization, ind.Organization);
        }

        [Fact]
        public void IndexShouldReturnSubscribedGroupOfUser() {
            ViewResult result = _controller.Index(_OwnerHogent) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            Assert.Equal(_OwnerHogent.Group, ind.SubscribedGroup);
        }

        [Fact]
        public void IndexNotEmptyInvitedGroupOfUser() {
            ViewResult result = _controller.Index(_ParticipantHogent) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            IEnumerable<Group> groups = ind.InvitedGroups;
            Assert.Empty(groups);
        }

        [Fact]
        public void IndexShouldReturnPossibleOpenGroupsForUserSoNotNull() {
            ViewResult result = _controller.Index(_ParticipantHogent) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            IEnumerable<Group> groups = ind.OpenGroups;
            Assert.NotNull(groups);
        }

        [Fact]
        public void IndexShouldReturnNullForSubscribedGroupOfUserParticipant() {
            ViewResult result = _controller.Index(_ParticipantHogent) as ViewResult;
            IndexViewModel ind = (IndexViewModel)result?.Model;
            Assert.Null(ind.SubscribedGroup);
        }

        #endregion

        #region HTTP POST Create

        [Fact]
        public void ParticipantShouldCreateGroup() {
            _controller.Create(_ParticipantHogent, "testGroup", false);
            Assert.Equal("testGroup", _ParticipantHogent.Group.Name);
            Assert.False(_ParticipantHogent.Group.Closed);
        }

        [Fact]
        public void ParticipantRedirectToInviteWhenCreatingGroup() {
            RedirectToActionResult res = _controller.Create(_ParticipantHogent, "testGroup", false) as RedirectToActionResult;
            Assert.Equal("Invite", res.ActionName);
        }

        [Fact]
        public void ParticipantCannotCreateAndRedirectsToCreate() {
            ViewResult res = _controller.Create(_OwnerHogent, "test", false) as ViewResult;
            Assert.Equal("Create", res.ViewName);
        }

        #endregion

        #region HTTP GET Show

        [Fact]
        public void ParticipantWithGroupCanSeeSubscribedGroup() {
            ViewResult result = _controller.Show(_OwnerHogent, 1) as ViewResult;
            ShowViewModel vm = (ShowViewModel)result?.Model;
            Assert.Equal(context.HogentGroup, vm.Group);
        }

        [Fact]
        public void ParticipantWithGroupCanSeeInvitationsForGroup() {
            ViewResult result = _controller.Show(_OwnerHogent, 1) as ViewResult;
            ShowViewModel vm = (ShowViewModel)result?.Model;
            Assert.Equal(context.HogentGroup.Invitations, vm.Invitations);
        }

        #endregion

        #region HTTP POST Register

        [Fact]
        public void ParticipantCanRegisterInGroup1() {
            _controller.Register(_ParticipantHogent, 1);
            Assert.Equal(context.HogentGroup, _ParticipantHogent.Group);
        }

        [Fact]
        public void ParticipantShouldRedirectToIndexOfGroupsBecauseAlreadyInGroup() {
            RedirectToActionResult result = _controller
                .Register(_OwnerHogent, 1)
                as RedirectToActionResult;
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void ParticipantShouldRegisterInGroupAndRedirectsToDashboard() {
            RedirectToActionResult result = _controller
                .Register(_ParticipantHogent, 1)
                as RedirectToActionResult;
            Assert.Equal("Dashboard", result.ActionName);
        }

        #endregion

        #region HTTP POST Invite

        [Fact]
        public void InviteShouldRedirectToInviteOfController() {
            ViewResult result = _controller.Invite(_OwnerHogent, 1, "participant@hogent.be") as ViewResult;
            Assert.Equal("Invite", result?.ViewName);
        }

        [Fact]
        public void InviteShouldRedirectToInviteOfControllerWhenAlreadyInGroup() {
            ViewResult result = _controller.Invite(_OwnerHogent, 1, "owner_approved@hogent.be") as ViewResult;
            Assert.Equal("Invite", result?.ViewName);
        }

        #endregion

        #region HTTP GET Announce

        [Fact]
        public void ParticipantCanShowAnnounceForm() {
            ViewResult res = _controller.Announce(_OwnerGranted, 4) as ViewResult;
            AnnounceViewModel vm = (AnnounceViewModel)res?.Model;
            Assert.Equal(context.Label2, vm.Label);
            Assert.Equal("", vm.Message);
        }

        #endregion

    }
}
