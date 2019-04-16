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
            OurQueue myQ = new OurQueue(4);  // using Q size of just 4 to make testing limits easier


           
            //=====================================================================================
            // test 1  ============================================================================================
            Console.WriteLine("Begin of testing OurQueue. Make sure pointers are working");
            myQ.Clear();
            myQ.Enqueue(1);  // fill the q completely (with 4 entries)
            myQ.Enqueue(2);
            myQ.Enqueue(3);
            myQ.Enqueue(4);

            // remove and add an element 5 times to make sure the top and bottom pointers have all looped back to zero
            myQ.Dequeue(); // remove one
            myQ.Enqueue(5);  // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(6); // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(7); // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(8); // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(9); // fill the last empty slot

            Console.WriteLine("At this point, there should be 4 entries, there are {0}", myQ.QCount);
            Console.WriteLine();
            Console.WriteLine();

            // test 2  ============================================================================================
            // make sure clear works after above test left it full
            myQ.Clear();
            Console.WriteLine("after a Clear, the queue should be empty, it says it has this many entries {0}", myQ.QCount);
            Console.WriteLine();
            Console.WriteLine();

            // test 3  ============================================================================================
            // test values are correct after looping the pointers. Fill the Q, then pop and push 5 times and check the top
            // of the Q to make sure the correct value is stored there.
            
            Console.WriteLine("Make sure pointers are working and we get the right return value");

            myQ.Clear();
            myQ.Enqueue(1);  // fill the q
            myQ.Enqueue(2);
            myQ.Enqueue(3);
            myQ.Enqueue(4);

            // walk the empty element 5 times to make sure the top and bottom pointers have all looped back to zero
            myQ.Dequeue(); // remove one
            myQ.Enqueue(5);  // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(6); // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(7); // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(8); // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(9); // fill the last empty slot

            int value = myQ.Dequeue();
            Console.WriteLine("At this point, the top of the queue should be holding a 6, it is in fact a  {0}", value);
            Console.WriteLine();
            Console.WriteLine();


            // test 4  ============================================================================================
            //make use queue is storing data correctly, fill it with known values and then pop them all out to verify

            myQ.Clear();
            myQ.Enqueue(1111);  // fill the q
            myQ.Enqueue(2222);
            myQ.Enqueue(3333);
            myQ.Enqueue(4444);

            value = myQ.Dequeue() + myQ.Dequeue() + myQ.Dequeue() + myQ.Dequeue();

            Console.WriteLine("make sure queue is storing data correctly");
            Console.WriteLine("The sum of the 4 values should be 11110, it is actaully {0}", value);

            Console.WriteLine();
            Console.WriteLine();


            // test 5  ============================================================================================
            // check that we throw the correct exception when trying to pop an empty Q
            try
            {
                myQ.Clear();
                Console.WriteLine(myQ.Dequeue()); // throw an empty exception
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Correctly caught an exception when popping and empty queue, the message passed is " + e.Message);
            }
            Console.WriteLine();
            Console.WriteLine();


            // test 6  ============================================================================================
            // check that we throw the correct exception when we try to put an entry in when the queue is already full
            myQ.Clear();
            try
            {

                myQ.Enqueue(10);  // fill the q
                myQ.Enqueue(11);
                myQ.Enqueue(12);
                myQ.Enqueue(13);
                // try to put in one too many
                myQ.Enqueue(5);  // throw a full exception

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Correctly caught an exception trying to add to a full queue, the message passed is " + e.Message);
            }
            Console.WriteLine();
            Console.WriteLine();

            // test 7  ============================================================================================
            // check that we throw the correct exception when we try to peek at an empty queue

            myQ.Clear();  // try to peak at an empty queue
            Console.WriteLine();
            Console.WriteLine("Try to peak, should cause exception.");

            try
            {
                myQ.Peek();
            }
            catch (Exception e)
            {
                Console.WriteLine("good, did get the exception;  " + e.Message);
            }

            // test 8  ============================================================================================
            // Students need to create one more important, useful test!!

            Console.ReadLine();  // done


        }
    }
}
