using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        public void SaveScore_ShouldSaveUserNameAndUserScoreInFile()
        {
            //Arrange
            var expectedUserName = "Maciek";
            var expectedScore = 50;
            var expectedSeparator = "-";
            var expectedText = expectedUserName + expectedSeparator + expectedScore + Environment.NewLine;
                        
            //Act
            HighScore.SaveScore(expectedUserName, expectedScore);
            string text = File.ReadAllText(HighScore.HighScoreFilePath);

            //Assert
            Assert.AreEqual(expectedText, text);
        }

        [TestMethod]

        public void ReadTextFile_ShouldReturnEmptyDictionary()
        {
            //Arrange
            var file = File.CreateText(HighScore.HighScoreFilePath);
            file.Close();
            var expectedCount = 0;

            //Act
            var returnDict = HighScore.ReadTextFile().Count;
            
            //Assert
            Assert.AreEqual(expectedCount, returnDict);
        }
        [TestMethod]

        public void ReadTextFile_ShouldReturnDictionaryWithUserNameUserScore()
        {
            //Arrange
            var expectedUserName = "Maciek";
            var expectedScore = 50;

            var expecteddict = new Dictionary<string, List<int>>();
            var expectedListScore = new List<int>();

            expectedListScore.Add(expectedScore);
            expecteddict.Add(expectedUserName, expectedListScore);


            //Act
            HighScore.SaveScore(expectedUserName, expectedScore);
            var returnDict = HighScore.ReadTextFile();

            //Assert
            Assert.AreEqual(returnDict, expecteddict);
        }

    }
}
