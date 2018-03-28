using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace snake
{
    public class Snake
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

       

        public void SaveSnake()
        {
            FileStream fs = new FileStream(@"snake.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Snake));
            try
            {
                xs.Serialize(fs, Game.snake);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        public Snake()
        {
            sign = 'o';
            color = ConsoleColor.Yellow;
            body = new List<Point>();

            body.Add(new Point(12, 10));
            body.Add(new Point(11, 10));
            body.Add(new Point(10, 10));
        }

        public void Move(int dx, int dy)
        {
            Point lastPoint = body[body.Count - 1];
            Console.SetCursorPosition(lastPoint.x, lastPoint.y);
            Console.Write(' ');

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;
            Game.snake.CanEat();
            Game.snake.Borders();
            Game.snake.GameIsOver();
        }

        public bool CanEat()
        {
            if(Game.food.location.x == body[0].x  && Game.food.location.y == body[0].y )
            {
                body.Add(new Point(body[body.Count -1].x, body[body.Count-1].y));
                return true;
            }
            Game.food.SetRandomPosition(Game.wall, Game.snake);
            return false;
        }

        public void GameIsOver()
        {
            for(int i = 1; i< body.Count; ++i)
            {
                if(body[0].x==body[i].x && body[0].y == body[i].y)
                {
                    Game.GameOver = true;
                    break;
                }
            }

            if(Game.GameOver == false)
            {
                for(int i = 0; i < Game.wall.body.Count; ++i)
                {
                    if(body[0].x==Game.wall.body[i].x && body[0].y == Game.wall.body[i].y)
                    {
                        Game.GameOver = true;
                        break;

                    }
                }
            }
        }

        public void NewLevel()
        {
            for (int i = 1; i <= body.Count - 1; i++)
            {
                body[i].x = 0;
                body[i].y = 0;
            }
            body[0].x = 1;
            body[0].y = 1;
        }


        public bool GameOver(Wall wall)
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            for (int i = 0; i < wall.body.Count; i++)
            {
                if (body[0].x == wall.body[i].x && body[0].y == wall.body[i].y)
                    return true;
            }
            return false;

        }

        public void Draw()
        {
            int i = 0;
            foreach(Point p in body)
            {
                if (i == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                i++;
            }
        }

        public void Borders()
        {
            if (body[0].x < 0)
                body[0].x = 70;
            if (body[0].x > 70)
                body[0].x = 0;
            if (body[0].y < 0)
                body[0].y = 20;
            if (body[0].y > 20)
                body[0].y = 0;

        }
    }
}
