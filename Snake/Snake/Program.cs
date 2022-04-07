using System;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            DateTime lastDate = DateTime.Now;
            double frameRate = 1000 / 5.0;

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
                            //x
                            break;
                        case ConsoleKey.LeftArrow:
                            //x
                            break;
                        case ConsoleKey.UpArrow:
                            //x
                            break;
                        case ConsoleKey.DownArrow:
                            //x
                            break;
                    }
                    if ((DateTime.Now - lastDate).TotalMilliseconds >= frameRate)
                    {

                        //gameaction
                        lastDate = DateTime.Now;

                    }
                        
                }
                
            }
            
        }
    }
}
