using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class GBOrganizationTest
    {
        [Fact]
        public void CreateGroupShouldCreateNewGroup()
        {
            GBOrganization g = new GBOrganization();
            g.CreateGroup("NewGroup");
            Assert.Equal(1, g.Groups.Count);
            Assert.Equal("NewGroup", g.Groups.OfType<Group>()
                .FirstOrDefault().Name);
        }
    }
}
