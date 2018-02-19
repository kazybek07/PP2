using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Wall
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        public int level = 1;

        public Wall()
        {
            color = ConsoleColor.Red;
            sign = '#';
            body = new List<Point>();

            LoadLevel(1);
        }

        public void LoadLevel(int level)
        {
            body.Clear();

            int a = level;
            string filepath = string.Format(@"C:\Users\local\Desktop\PP\week 5\levels\level{0}.txt", level);
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = "";
            int i = 0;
            int row = 0;
            while (i < 20)
            {
                line = sr.ReadLine();
                for(int col = 0; col < line.Length; ++col)
                {
                    if(line[col]== '#')
                    {
                        body.Add(new Point(col, row));
                    }
                }
                i++;
                row++;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
