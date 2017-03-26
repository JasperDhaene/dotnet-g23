using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.MotivationViewModels;
using dotnet_g23.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace dotnet_g23.Tests.Controllers {
    public class MotivationControllerTest {
        #region Attributes
        private readonly MotivationController _controller;
        private DummyApplicationDbContext _context;
        private readonly Participant _ownerHogent;
        private readonly Participant _ownerHogentSubmitted;
        #endregion

        #region Constructor
        public MotivationControllerTest() {
            _context = new DummyApplicationDbContext();

            Mock<IGroupRepository> groupRepo = new Mock<IGroupRepository>();
            
            groupRepo.Setup(g => g.GetAll()).Returns(_context.Groups);
            groupRepo.Setup(g => g.GetBy(1)).Returns(_context.HogentGroup);
            groupRepo.Setup(o => o.GetBy(2)).Returns(_context.HogentGroupSubmitted);
            groupRepo.Setup(g => g.GetBy(3)).Returns(_context.HogentGroupApproved);
            groupRepo.Setup(o => o.GetBy(4)).Returns(_context.HogentGroupGranted);
            groupRepo.Setup(g => g.GetBy(5)).Returns(_context.HogentGroupAnnounced);

            _controller = new MotivationController(groupRepo.Object);
            _controller.TempData = new Mock<ITempDataDictionary>().Object;

            _ownerHogent = _context.OwnerHogent.UserState as Participant;
            _ownerHogentSubmitted = _context.OwnerHogentSubmitted.UserState as Participant;
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
            Assert.Equal(_context.MotivationSubmitted.MotivationText, vm.Motivation.MotivationText);
        }

        #endregion

    }
}