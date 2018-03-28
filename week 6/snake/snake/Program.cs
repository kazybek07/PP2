using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {

        public static int direction = 1;
        public static int speed = 200;

        static void MoveSnakeThread()
        {
            while (!Game.GameOver)
            {
                switch (direction)
                {
                    case 1:
                        Game.snake.Move(1, 0);
                        break;
                    case 2:
                        Game.snake.Move(0, 1);
                        break;
                    case 3:
                        Game.snake.Move(-1, 0);
                        break;
                    case 4:
                        Game.snake.Move(0, -1);
                        break;
                }
                Game.DrawComments();
                Game.Draw();
                Thread.Sleep(speed);

                if(Game.GameOver == true)
                {
                    Game.DrawComments();
                    Game.EndGame();
                    Game.Draw();
                }
            }

        }
        static void Main(string[] args)
        {
            Game.Init();
            Game.food.SetRandomPosition(Game.wall, Game.snake);
            Thread t = new Thread(MoveSnakeThread);
            t.Start();

            //StreamWriter sw = new StreamWriter(@"C:\Users\local\Desktop\PP\week 5\players.txt",true);

            
            
            
           
            while (!Game.GameOver)
            {
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        direction = 4;
                        break;
                    case ConsoleKey.DownArrow:
                        direction = 2;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = 3;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = 1;
                        break;


                    case ConsoleKey.Enter:
                        Console.Clear();
                        Game.wall.level = 1;
                        Game.food.score = 0;
                        Game.snake = new Snake();
                        Game.Draw();
                        direction = 1;

                        if (Game.GameOver == true)
                        {
                            Game.GameOver = false;
                           t = new Thread(MoveSnakeThread);
                           t.Start();
                        }
                        break;

                    case ConsoleKey.Q:
                        Game.GameOver = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.S:
                        if (Game.GameOver != true)
                            Game.Save();
                        Game.GameOver = true;
                        break;
                }
                
                
               
            }

        }
    }
}
