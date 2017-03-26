using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.LabelViewModels;
using dotnet_g23.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_g23.Tests.Controllers
{
    public class LabelControllerTest
    {
        #region Attributes
        private readonly LabelController _controller;
        private readonly Participant _ownerApproved;
        private DummyApplicationDbContext context;
        #endregion

        #region Constructor
        public LabelControllerTest() {
            context = new DummyApplicationDbContext();

            Mock<ICompanyRepository> compRepo = new Mock<ICompanyRepository>();
            Mock<IGroupRepository> groupRepo = new Mock<IGroupRepository>();

            compRepo.Setup(c => c.GetAll()).Returns(context.Companies);
            compRepo.Setup(c => c.GetBy(1)).Returns(context.Company1);
            compRepo.Setup(c => c.GetBy(2)).Returns(context.Company2);
            compRepo.Setup(c => c.GetBy(3)).Returns(context.Company3);

            groupRepo.Setup(g => g.GetAll()).Returns(context.Groups);
            groupRepo.Setup(g => g.GetBy(1)).Returns(context.HogentGroup);
            groupRepo.Setup(g => g.GetBy(2)).Returns(context.HogentGroupSubmitted);
            groupRepo.Setup(g => g.GetBy(3)).Returns(context.HogentGroupApproved);
            groupRepo.Setup(g => g.GetBy(4)).Returns(context.HogentGroupGranted);
            groupRepo.Setup(g => g.GetBy(5)).Returns(context.HogentGroupAnnounced);

            _controller = new LabelController(compRepo.Object, groupRepo.Object);

            _ownerApproved = context.OwnerHogentApproved.UserState as Participant;
        }
        #endregion

        #region Index

        [Fact]
        public void UserCanSeeAllTheCompaniesInTheSystem() {
            ViewResult res = _controller.Index(_ownerApproved.User) as ViewResult;
            IndexViewModel vm = (IndexViewModel)res?.Model;
            Assert.Equal(context.Companies, vm.Companies);
        }

        #endregion

        #region Show

        [Fact]
        public void ParticipantCanShowDetailsOfCompany() {
            ViewResult result = _controller.Show(_ownerApproved, 1) as ViewResult;
            ShowViewModel vm = (ShowViewModel)result?.Model;
            Assert.Equal(context.Company1, vm.Company);
            Assert.Equal(context.Company1.Contacts, vm.Contacts);

        }

        #endregion 
    }
}
