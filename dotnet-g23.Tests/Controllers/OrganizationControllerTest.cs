//using dotnet_g23.Controllers;
//using dotnet_g23.Models.Domain;
//using dotnet_g23.Models.Domain.Repositories;
//using dotnet_g23.Models.ViewModels.OrganizationViewModels;
//using dotnet_g23.Tests.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Moq;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Xunit;

//namespace dotnet_g23.Tests.Controllers {
//    public class OrganizationControllerTest {
//        #region Attributes
//        private readonly OrganizationController _controller;
//        private readonly GUser _user1;
//        private readonly GUser _user2;
//        private DummyApplicationDbContext context;
//        #endregion

//        #region Constructor
//        public OrganizationControllerTest() {
//            context = new DummyApplicationDbContext();

//            Mock<IOrganizationRepository> repo = new Mock<IOrganizationRepository>();
//            Mock<IGroupRepository> Grepo = new Mock<IGroupRepository>();
//            Mock<IPostRepository> Prepo = new Mock<IPostRepository>();

//            repo.Setup(o => o.GetAll()).Returns(context.Organizations);

//            repo.Setup(o => o.GetBy(1)).Returns(context.org1);
//            repo.Setup(o => o.GetBy(2)).Returns(context.org2);
//            repo.Setup(o => o.GetBy(3)).Returns(context.org3);

//            repo.Setup(o => o.GetByDomain("hogent.be")).Returns(context.OrgsHogent);
//            repo.Setup(o => o.GetByDomain("howest.be")).Returns(context.OrgsHowest);
//            repo.Setup(o => o.GetByDomain("organization.be"))
//                .Returns(context.OrgsOrganization);

//            _controller = new OrganizationController(repo.Object, Grepo.Object, Prepo.Object);
//            _controller.TempData = new Mock<ITempDataDictionary>().Object;

//            _user1 = context.Preben;
//            _user2 = context.Tuur;

//        }
//        #endregion

//        #region Index

//        [Fact]
//        public void IndexGivenListOfPossibleOrganizationsWithUser1() {
//            ViewResult result = _controller.Index(_user1, _user1.UserState as Participant, null) as ViewResult;
//            IndexViewModel ind1 = (IndexViewModel)result?.Model;
//            IEnumerable<Organization> orgResult = ind1.Organizations;
//            Assert.False(orgResult?.Count() == 0);
//        }

//        [Fact]
//        public void IndexGivenListOfPossibleOrganizationsWithUser2() {
//            ViewResult result = _controller.Index(_user2, _user2.UserState as Participant, null) as ViewResult;
//            IndexViewModel ind2 = (IndexViewModel)result?.Model;
//            IEnumerable<Organization> orgResult = ind2.Organizations;
//            Assert.False(orgResult?.Count() == 0);
//        }

//        [Fact]
//        public void IndexShouldGiveEmptySubscribedOrganizationForUser1() {
//            ViewResult result = _controller.Index(_user1, _user1.UserState as Participant, null) as ViewResult;
//            IndexViewModel ind1 = (IndexViewModel)result?.Model;
//            Assert.Equal(null, ind1.SubscribedOrganization);
//        }

//        [Fact]
//        public void IndexShouldGiveSubscribedOrganizationForUser2() {
//            ViewResult result = _controller.Index(_user2, _user2.UserState as Participant, null) as ViewResult;
//            IndexViewModel ind2 = (IndexViewModel)result?.Model;
//            Assert.Equal(context.org3, ind2.SubscribedOrganization);
//        }

//        #endregion

//        #region Register Post

//        [Fact]
//        public void RegisterShouldRedirectToActionForUser1RegisterToOrganizationAfterRegistration() {
//            RedirectToActionResult result = _controller.Register(_user1, context.org1.OrganizationId) as RedirectToActionResult;
//            Assert.Equal("Index", result?.ActionName);
//            Assert.Equal("Organizations", result?.ControllerName);
//        }

//        [Fact]
//        public void RegisterShouldRedirectToActionForUser2RegisterToOrganizationWhenAlreadyInOrganization() {
//            RedirectToActionResult result = _controller.Register(_user2, context.org3.OrganizationId) as RedirectToActionResult;
//            Assert.Equal("Index", result.ActionName);
//            Assert.Equal("Organizations", result.ControllerName);
//        }
//        #endregion
//    }
//}