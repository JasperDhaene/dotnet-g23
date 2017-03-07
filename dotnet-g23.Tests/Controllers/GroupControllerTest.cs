using dotnet_g23.Controllers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Tests.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_g23.Tests.Controllers
{
    public class GroupControllerTest
    {
        private readonly GroupController _controller;
        private readonly Participant _participant;
        private DummyApplicationDbContext context;

        public GroupControllerTest() {
            context = new DummyApplicationDbContext();

            Mock<IUserRepository> Userrepo = new Mock<IUserRepository>();
            Mock<IGroupRepository> Grouprepo = new Mock<IGroupRepository>();

            Grouprepo.Setup(o => o.GetAll()).Returns(context.Groups);

            Grouprepo.Setup(o => o.GetBy(1)).Returns(context.Groups.First());
            Grouprepo.Setup(o => o.GetBy(1)).Returns(context.Groups.Skip(1).First());

            _controller = new GroupController(Grouprepo.Object, Userrepo.Object);
            _controller.TempData = new Mock<ITempDataDictionary>().Object;

            _participant = context.Tuur.UserState as Participant;
        }
    }
}
