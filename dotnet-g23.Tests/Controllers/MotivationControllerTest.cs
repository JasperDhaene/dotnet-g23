using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.MotivationViewModels;
using dotnet_g23.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace dotnet_g23.Tests.Controllers {
    public class MotivationControllerTest {
        #region Attributes
        private readonly MotivationController _controller;
        private DummyApplicationDbContext context;
        private readonly Participant _ownerHogent;
        private readonly Participant _ownerHogentSubmitted;
        #endregion

        #region Constructor
        public MotivationControllerTest() {
            context = new DummyApplicationDbContext();

            Mock<IGroupRepository> GroupRepo = new Mock<IGroupRepository>();

            GroupRepo.Setup(g => g.GetAll()).Returns(context.Groups);
            GroupRepo.Setup(g => g.GetBy(1)).Returns(context.HogentGroup);
            GroupRepo.Setup(o => o.GetBy(2)).Returns(context.HogentGroupSubmitted);
            GroupRepo.Setup(g => g.GetBy(3)).Returns(context.HogentGroupApproved);
            GroupRepo.Setup(o => o.GetBy(4)).Returns(context.HogentGroupGranted);
            GroupRepo.Setup(g => g.GetBy(5)).Returns(context.HogentGroupAnnounced);

            _controller = new MotivationController(GroupRepo.Object);
            _controller.TempData = new Mock<ITempDataDictionary>().Object;

            _ownerHogent = context.OwnerHogent.UserState as Participant;
            _ownerHogentSubmitted = context.OwnerHogentSubmitted.UserState as Participant;
        }
        #endregion

        #region Edit - GET

        [Fact]
        public void ParticipantWhereGroupHasNoMotivationCanCreateNewMotivationBecauseIsEmpty() {
            ViewResult result = _controller.Edit(_ownerHogent, 1) as ViewResult;
            ShowViewModel vm = (ShowViewModel)result?.Model;
            Assert.Null(vm.Motivation.MotivationText);
        }

        [Fact]
        public void ViewmodelShouldReturnGroupOfParticipant() {
            ViewResult result = _controller.Edit(_ownerHogent, 1) as ViewResult;
            ShowViewModel vm = (ShowViewModel)result?.Model;
            Assert.Equal(_ownerHogent.Group, vm.Group);
        }

        [Fact]
        public void ParticipantWhereGroupHasMotivationCanShowMotivation() {
            ViewResult result = _controller.Edit(_ownerHogentSubmitted, 2) as ViewResult;
            ShowViewModel vm = (ShowViewModel)result?.Model;
            Assert.Equal(context.MotivationSubmitted.MotivationText, vm.Motivation.MotivationText);
        }

        #endregion

        #region Update - Post

        //[Fact]
        //public void UpdateCanSubmitOrSaveMotivationSoSystemRedirectsToDashboardOfGroup() {
        //    Motivation mot = new Motivation("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. "
        //        +"Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque.");
        //    RedirectToActionResult result = _controller.Update(_ownerHogent, 1, mot) as RedirectToActionResult;
        //    Assert.Equal("Dashboard", result?.ActionName);
        //    Assert.Equal("Group", result?.ControllerName);
        //}

        #endregion
    }
}