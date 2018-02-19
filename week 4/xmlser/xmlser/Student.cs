using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmlser
{
    class Student
    {
        public string name;
        public string sname;
        public double gpa;

        public Student()
        {
            name = "Kbtu";
            sname = "Fit";
            gpa = 4;
        }

        public override string ToString()
        {
            return name + " " + sname + " " + gpa;
        }
    }
}
