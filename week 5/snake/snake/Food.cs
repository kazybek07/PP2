using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Food
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

        public bool SetRandomPosition(Wall wall, Snake snake)
        {
            int x = new Random().Next(0, 70);
            int y = new Random().Next(0, 20);

            for (int i = 0; i < wall.body.Count; i++)
                if (wall.body[i].x == x && wall.body[i].y == y)
                    return false;
            for (int i = 0; i < snake.body.Count; i++)
                if (snake.body[i].x == x && snake.body[i].y == y)
                    return false;

            location = new Point(x, y);
            return true;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }

        public void Eat(Snake snake, Wall wall)
        {

            score += 5;//когда змейка скушала, счет увеличивается на 5 очков
                       //пока наша функция не будет правдива , ищем случайную позицию для еды
            do SetRandomPosition(wall, snake);
            while (SetRandomPosition(wall, snake) != true);
            SetRandomPosition(wall, snake);
            if (score == (wall.level + 1) * 10)
            {//меняем уровень при достижении определенного количества очнов
                Console.Clear();
                snake.NewLevel();
                wall.level++;
                if (wall.level > 3)
                {//пока всего 4 уровня поэтому при прохождении на 5 -возращаемся к первому и обнуляем счет
                    wall.level = 1;
                    score = 0;
                }

            }
        }

    }
}
