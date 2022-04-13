using System;

namespace Snake
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            SnakeApp snakeApp = new SnakeApp();

            snakeApp.StartGame();
            
        }
    }
}
