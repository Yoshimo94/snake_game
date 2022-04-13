using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class SnakeApp
    {
        private const double AccelerationRate = 1.1;
       
        private Snake _snake { get; set; }
        private Meal _meal { get; set; }
        private bool _isRunning { get; set; }
        private DateTime _lastDate { get; set; }
        private double _frameRate { get; set; }

        public SnakeApp()
        {
            _meal = new Meal();
            _snake = new Snake();
            _isRunning = true;
            _lastDate = DateTime.Now;
            _frameRate = 1000 / 5.0;
        }

        public void RefreshGame()
        {
            Console.Clear();
            _meal = new Meal();
            _snake = new Snake();
            _isRunning = true;
            _lastDate = DateTime.Now;
            _frameRate = 1000 / 5.0;

        }

        public void StartGame()
        {
            //game loop
            while (_isRunning)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.Escape:
                            _isRunning = true;
                            break;
                        case ConsoleKey.RightArrow:
                            _snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.LeftArrow:
                            _snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.UpArrow:
                            _snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            _snake.Direction = Direction.Down;
                            break;
                    }
                }
                if ((DateTime.Now - _lastDate).TotalMilliseconds >= _frameRate)
                {

                    //gameaction
                    _snake.Move();

                    if (_meal.CurrentPosition.X == _snake.HeadPosition.X
                        && _meal.CurrentPosition.Y == _snake.HeadPosition.Y)
                    {
                        _snake.EatMeal();
                        _meal = new Meal();
                        _frameRate /= AccelerationRate;
                    }

                    if (_snake.GameOver)
                    {
                        Console.Clear();
                        Console.WriteLine($"GAME OVER. YOUR SCORE:{_snake.Length}");
                        Console.WriteLine("1. Aby zagrać ponowanie wciśnij: N ");
                        Console.WriteLine("2. Aby wyjść z gry wciśnij: Q ");
                        var userinput = Console.ReadLine();
                        if (userinput.ToLower() == "q")
                        {
                            _isRunning = false;
                        }
                        else if (userinput.ToLower() == "n")
                        {
                            RefreshGame();
                            StartGame();
                        }
                    }

                    _lastDate = DateTime.Now;
                }

            }
        }

    }
}
