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

            Console.SetCursorPosition(105, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ABY ZATRZYMAĆ GRĘ WCIŚNIJ BACKSPACE");
        }

        public static void ActualScore(int snakeLength)
        {
            Console.SetCursorPosition(105, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"YOUR ACTUAL SCORE: {snakeLength}");
        }

        public static void DrawPauseGame(bool isPausing)
        {
            if (isPausing)
            {
                Console.SetCursorPosition(105, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GRA ZATRZYMANA");
                Console.SetCursorPosition(105, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ABY WZNOWIĆ GRĘ WCIŚNIJ BACKSPACE");
            }
            else
            {
                Console.SetCursorPosition(105, 10);
                Console.WriteLine("              ");
                Console.SetCursorPosition(105, 11);
                Console.WriteLine("                                  ");
            }
        }
    }
}
