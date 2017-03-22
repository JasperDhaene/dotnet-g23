using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.OrganizationViewModels;
using dotnet_g23.Tests.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace dotnet_g23.Tests.Controllers {
    public class OrganizationControllerTest {
        #region Attributes
        private readonly OrganizationController _controller;
        private DummyApplicationDbContext _context;
        private readonly GUser _user1;
        private readonly GUser _user2;
        
        #endregion

        #region Constructor
        public OrganizationControllerTest() {
            _context = new DummyApplicationDbContext();

            Mock<UserManager<ApplicationUser>> userMan = new Mock<UserManager<ApplicationUser>>();
            Mock<SignInManager<ApplicationUser>> signMan = new Mock<SignInManager<ApplicationUser>>();
            Mock<IOrganizationRepository> repo = new Mock<IOrganizationRepository>();
            Mock<IGroupRepository> Grepo = new Mock<IGroupRepository>();
            Mock<IPostRepository> Prepo = new Mock<IPostRepository>();

            repo.Setup(o => o.GetAll()).Returns(_context.Organizations);

            repo.Setup(o => o.GetBy(1)).Returns(_context.HogentGent);
            repo.Setup(o => o.GetBy(2)).Returns(_context.HogentAalst);
            repo.Setup(o => o.GetBy(3)).Returns(_context.HowestKortrijk);
            repo.Setup(o => o.GetBy(4)).Returns(_context.HowestBrugge);
            repo.Setup(o => o.GetBy(5)).Returns(_context.Ugent);

            Grepo.Setup(o => o.GetAll()).Returns(_context.Groups);

            Grepo.Setup(o => o.GetBy(1)).Returns(_context.HogentGroup);
            Grepo.Setup(o => o.GetBy(2)).Returns(_context.HogentGroupSubmitted);
            Grepo.Setup(o => o.GetBy(3)).Returns(_context.HogentGroupApproved);
            Grepo.Setup(o => o.GetBy(4)).Returns(_context.HogentGroupGranted);
            Grepo.Setup(o => o.GetBy(5)).Returns(_context.HogentGroupAnnounced);

            _controller = new OrganizationController(userMan.Object, signMan.Object, repo.Object, Grepo.Object, Prepo.Object);
            _controller.TempData = new Mock<ITempDataDictionary>().Object;

            

        }
        #endregion

        #region Index
        
        #endregion
    }
}