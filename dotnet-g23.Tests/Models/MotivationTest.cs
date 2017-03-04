using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public void MotivationThrowsExceptionOnToShortMotivationText() {
            // < 99 chars
            String text = "Lorem ipsum dolor sit amet";

            Assert.Throws<ArgumentException>(() => new Motivation(text));

        }

        public void MotivationThrowsExceptionOnShortMotivationText() {
            // 99 chars
            String text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed doeiusmod tempor incididunt ut labore";

            Assert.Throws<ArgumentException>(() => new Motivation(text));
        }

        [Fact]
        public void MotivationThrowsExceptionOnToLongMotivationText() {
            // > 250 chars
            String text =
                "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed doeiusmod tempor incididunt " +
                "ut labore et dolore magna aliqua. Ut enimad minim veniam, quis nostrud exercitation ullamco " +
                "laboris nisi utaliquip ex ea commodo consequat. Duis aute irure dolor inreprehenderit";

            Assert.Throws<ArgumentException>(() => new Motivation(text));
        }

        [Fact]
        public void MotivationThrowsExceptionOnLongMotivationText() {

            // 251 chars
            String text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed doeiusmod tempor incididunt " +
                   "ut labore et dolore magna aliqua. Ut enimad minim veniam, quis nostrud exercitation ullamco " +
                   "laboris nisi utaliquip ex ea commodo consequat. Duis aute irure dolo";

            Assert.Throws<ArgumentException>(() => new Motivation(text));
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
