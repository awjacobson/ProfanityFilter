using AWJ.ProfanityFilter.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWJ.ProfanityFilter.Tests.Services.ProfanityServiceTests
{
    [TestClass]
    public class HasUrlShould
    {
        [TestMethod]
        public void ReturnTrueWhenUrlFound()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasUrl("click this http://www.foufos.gr/kino");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ReturnFalseWhenUrlNotFound()
        {
            // Arrange
            var badwords = new[] { "porn" };
            var service = new ProfanityService(badwords);

            // Act
            var actual = service.HasUrl("click this link");

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
