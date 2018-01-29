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
            int x;
            for(int i = 0; i < args.Length; ++i) // пробегаемся по массиву аргс
            {
                x = int.Parse(args[i]); // переводим в инт
                bool res = true; // заводим переменную булеан
                for(int j = 2;  j < Math.Sqrt(x); ++j) // все делители находятся в этом отрезке
                {
                    if (x == 1) // 1 это не прайм
                    {
                        res = false;
                        break;
                    }
                    if (x % j == 0) // проверка на простоту
                    {
                        res = false;
                        break;
                    }

                }
                if(res == true) // если результат положительный
                {
                    Console.WriteLine(x);
                }
            }

            Console.ReadKey(); // чтобы приложение не закрывалось 
        }
    }
}
