using System;

namespace Snake
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(140, 40);

            Console.CursorVisible = false;

            SnakeApp snakeApp = new SnakeApp();

            snakeApp.MainMenu();
            
        }
    }
}
