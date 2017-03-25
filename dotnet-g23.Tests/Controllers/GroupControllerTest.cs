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

            ParticipantRepo.Setup(g => g.GetAll()).Returns(context.Participants);
            ParticipantRepo.Setup(g => g.GetBy(1)).Returns(context.ParticipantHogent.UserState as Participant);
            ParticipantRepo.Setup(g => g.GetBy(2)).Returns(context.OwnerHogent.UserState as Participant);

            _controller = new GroupController(GroupRepo.Object, ParticipantRepo.Object, InvRepo.Object, LRepo.Object, PostRepo.Object, HostEnv.Object);

            _ParticipantHogent = context.ParticipantHogent.UserState as Participant;
            _OwnerHogent = context.OwnerHogent.UserState as Participant;
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

        #region Show

        //[Fact]


        #endregion

        #region HTTP POST Register

        //[Fact]
        //public void ParticipantShouldRedirectToIndexOfGroupsBecauseAlreadyInGroup() {
        //    RedirectToActionResult result = _controller
        //        .Register(_participant, context.Groups.First().GroupId)
        //        as RedirectToActionResult;
        //    Assert.Equal("Index", result.ActionName);
        //}

        //[Fact]
        //public void ParticipantShouldRegisterInGroup() {
        //    RedirectToActionResult result = _controller
        //        .Register(_participant2, context.Groups.First().GroupId)
        //        as RedirectToActionResult;
        //    Assert.Equal("Index", result.ActionName);
        //}

        #endregion

        #region HTTP POST Invite
        //[Fact]
        //public void InviteShouldReturnGroupSearchedById() {
        //    ViewResult result = _controller.Invite(_participant2, context.Groups.First().GroupId, "test.test@hogent.be") as ViewResult;
        //    Assert.Equal("Invite", result?.ViewName);
        //}

        #endregion
    }
}
