using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxmin
{
    class file
    {
        public int max;
        public int min;

        public void maxmin()
        {
            FileStream fs = new FileStream(@"C:\Users\local\Desktop\PP\week 2\numbers.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            string[] arr = s.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                int n = int.Parse(arr[i]);

                if (n > max)
                {
                    max = n;
                }

                if (n < min)
                {
                    min = n;
                }
            }
            fs.Close();
            sr.Close();

        }

        class Program
        {
            static void Main(string[] args)
            {
                file f = new file();
                f.maxmin();
                Console.WriteLine("max=" + f.max);
                Console.WriteLine("min=" + f.min);
                Console.ReadKey();
            }
        }
    }
}