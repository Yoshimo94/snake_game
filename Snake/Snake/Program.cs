using System;

namespace Snake
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool exit = false;
            DateTime lastDate = DateTime.Now;
            double frameRate = 1000 / 5.0;
            Meal meal = new Meal();
            Snake snake = new Snake();

            //game loop
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.Escape:
                            exit = true;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                    }                     
                }
                if ((DateTime.Now - lastDate).TotalMilliseconds >= frameRate)
                {

                    //gameaction
                    snake.Move();
                    
                    if(meal.CurrentPosition.X == snake.HeadPosition.X
                        && meal.CurrentPosition.Y == snake.HeadPosition.Y)
                    {
                        snake.EatMeal();
                        meal = new Meal();
                        frameRate /= 1.1;
                    }

                    if (snake.GameOver)
                    {
                        Console.Clear();
                        Console.WriteLine($"GAME OVER. YOUR SCORE:{snake.Length}");
                        exit = true;
                        Console.ReadLine();
                    }

                    lastDate = DateTime.Now;
                }

            }
            
        }
    }
}
