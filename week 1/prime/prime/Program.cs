using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            args = s.Split(' ');
            foreach(string s1 in args)
            {
                bool res = true;
                int x = int.Parse(s1);
                for(int i = 2; i <= Math.Sqrt(x); ++i)
                {
                   
                    if (x % i == 0)
                    {
                        res = false;
                        break;
                    }
                }
                if (res == true && x != 1)
                {
                    Console.WriteLine(x + " ");
                    Console.ReadKey();
                }
            }
            
        }
    }
}
