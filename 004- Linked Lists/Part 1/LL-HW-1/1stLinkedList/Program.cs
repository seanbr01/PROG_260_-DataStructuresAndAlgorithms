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
            IntLinkedList myLL = new IntLinkedList();

            myLL.InsertAtEnd(1);
            myLL.InsertAtEnd(2);
            myLL.InsertAtEnd(3);
        
            myLL.Print();  // should write out  1   2   3

            Console.WriteLine();


            int returnValue = myLL.RemoveFromEnd();
            Console.WriteLine(returnValue);  // should write out 3
            returnValue = myLL.RemoveFromEnd();
            Console.WriteLine(returnValue); // should write out 2
            returnValue = myLL.RemoveFromEnd();
            Console.WriteLine(returnValue);  // should write out 1
            Console.WriteLine();
            myLL.Print();  // should write out nothing
            Console.WriteLine();
            returnValue = myLL.RemoveFromEnd();  // should throw an exception
            
            Console.ReadLine();
        }
    }
}
