using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace xmlser
{
    class Program
    {
        static void f1()
        {
            FileStream fs = new FileStream(@"data.xml", FileMode.Create, FileAccess.Write);

            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex c = new Complex();
            try
            {
                xs.Serialize(fs,c);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine("done");

        }

        static void f2()
        {
            FileStream fs = new FileStream(@"data.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            try
            {
                Complex c = xs.Deserialize(fs) as Complex;
                Console.WriteLine(c);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        static void Main(string[] args)
        {

            Complex a = new Complex(3, 5);
            Complex b = new Complex(2, 5);
            Complex n = a + b;
            Console.WriteLine(a + " " + b + "=" + n);

            f1();
            Console.ReadKey();

        }
    }
}
