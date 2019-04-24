using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linked List test program");

            // tests Print()  
            
            IntLinkedList myLL = new IntLinkedList();
            myLL.InsertAtFront(111);
            myLL.InsertAtFront(222);
            myLL.InsertAtFront(333);
            myLL.InsertAtFront(444);
            myLL.InsertAtFront(555);

            Console.WriteLine("testing LL print, should see 555  444  333  222  111");
            Console.WriteLine();
            myLL.Print();

            Console.WriteLine();
            Console.WriteLine();
            myLL.InsertAtFront(333);
            Console.WriteLine("Adding another 333 and thentesting PrintAllMatching(target)");
            Console.WriteLine();
            myLL.Print();
          
            myLL.PrintAllMatching(333);
            Console.WriteLine();




          
            Console.ReadLine();

        }
    }
}
