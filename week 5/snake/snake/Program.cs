using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\local\Desktop\PP\week 5\players.txt",true);

            Console.CursorVisible = false;
            Console.SetWindowSize(70, 20);
            Snake snake = new Snake();
            Food food = new Food();
            Wall wall = new Wall();

            food.SetRandomPosition(wall,snake);
            int cnt = 0;

            bool res = true;
            while (res)
            {
                wall.LoadLevel(1);
                Console.Clear();
                snake.Draw();
                food.Draw();
                wall.Draw();

                

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Move(1, 0);
                        break;
                }
                cnt++;
                snake.Borders();
                if (snake.CanEat(food))
                    food.Eat(snake,wall);

                if (snake.GameOver(wall))
                {
                    Snake.EndofGame();
                    ConsoleKeyInfo bttn = Console.ReadKey();
                    switch (bttn.Key)
                    {
                        case ConsoleKey.Enter:
                        snake.body.Clear();
                        food.score = 0;
                            snake = new Snake();
                        Console.Clear();
                            break;

                        case ConsoleKey.Q:
                            res = false;
                            Console.SetCursorPosition(49, 9);
                            Console.WriteLine("User name:");
                            Console.SetCursorPosition(49, 10);
                            string s = Console.ReadLine();
                            sw.WriteLine("User:" + s + "score:" + food.score);
                            sw.Close();
                            break;
                    }
                }
            }

        }
    }
}
