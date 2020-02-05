using AWJ.ProfanityFilter.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AWJ.ProfanityFilter.Tests.Services.ProfanityServiceTests
{
    [TestClass]
    public class HasNonEnglishShould
    {
        [TestMethod]
        public void ReturnFalseWhenEnglish()
        {
            // Act
            var actual = ProfanityService.HasNonEnglish("this text should be okay");

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ReturnTrueWhenCryllic()
        {
            // Act
            var actual = ProfanityService.HasNonEnglish("Регистрация");

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
