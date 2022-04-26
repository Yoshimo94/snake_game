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

        private static string Separator = "-";


        public static void SaveScore(string userName, int snakeLength)
        {
            StreamWriter highScore = CreateOrOpenTxtFile();

            var scoreToSave = userName + Separator + snakeLength.ToString();

            highScore.WriteLine(scoreToSave);
            highScore.Close();

        }

        public static bool CheckScore(int snakeLength)
        {
            var top5Score = File.ReadLines(HighScoreFilePath).Select(line => int.Parse(line)).OrderBy(score => score).Take(5);

            if (top5Score.First() < snakeLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckName(string userName)
        {
            if (userName == null || userName.Length <= 3)
            {
                return false;
            }
            return true;
        }
        public static StreamWriter CreateOrOpenTxtFile()
        {
            if (!File.Exists(HighScoreFilePath))
            {
                return File.CreateText(HighScoreFilePath);
            }
            else
            {
                return new StreamWriter(HighScoreFilePath, true);
            }
        }
        public static Dictionary<string, List<int>> ReadTextFile()
        {

            var returnDict = new Dictionary<string, List<int>>();   
            var highscore = File.ReadLines(HighScoreFilePath).ToList();
 
            if (highscore == null)
            {
                return returnDict;
            }
           
            var returnList = new List<int>();

            foreach (var line in highscore)
            {
                var seperatedStrings = line.Split(Separator);
                var userName = seperatedStrings[0];
                var userScore = int.Parse(seperatedStrings[1]);
                returnList.Add(userScore);

                returnDict.Add(userName, returnList);
            }
            return returnDict;
        }

    }
}
