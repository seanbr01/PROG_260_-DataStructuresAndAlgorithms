using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartArrayConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var mySmartArray = new SmartArray(5);
            mySmartArray.SetAtIndex(2, 102);
            mySmartArray.SetAtIndex(4, 104);
            mySmartArray.PrintAllElements();
            Console.WriteLine();

            var x = mySmartArray.GetAtIndex(4);
            Console.WriteLine("x is {0}", x);
            Console.WriteLine();

            var found = mySmartArray.Find(102);
            Console.WriteLine(found);

            mySmartArray.Resize(10);

            mySmartArray.PrintAllElements();

            Console.ReadLine();
        }
    }
}
