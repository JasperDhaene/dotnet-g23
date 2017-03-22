using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_g23.Tests.Models {
    public class ActionTest {
        [Fact]
        public void ConstructorShouldCreateNewAction() {
            Group group = new Group("open");
            dotnet_g23.Models.Domain.Action action = new dotnet_g23.Models.Domain.Action(group, "Foobar", "Foobar");
            Assert.Null(action.Date);
            Assert.Equal(group, action.Group);
        }

        [Fact]
        public void ConstructorShouldCreateNewEvent() {
            Group group = new Group("open");
            DateTime time = new DateTime(2017, 03, 23);
            dotnet_g23.Models.Domain.Action action = new dotnet_g23.Models.Domain.Action(group, "Foobar", "Foobar", time);
            Assert.Equal(time, action.Date);
        }

        [Fact]
        public void ConstructorShouldThrowExceptionOnWrongDescription() {
            Group group = new Group("open");
            Assert.Throws<GoedBezigException>(() => new dotnet_g23.Models.Domain.Action(group, "Foobar", "    "));
            
        }
    }
}
