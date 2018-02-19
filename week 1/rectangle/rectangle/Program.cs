using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rectangle
{   
    class rectangle
    {
        public int width;
        public int height;
        public double area;
        public double per;

        public rectangle()
        {
            width = 5;
            height = 4;
        }

        public rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
        public void findArea()
        {
            area = width * height;
        }
        public void findPer()
        {
            per = (width + height) * 2;
        }

        public override string ToString()
        {
            return width + " " + height + " " + area + " " + per;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            rectangle r = new rectangle(5, 6);
            r.findArea();
            r.findPer();

            /*  Console.WriteLine("area:" + r.area);
              Console.WriteLine("perimeter:" + r.per);*/

            string s = r.ToString();
            Console.WriteLine(s);
            Console.ReadKey();


        }
    }
}
