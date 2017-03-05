using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.OrganizationViewModels;
using dotnet_g23.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace dotnet_g23.Tests.Controllers {
    public class OrganizationControllerTest
    {
        #region Attributes
        private readonly OrganizationController _controller;
        private readonly GUser _user1;
        private readonly GUser _user2;
        private DummyApplicationDbContext context;
        #endregion

        #region Constructor
        public OrganizationControllerTest() {
            context = new DummyApplicationDbContext();

            Mock<IOrganizationRepository> repo = new Mock<IOrganizationRepository>();

            repo.Setup(o => o.GetAll()).Returns(context.Organizations);

            repo.Setup(o => o.GetBy(1)).Returns(context.org1);
            repo.Setup(o => o.GetBy(2)).Returns(context.org2);
            repo.Setup(o => o.GetBy(3)).Returns(context.org3);

            repo.Setup(o => o.GetByDomain("hogent.be")).Returns(context.OrgsHogent);
            repo.Setup(o => o.GetByDomain("howest.be")).Returns(context.OrgsHowest);
            repo.Setup(o => o.GetByDomain("organization.be"))
                .Returns(context.OrgsOrganization);

            _controller = new OrganizationController(repo.Object);
            _user1 = context.Preben;
            _user2 = context.Tuur;
            
        }
        #endregion

        #region Index
        [Fact]
        public void IndexGivenListOfPossibleOrganizationsWithUser1() {
            ViewResult result = _controller.Index(_user1) as ViewResult;
            IndexViewModel ind1 = (IndexViewModel)result?.Model;
            IEnumerable<Organization> orgResult = ind1.Organizations;
            Assert.Equal(1, orgResult?.Count());
            Assert.False(orgResult?.Count() == 0);
        }

        [Fact]
        public void IndexGivenEmptyListOfPossibleOrganizationsWithUser2() {
            ViewResult result = _controller.Index(_user2) as ViewResult;
            IndexViewModel ind2 = (IndexViewModel)result?.Model;
            IEnumerable<Organization> orgResult = ind2.Organizations;
            Assert.Equal(0, orgResult?.Count());
            Assert.Empty(orgResult);
        }

        [Fact]
        public void IndexShouldGiveEmptySubscribedOrganizationForUser1() {
            ViewResult result = _controller.Index(_user1) as ViewResult;
            IndexViewModel ind1 = (IndexViewModel)result?.Model;
            Assert.Equal(null, ind1.SubscribedOrganization);
        }

        [Fact]
        public void IndexShouldGiveSubscribedOrganizationForUser2() {
            ViewResult result = _controller.Index(_user2) as ViewResult;
            IndexViewModel ind2 = (IndexViewModel)result?.Model;
            Assert.Equal(context.org3, ind2.SubscribedOrganization);
        }
        #endregion
    }
}
