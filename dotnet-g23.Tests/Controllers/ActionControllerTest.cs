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
    public class ActionControllerTest
    {
        #region Attributes
        private readonly ActionController _controller;
        private Participant _OwnerGranted;
        private Participant _OwnerAnnounced;
        private DummyApplicationDbContext context;
        #endregion

        #region Controller
        public ActionControllerTest() {
            context = new DummyApplicationDbContext();

            Mock<IParticipantRepository> PartRepo = new Mock<IParticipantRepository>();
        }
        #endregion
    }
}
