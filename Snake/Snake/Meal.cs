using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Meal
    {
        public Coordinate CurrentPosition { get; set; }


        public Meal()
        {
            Random rand = new Random();
            int x = rand.Next(1, 20);
            int y = rand.Next(1, 20);
            CurrentPosition = new Coordinate(x, y);
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(CurrentPosition.X, CurrentPosition.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("$");
        }








    }


}
