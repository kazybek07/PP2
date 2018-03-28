using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    public class Game
    {
        public static Snake snake;
        public static Food food;
        public static Wall wall;
        public static bool GameOver;

        public Game()
        {

        }

        public static void Save()
        {
            //snake.SaveSnake();
            wall.SaveWall();
           // food.SaveFood();
        }

        public static void Init()
        {
            GameOver = false;
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 20);

            snake = new Snake();
            food = new Food();
            wall = new Wall();

        }

        public static void EndGame()
        {
            Console.SetCursorPosition(23, 9);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Game over");

        }

        public static void DrawComments()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press Enter - new game");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press S to save the game");
        }

        public static void Draw()
        {
            Console.Clear();
            wall.LoadLevel(1);
            snake.Draw();
            food.Draw();
            wall.Draw();
        }
    }
}
