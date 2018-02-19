using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuStack
{
    class Program
    {
        static void showfiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\local\Desktop\files");
            FileInfo[] files = dir.GetFiles();
            for(int i = 0; i < files.Length; ++i)
            {
                Console.WriteLine(files[i].Name); 
            }
        }

        static void showdirs()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\local\Desktop\files");
            DirectoryInfo[] dirs = dir.GetDirectories();
            for(int i = 0; i < dirs.Length; ++i)
            {
                Console.WriteLine(dirs[i].Name);
            }
        }
        static void f5(string path, int depth = 0)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            DirectoryInfo[] dirs = dir.GetDirectories();
            Stack s = new Stack();
            for(int i = 0; i < dirs.Length; ++i)
            {
                s.Push(dirs[i]);
            }
        }

        static void Main(string[] args)
        {
            showdirs();
            showfiles();
            f5(@"C:\Users\local\Desktop\files");
            Console.ReadKey();
        }
    }
}
