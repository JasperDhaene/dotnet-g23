using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.OrganizationViewModels;
using Moq;

namespace dotnet_g23.Tests.Controllers {
    public class OrganizationControllerTest
    {
        private OrganizationController _controller;
        private GUser _user;
        private Mock<IOrganizationRepository> _mockOrgRepo;
        private IndexViewModel _model;
        private IndexViewModel _modelMetFout;

        public OrganizationControllerTest() {

        }
    }
}
