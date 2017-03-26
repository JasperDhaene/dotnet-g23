using System;
using dotnet_g23.Models.Domain;
using Xunit;

namespace dotnet_g23.Tests.Models {
    public class MotivationTest {
        [Fact]
        public void MotivationHasValidMotivationText() {
            String text =
                "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed " +
                "doeiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enimad minim veniam";
            Motivation motivation = new Motivation(text);

            Assert.Equal(text, motivation.MotivationText);
        }

        [Fact]
        public void MotivationIsNotApprovedByDefault() {
            String text =
                "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed " +
                "doeiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enimad minim veniam";

            Motivation motivation = new Motivation(text);

            Assert.False(motivation.Approved);
        }
    }
}
