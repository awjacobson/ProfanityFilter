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
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasNonEnglish("this text should be okay");

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ReturnTrueWhenCryllic()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasNonEnglish("Регистрация");

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
