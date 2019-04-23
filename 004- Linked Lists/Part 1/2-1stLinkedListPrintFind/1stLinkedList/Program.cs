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

            myLL.InsertAtFront(3);
            myLL.InsertAtFront(7);
            myLL.InsertAtFront(5);

            myLL.Print();

            Console.ReadLine();

           
            
            bool found = myLL.Find(5);

            Console.WriteLine("the value was found? {0}", found);
            Console.WriteLine();

            //myLL.RemoveByValue(7);

            myLL.Print();


            Console.ReadLine();
        }
    }
}
