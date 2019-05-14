using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260BasicBSTclass
{
    class Program  // basic BST program with just an insert and a find method
    {
        static void Main(string[] args)
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            myBST.Add(20); // add our first node at the top, and 4 more items
            myBST.Add(12);
            myBST.Add(30);
            myBST.Add(10);
            myBST.Add(15);

            // now test if our Find works.
            if (myBST.Find(10))
            {
                Console.WriteLine("Found the value 10");
            }
            else
            {
                Console.WriteLine("bug!");
            }

            if (myBST.Find(12))
            {
                Console.WriteLine("Found the value 12");
            }
            else
            {
                Console.WriteLine("bug!");
            }

            if (myBST.Find(15))
            {
                Console.WriteLine("Found the value 15");
            }
            else
            {
                Console.WriteLine("bug!");
            }

            if (myBST.Find(20))
            {
                Console.WriteLine("Found the value 20");
            }
            else
            {
                Console.WriteLine("bug!");
            }

            if (myBST.Find(30))
            {
                Console.WriteLine("Found the value 30");
            }
            else
            {
                Console.WriteLine("bug!");
            }

            Console.WriteLine();
            Console.WriteLine("Testing adding a duplicate value.");
            try
            {
                myBST.Add(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }



            Console.WriteLine("Program end.");
            Console.ReadLine();
        }
    }

}