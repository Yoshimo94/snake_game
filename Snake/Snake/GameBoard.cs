using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class GameBoard
    {
        public static void DrawGameBoard()
        {
            for (int i = 0; i < 32; i++)
            {
                Console.SetCursorPosition(101, i);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|");
            }
            for (int i = 0; i < 101; i++)
            {
                Console.SetCursorPosition(i, 31);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("~");
            }
        }
    }
}
