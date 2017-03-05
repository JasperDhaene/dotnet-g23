using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.OrganizationViewModels;
using dotnet_g23.Tests.Data;
using Moq;

namespace dotnet_g23.Tests.Controllers {
    public class OrganizationControllerTest
    {
        private readonly OrganizationController _controller;
        private readonly GUser _user;

        public OrganizationControllerTest() {
            DummyApplicationDbContext context = new DummyApplicationDbContext();

            Mock<IOrganizationRepository> repo = new Mock<IOrganizationRepository>();

            repo.Setup(o => o.GetAll()).Returns(context.Organizations);

            repo.Setup(o => o.GetBy(1)).Returns(context.org1);
            repo.Setup(o => o.GetBy(2)).Returns(context.org2);
            repo.Setup(o => o.GetBy(3)).Returns(context.org3);

            repo.Setup(o => o.GetByDomain("hogent.be")).Returns(context.org1);
            repo.Setup(o => o.GetBy(2)).Returns(context.org2);
            repo.Setup(o => o.GetBy(3)).Returns(context.org3);
        }
    }
}
