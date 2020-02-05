using AWJ.ProfanityFilter.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AWJ.ProfanityFilter.Tests.Services.ProfanityServiceTests
{
    [TestClass]
    public class HasUrlShould
    {
        [TestMethod]
        public void ReturnTrueWhenUrlFound()
        {
            // Act
            var actual = ProfanityService.HasUrl("click this http://www.foufos.gr/kino");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ReturnFalseWhenUrlNotFound()
        {
            // Act
            var actual = ProfanityService.HasUrl("click this link");

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
