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

        public student()
        {
            name = "Marat";
            sname = "Gaziz";
            gpa = 3.7;
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
            student s = new student();
            Console.WriteLine(s);
            Console.ReadKey();

        }
    }
}
