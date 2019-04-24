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

            myLL.InsertAtFront(1);
            //myLL.InsertAtFront(2);
            //myLL.InsertAtFront(3);
            //myLL.InsertAtFront(4);
            //myLL.InsertAtFront(5);

            myLL.Print();

            Console.WriteLine();
           
           

            bool yes = myLL.RemoveByValue(1);
            Console.WriteLine(yes);
            Console.WriteLine();
            myLL.Print();


            Console.ReadLine();
        }
    }
}
