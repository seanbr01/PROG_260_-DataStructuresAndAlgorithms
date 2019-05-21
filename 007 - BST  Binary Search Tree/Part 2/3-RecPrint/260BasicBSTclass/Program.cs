using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260BasicBSTclass
{
    class Program
    {
        static void Main(string[] args)
        {
            BST myBST = new BST();  // instantiate an object of the class BST
          
            Console.WriteLine("using Add, add 5 nodes");
            myBST.Add(10); // add our first node at the top, and 4 more items
            myBST.Add(5);
            myBST.Add(7);
            myBST.Add(12);
            myBST.Add(1);
            myBST.Add(2);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("now calling new Print, which uses recursion");
            myBST.Print();

            Console.WriteLine();
            Console.WriteLine("Program end.");
            Console.ReadLine();
        }

    }
}
