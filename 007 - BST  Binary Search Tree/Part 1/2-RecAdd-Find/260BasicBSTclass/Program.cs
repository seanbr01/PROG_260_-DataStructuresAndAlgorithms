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
            try
            {
                // first case, first ppt
                Console.WriteLine("using AddRec, add 5 nodes");
                myBST.AddRec(10); // add our first node at the top
                myBST.AddRec(5);
                myBST.AddRec(15);
                myBST.AddRec(7);
                myBST.AddRec(12);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("now use new FindRec method to find those 5 nodes");
                // now test if our Find works.
                if (myBST.FindRec(10))
                {
                    Console.WriteLine("Found the value 10");
                }
                else
                {
                    Console.WriteLine("bug!");
                }

                if (myBST.FindRec(5))
                {
                    Console.WriteLine("Found the value 5");
                }
                else
                {
                    Console.WriteLine("bug!");
                }

                if (myBST.FindRec(15))
                {
                    Console.WriteLine("Found the value 15");
                }
                else
                {
                    Console.WriteLine("bug!");
                }

                if (myBST.FindRec(7))
                {
                    Console.WriteLine("Found the value 7");
                }
                else
                {
                    Console.WriteLine("bug!");
                }

                if (myBST.FindRec(12))
                {
                    Console.WriteLine("Found the value 12");
                }
                else
                {
                    Console.WriteLine("bug!");
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Test: trying to add a value that is already in the BST");
                Console.WriteLine();
                myBST.AddRec(5);  // try adding a duplicate to 3rd case


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Program end.");
            Console.ReadLine();
        }

    }
}
