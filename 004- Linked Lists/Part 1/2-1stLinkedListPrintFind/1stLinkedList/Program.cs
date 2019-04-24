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

<<<<<<< HEAD
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
=======
            myLL.InsertAtFront(3);
            myLL.InsertAtFront(7);
            myLL.InsertAtFront(5);

            myLL.Print();

            Console.ReadLine();

           
            
            bool found = myLL.Find(5);

            Console.WriteLine("the value was found? {0}", found);
            Console.WriteLine();

            //myLL.RemoveByValue(7);

>>>>>>> 95485143828fc4e7dc5ff24b0698dc63d7a3725e
            myLL.Print();


            Console.ReadLine();
        }
    }
}
