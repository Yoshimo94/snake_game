using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Snake.Tests
{
    [TestClass]
    public class HighScoreTests
    {
        [TestInitialize]
        public void ConfigureTestEnvironment()
        {
            if (File.Exists(HighScore.HighScoreFilePath))
            {
                File.Delete(HighScore.HighScoreFilePath);
            }
        }

        [TestMethod]
        public void SaveScore_ShouldSaveUserNameInFile()
        {
            //Arrange
            var userName = "Maciek";
            var expectedText = userName + Environment.NewLine;
                        
            //Act
            HighScore.SaveScore(userName);
            string text = File.ReadAllText(HighScore.HighScoreFilePath);

            //Assert
            Assert.AreEqual(expectedText, text);
        }
    }
}
