﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class complex
    {

        public int x;
        public int y;

        public complex()
        {
            x = 1;
            y = 1;
        }
        public complex(int a, int b)
        {
            x = a;
            y = b;
        }
        public int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }
        public void Cancel()
        {
            int n = GCD(x, y);
            x /= n;
            y /= n;
        }

        public static complex operator +(complex c1, complex c2)
        {
            complex n = new complex();
            n.y = c2.y * c1.y;
            n.x = c1.x * n.y / c1.y + c2.x * n.y / c2.y;

            n.Cancel();


            return n;
        }
        public override string ToString()
        {
            if (y != 1)
                return x + "/" + y;
            else return x + " ";
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            complex a = new complex(3,5);
            complex b = new complex(2,5);
            complex n = a + b;
            Console.WriteLine(a + "+" + b + "=" + n);
            Console.ReadKey();

        }
    }
}
