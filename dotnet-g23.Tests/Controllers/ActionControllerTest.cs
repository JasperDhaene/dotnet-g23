using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.ActionViewModels;
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
    public class ActionControllerTest
    {
        #region Attributes
        private readonly ActionController _controller;
        private Participant _OwnerGranted;
        private Participant _OwnerAnnounced;
        private DummyApplicationDbContext context;
        #endregion

        #region Controller
        public ActionControllerTest() {
            context = new DummyApplicationDbContext();

            Mock<IParticipantRepository> PartRepo = new Mock<IParticipantRepository>();
            Mock<IGroupRepository> GroupRepo = new Mock<IGroupRepository>();

            GroupRepo.Setup(g => g.GetAll()).Returns(context.Groups);
            GroupRepo.Setup(g => g.GetBy(1)).Returns(context.HogentGroup);
            GroupRepo.Setup(g => g.GetBy(2)).Returns(context.HogentGroupSubmitted);
            GroupRepo.Setup(g => g.GetBy(3)).Returns(context.HogentGroupApproved);
            GroupRepo.Setup(g => g.GetBy(4)).Returns(context.HogentGroupGranted);
            GroupRepo.Setup(g => g.GetBy(5)).Returns(context.HogentGroupAnnounced);

            _controller = new ActionController(PartRepo.Object, GroupRepo.Object);
            _controller.TempData = new Mock<ITempDataDictionary>().Object;

            _OwnerGranted = context.OwnerHogentGranted.UserState as Participant;
            _OwnerAnnounced = context.OwnerHogentAnnounced.UserState as Participant;
        }
        #endregion

        #region Update

        [Fact]
        public void ParticipantCanUpdateActionAndRedirectToShow() {
            RedirectToActionResult res = _controller.Update(_OwnerGranted, 4, context.Action1) as RedirectToActionResult;
            Assert.Equal("Show", res?.ActionName);
            Assert.Equal("Group", res?.ControllerName);
        }

        #endregion
    }
}
