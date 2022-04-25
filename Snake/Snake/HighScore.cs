using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class HighScore
    {
        public static string HighScoreFilePath { get; set; } = @"highscore.txt";


        public static void SaveScore(string userName)
        {
            StreamWriter highScore;

            if (!File.Exists(HighScoreFilePath))
            {
                highScore = File.CreateText(HighScoreFilePath);
            }
            else
            {
                highScore = new StreamWriter(HighScoreFilePath, true);
            }
            highScore.WriteLine(userName);
            highScore.Close();
        }

    }
}
