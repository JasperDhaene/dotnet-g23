using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.LabelViewModels;
using dotnet_g23.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace dotnet_g23.Tests.Controllers
{
    public class LabelControllerTest
    {
        #region Attributes
        private readonly LabelController _controller;
        private readonly Participant _ownerApproved;
        private DummyApplicationDbContext _context;
        #endregion

        #region Constructor
        public LabelControllerTest() {
            _context = new DummyApplicationDbContext();

            Mock<ICompanyRepository> compRepo = new Mock<ICompanyRepository>();
            Mock<IGroupRepository> groupRepo = new Mock<IGroupRepository>();

            compRepo.Setup(c => c.GetAll()).Returns(_context.Companies);
            compRepo.Setup(c => c.GetBy(1)).Returns(_context.Company1);
            compRepo.Setup(c => c.GetBy(2)).Returns(_context.Company2);
            compRepo.Setup(c => c.GetBy(3)).Returns(_context.Company3);

            groupRepo.Setup(g => g.GetAll()).Returns(_context.Groups);
            groupRepo.Setup(g => g.GetBy(1)).Returns(_context.HogentGroup);
            groupRepo.Setup(g => g.GetBy(2)).Returns(_context.HogentGroupSubmitted);
            groupRepo.Setup(g => g.GetBy(3)).Returns(_context.HogentGroupApproved);
            groupRepo.Setup(g => g.GetBy(4)).Returns(_context.HogentGroupGranted);
            groupRepo.Setup(g => g.GetBy(5)).Returns(_context.HogentGroupAnnounced);

            _controller = new LabelController(compRepo.Object, groupRepo.Object);

            _ownerApproved = _context.OwnerHogentApproved.UserState as Participant;
        }
        #endregion

        #region Index

        [Fact]
        public void UserCanSeeAllTheCompaniesInTheSystem() {
            ViewResult res = _controller.Index(_ownerApproved.User) as ViewResult;
            IndexViewModel vm = (IndexViewModel)res?.Model;
            Assert.Equal(_context.Companies, vm.Companies);
        }

        #endregion

        #region Show

        [Fact]
        public void ParticipantCanShowLabelForCompany() {
            ViewResult result = _controller.Show(_ownerApproved, 2) as ViewResult;
            ShowViewModel vm = (ShowViewModel)result?.Model;
            Assert.NotNull(vm.Label);
        }

        [Fact]
        public void ParticipantCanSeeTheCompanyNameAndItsContacts() {
            ViewResult result = _controller.Show(_ownerApproved, 2) as ViewResult;
            ShowViewModel vm = (ShowViewModel)result?.Model;
            Assert.Equal(_context.Company2, vm.Company);
            Assert.NotNull(vm.Contacts);
        }

        #endregion 
    }
}
