using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurQueueClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("put breakpoints in queue class and watch pointers");
            OurQueue myQ = new OurQueue(4);  // using Q size of 4 
            
            //=====================================================================================
            // test 1  ============================================================================================
            Console.WriteLine("Begin of testing OurQueue. Make sure pointers are working");
            myQ.Clear();
            myQ.Enqueue(21);  // fill the q completely (with 4 entries)
            myQ.Enqueue(22);
            myQ.Enqueue(23);
            myQ.Enqueue(24);
            Console.WriteLine(myQ.Dequeue());
            Console.WriteLine(myQ.Dequeue());
            Console.WriteLine(myQ.Dequeue());
            Console.WriteLine(myQ.Dequeue());

            // test 2  ============================================================================================
            // make sure clear works after above test left it full
            myQ.Clear();
            Console.WriteLine("after a Clear, the queue should be empty, it says it has this many entries {0}", myQ.QCount);
            Console.WriteLine();
            Console.WriteLine();

            // test 3  ============================================================================================
            myQ.Enqueue(21);  // fill the q completely (with 4 entries)
            myQ.Enqueue(22);
            myQ.Enqueue(23);
            myQ.Enqueue(24);
            Console.WriteLine("so far so good, lets add one more!");
            Console.ReadLine();
            myQ.Enqueue(25);



            Console.ReadLine();  // done


        }
    }
}
