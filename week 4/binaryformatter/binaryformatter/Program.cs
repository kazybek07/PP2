using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaryformatter
{
    class Program
    {
        static void f1()
        {   
            

            FileStream fs = new FileStream(@"dat2.ser", FileMode.Create, FileAccess.Write);

            complex c = new complex(1,3);
            
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, c);
            }

            catch (Exception e)
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

            FileStream fs = new FileStream(@"data.ser", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                complex c = bf.Deserialize(fs) as complex;
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
            f1();
            Console.ReadKey();
        }

    }
}
