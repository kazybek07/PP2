using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student
{      
    class student
    {
        public string name;
        public string sname;
        public double gpa;


        public student(string _name, string _sname)
        {
            name = _name;
            sname = _sname;

        }
        public student(string n, string s, double g)
        {
            name = n;
            sname = s;
            gpa = g;
        }

        public override string ToString()
        {
            return name + " " + sname + " " + gpa;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            student s = new student("KBTU", "FIT");
            Console.WriteLine(s);
            Console.ReadKey();

        }
    }
}
