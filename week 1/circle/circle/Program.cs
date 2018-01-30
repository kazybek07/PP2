using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circle
{   
    class circle
    {
        public int radius;
        public double area;
        public double circum;
        public int diameter;

        public circle(int r)
        {
            radius = r;
        }

        public void findArea()
        {
            area = Math.PI * radius * radius;
        }

        public void findCircum()
        {
            circum = 2 * Math.PI * radius;
        }

        public void findDiameter()
        {
            diameter = 2 * radius;
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            circle c = new circle(3);
            c.findArea();
            c.findCircum();
            c.findDiameter();

            Console.WriteLine("area:" + c.area);
            Console.WriteLine("circumference:"+ c.circum);
            Console.WriteLine("diameter:" + c.diameter);

            Console.ReadKey();

        }
    }
}
