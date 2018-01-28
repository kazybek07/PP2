 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minprime
{   
    class minprime
    {
        public int minp = 3;

        public void findprime()
        {
            FileStream fs = new FileStream(@"C:\Users\local\Desktop\PP\week 2\numbers.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            string[] arr = s.Split(' ');

            for(int i = 0; i < arr.Length; ++i)
            {
                bool res = true;
                int n = int.Parse(arr[i]);
                if (n == 1)
                {
                    res = false;
                }
                if(n > 1)
                {
                    for(int j = 2; j < Math.Sqrt(n); ++j)
                    {
                        if (n % j == 0)
                        {
                            res = false;
                            
                        }

                    }
                }
                if (n < minp && res == true)
                {
                    minp = n;
                }
            }
            FileStream fw = new FileStream(@"C:\Users\local\Desktop\PP\week 2\answer.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fw);
            sw.Write("min prime =" + minp);
            fs.Close();
            sr.Close();
            sw.Close();
            fw.Close();
            
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {

            minprime m = new minprime();
            m.findprime();
            Console.WriteLine("min prime=" + m.minp);
            Console.ReadKey();
        }
    }
}
