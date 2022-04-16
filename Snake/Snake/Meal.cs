using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Meal
    {
        public Coordinate CurrentPosition { get; set; }


        public void Draw()
        {
            Console.SetCursorPosition(CurrentPosition.X, CurrentPosition.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("$");
        }
        public void CreateMeal(List<Coordinate> snakeTail)
        {
            Random rand = new Random();
            int x = rand.Next(1, 20);
            int y = rand.Next(1, 20);

            foreach (var tailUnit in snakeTail)
            {
                if (tailUnit.X == x && tailUnit.Y == y)
                {
                    CreateMeal(snakeTail);
                }
            }
            CurrentPosition = new Coordinate(x, y);
            Draw();
        }
    }
}

