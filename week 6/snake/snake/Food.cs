using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace snake
{
    public class Food
    {
        public Point location;
        public char sign;
        public ConsoleColor color;
        public int score;
        public Food()
        {
            sign = '@';
            color = ConsoleColor.Green;
          
        }

        public void SaveFood()
        {
            FileStream fs = new FileStream(@"food.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            try
            {
                xs.Serialize(fs, Game.food);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        public bool SetRandomPosition(Wall wall, Snake snake)
        {
            int x = new Random().Next(0, 70);
            int y = new Random().Next(0, 20);

            for (int i = 0; i < wall.body.Count; i++)
            {
                if (wall.body[i].x == x && wall.body[i].y == y)
                    return false;
            }
            for (int i = 0; i < snake.body.Count; i++)
            {
                if (snake.body[i].x == x && snake.body[i].y == y)
                    return false;
            }
            location = new Point(x, y);
            return true;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(left: location.x, top: location.y);
            Console.Write(sign);
        }

        public void Eat(Snake snake, Wall wall)
        {

            score += 5;
            do SetRandomPosition(wall, snake);
            while (SetRandomPosition(wall, snake) != true);
            SetRandomPosition(wall, snake);
            if (score == (wall.level + 1) * 10)
            {
                Console.Clear();
                snake.NewLevel();
                wall.level++;
                if (wall.level > 3)
                {
                    wall.level = 1;
                    score = 0;
                }

            }
        }

    }
}
