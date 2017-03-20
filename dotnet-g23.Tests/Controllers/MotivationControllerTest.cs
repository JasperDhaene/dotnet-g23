//using dotnet_g23.Controllers;
//using dotnet_g23.Models.Domain;
//using dotnet_g23.Models.Domain.Repositories;
//using dotnet_g23.Models.ViewModels.MotivationViewModels;
//using dotnet_g23.Tests.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Moq;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Xunit;

//namespace dotnet_g23.Tests.Controllers {
//    public class MotivationControllerTest {
//        #region Attributes
//        private readonly MotivationController _controller;
//        private readonly Participant _user1;
//        private readonly Participant _user2;
//        private DummyApplicationDbContext context;
//        #endregion

//        #region Constructor
//        public MotivationControllerTest() {
//            context = new DummyApplicationDbContext();

//            Mock<IGroupRepository> GroupRepo = new Mock<IGroupRepository>();

//            GroupRepo.Setup(g => g.GetAll()).Returns(context.Groups);
//            GroupRepo.Setup(g => g.GetBy(0)).Returns(context.Groups.First());
//            GroupRepo.Setup(o => o.GetBy(1)).Returns(context.Groups.Skip(1).First());
//            GroupRepo.Setup(g => g.GetByName("OpenGroup")).Returns(context.Groups.First());

//            _controller = new MotivationController(GroupRepo.Object);
//            _controller.TempData = new Mock<ITempDataDictionary>().Object;

//            _user1 = context.Preben2.UserState as Participant;
//            _user2 = context.Tuur.UserState as Participant;
//        }
//        #endregion

//        #region Show

//        [Fact]
//        public void ShowShouldShowGroupOfParticipant() {
//            ViewResult result = _controller.Show(_user2, 1) as ViewResult;
//            IndexViewModel vm = (IndexViewModel)result?.Model;
//            Assert.NotNull(vm?.Group);
//        }

//        #endregion

//        #region Update

//        [Fact]
//        public void UpdateShouldShowDetailsOfGroupWithUpdatedMotivation() {
//            RedirectToActionResult result = _controller
//                .Update(_user1, 1, context.Motivation) as RedirectToActionResult;
//            Assert.Equal("Show", result?.ActionName);
//            Assert.Equal("Group", result?.ControllerName);
//        }

//        #endregion
//    }
//}