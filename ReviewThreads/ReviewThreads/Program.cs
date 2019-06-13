using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReviewThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] myArray = new double[5] { 22.2, 33.3, 44.4, 55.5, 11.1 };

            // instantiate new threads with delagate methods
            Thread t2 = new Thread(DeligateMethod1);
            Thread t3 = new Thread(DeligateMethod2);

            // start theards
            t2.Start(myArray);
            t3.Start(myArray);

            Console.ReadLine();
        }

        public static void DeligateMethod1(object array)
        {
            double[] myArray = (double[])array;
            Console.WriteLine("The sum of the array is:");
            Console.WriteLine(myArray.Sum().ToString() + "\n");
        }

        private static void DeligateMethod2(object array)
        {
            double[] myArray = (double[])array;
            Console.WriteLine("The averege of the array is:");
            Console.WriteLine(myArray.Average().ToString() + "\n");
        }


    }
}
