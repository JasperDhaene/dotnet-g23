using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Tests.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Tests.Controllers
{
    public class LabelControllerTest
    {
        private readonly LabelController _controller;
        private readonly Participant _ownerApproved;
        private DummyApplicationDbContext context;

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
    }
}
