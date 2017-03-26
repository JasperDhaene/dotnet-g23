using dotnet_g23.Models.Domain;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class LabelTest
    {
        [Fact]
        public void ContstructorShouldCreateLabel() {
            Group group = new Group("OpenGroup");
            Company comp = new Company("foobar", "foobar", "foobar", "foobar.com", "foo@bar.com", new byte[] { 0x20, 0x20, 0x20 });
            Label label = new Label(group, comp);
            Assert.Equal(group, label.Group);
            Assert.Equal(comp, label.Company);
        }
    }
}
