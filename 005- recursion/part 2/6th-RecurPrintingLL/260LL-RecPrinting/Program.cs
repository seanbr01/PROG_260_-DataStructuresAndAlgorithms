using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260LL_RecPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            IntLinkedList myLL = new IntLinkedList();
            myLL.InsertAtFront(50);
            myLL.InsertAtFront(40);
            myLL.InsertAtFront(30);
            myLL.InsertAtFront(20);
            myLL.InsertAtFront(10);

            Console.WriteLine("while loop print");
            myLL.Print();
            
            Console.WriteLine();
            Console.WriteLine("recursive forward print");
            myLL.RecursivelyPrintForward();
            
            Console.WriteLine();
            Console.WriteLine("recursive backward print");
            myLL.RecursivelyPrintBackward();

            Console.WriteLine();

            Console.WriteLine("end of program");
            Console.ReadLine();
        }
    }
}

   