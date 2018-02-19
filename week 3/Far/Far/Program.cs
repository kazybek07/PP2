using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Far
{

    class Program
    {
        static void showFolderContent(DirectoryInfo cur, int pos)
        {
            FileSystemInfo[] data = cur.GetFileSystemInfos();
            for (int i = 0; i < data.Length; i++)
            {
                if (i == pos)
                    Console.BackgroundColor = ConsoleColor.White;
                else
                    Console.BackgroundColor = ConsoleColor.Black;

                if (data[i].GetType() == typeof(DirectoryInfo))
                    Console.ForegroundColor = ConsoleColor.Blue;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(data[i].Name);
            }

        }
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            int pos = 0;

            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\local\Desktop\files");

            bool res = true;
            while (res)
            {
                Console.Clear();
                showFolderContent(dir, pos);

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        pos--;
                        if (pos < 0)
                            pos = dir.GetFileSystemInfos().Length - 1;
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case ConsoleKey.DownArrow:
                        pos++;
                        if (pos == dir.GetFileSystemInfos().Length)
                            pos = 0;
                            Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo f = dir.GetFileSystemInfos()[pos];
                        if (f.GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(f.FullName);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            FileStream fs = new FileStream(@"C:\Users\local\Desktop\files\input.txt ", FileMode.Open, FileAccess.Read);
                            StreamReader sr = new StreamReader(fs);
                            string info = sr.ReadToEnd();
                            Console.Clear();
                            Console.WriteLine(info);
                            Console.ReadKey();

                        }
                        break;
                    case ConsoleKey.Backspace:
                       
                        dir = dir.Parent;
                        pos = 0;
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;

                    case ConsoleKey.Q:
                        res = false;
                        Console.Clear();

                        break;
                    

                }
            }


        }
    }
}

