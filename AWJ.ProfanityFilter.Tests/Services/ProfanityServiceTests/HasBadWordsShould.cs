using AWJ.ProfanityFilter.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AWJ.ProfanityFilter.Tests.Services.ProfanityServiceTests
{
    [TestClass]
    public class HasBadWordsShould
    {
        [TestMethod]
        public void HandleSpaceBeforeAndAfter()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasBadWords(" porn ");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HandleSpaceBeforeOnly()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasBadWords("bad is porn");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HandleSpaceAfterOnly()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasBadWords("porn is bad");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HandleWordByItself()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasBadWords("porn");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IgnoreCase()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasBadWords("Porn");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void z()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasBadWords("porn is first word");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void z1()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasBadWords("last word is porn");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Hyphenated()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasBadWords("porn-ish");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Embedded()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasBadWords("notpornisit");

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
