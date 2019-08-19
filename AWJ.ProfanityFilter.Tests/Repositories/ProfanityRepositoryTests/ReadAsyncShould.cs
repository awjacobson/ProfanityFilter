using AWJ.ProfanityFilter.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AWJ.ProfanityFilter.Tests.Repositories.ProfanityRepositoryTests
{
    [TestClass]
    public class ReadAsyncShould
    {
        [TestMethod]
        public void SkipCommentLines()
        {
            // Arrange
            var repo = new ProfanityRepository();

            // Act
            var badwords = repo.ReadAsync(new Uri("http://www.aaronjacobson.com/badwords.txt")).Result;

            // Assert
            Assert.IsFalse(badwords.Any(l => l.StartsWith("#")));
        }
    }
}
