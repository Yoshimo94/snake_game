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
            var scoreToSave = userName + Separator + snakeLength.ToString();
            using (var stream = File.AppendText(HighScoreFilePath))
            {
                stream.WriteLine(scoreToSave);
            }
        }

        public static bool CheckScore(int snakeLength)
        {
            var scores = ReadTextFile();
            var scoreLists = scores.Values;
            var scoreList = new List<int>();

            foreach (var temporaryScoreList in scoreLists)
            {
                scoreList.AddRange(temporaryScoreList);
            }

            if (scoreList.Count < 5)
            {
                return true;
            }
            else
            {
                foreach (var score in scoreList)
                {
                    if (snakeLength > score)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static bool CheckName(string userName)
        {
            if (userName == null || userName.Length <= 3)
            {
                return false;
            }
            return true;
        }

        public static Dictionary<string, List<int>> ReadTextFile()
        {
            var returnDict = new Dictionary<string, List<int>>();
            List<string> highscore;
            try
            {
                highscore = File.ReadLines(HighScoreFilePath).ToList();
            }
            catch (FileNotFoundException ex)
            {
                return returnDict;
            }
 
            if (highscore == null)
            {
                return returnDict;
            }
           
            foreach (var line in highscore)
            {
                var seperatedStrings = line.Split(Separator);
                var userName = seperatedStrings[0];
                var userScore = int.Parse(seperatedStrings[1]);

                if (returnDict.ContainsKey(userName))
                {
                    returnDict[userName].Add(userScore);
                }
                else
                {
                    var returnList = new List<int>();
                    returnDict.Add(userName, returnList);
                    returnDict[userName].Add(userScore);
                }
            }
            return returnDict;
        }

    }
}
