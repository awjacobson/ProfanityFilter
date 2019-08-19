using AWJ.ProfanityFilter.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AWJ.ProfanityFilter.Tests.Repositories.ProfanityRepositoryTests
{
    [TestClass]
    public class ParseLinesShould
    {
        [TestMethod]
        public void SkipCommentLines()
        {
            // Arrange
            var repo = new ProfanityRepository();
            var content = @"#I am a comment
# also a comment
### comment
porn";

            // Act
            var badwords = repo.ParseLines(content);

            // Assert
            Assert.IsFalse(badwords.Any(l => l.StartsWith("#")));
        }

        [TestMethod]
        public void Trim()
        {
            // Arrange
            var repo = new ProfanityRepository();
            var content = @" porn    
   porno     
   pornography   ";

            // Act
            var badwords = repo.ParseLines(content).ToList();

            // Assert
            Assert.AreEqual("porn", badwords[0]);
            Assert.AreEqual("porno", badwords[1]);
            Assert.AreEqual("pornography", badwords[2]);
        }

        [TestMethod]
        public void SkipBlankLines()
        {
            // Arrange
            var repo = new ProfanityRepository();
            var content = @"porn
         

pornography";

            // Act
            var badwords = repo.ParseLines(content).ToList();

            // Assert
            Assert.AreEqual("porn", badwords[0]);
            Assert.AreEqual("pornography", badwords[1]);
        }
    }
}
