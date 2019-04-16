using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1stMultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A1 = new int[] { 1, 2, 3 };
            int[] A2 = new int[] { 4, 5, 6 };
            // we are in the first thread, which you started when you told VS to "start" (at class Program, method Main)
            Random myRandom = new Random();
            Thread t2 = new Thread(WriteMsg2); // create second Thread and point it to the code (method) to execute
            Thread t3 = new Thread(WriteMsg3); // create third Thread and point it to the code (method) to execute
            t2.Start(A1);  // start the threads
            t3.Start(A2);

            for (int i = 0; i < 10; i++)
            {
               // Thread.Sleep(myRandom.Next(1, 2)*1000); // pretend the thread is doing useful work, buy taking a 2 to 3 second delay
                Console.WriteLine("thread 1");
            }
            Console.WriteLine("Thread: 1 done.");

            Console.WriteLine("Thread1: now waiting for other two threads");

            bool othersNotDone = true;  // simulate thread one waiting until other threads are done before continuing
            while (othersNotDone)
            {
                othersNotDone = false;
                 Thread.Sleep(myRandom.Next(1000)); //
                 if (t2.IsAlive || t3.IsAlive)
                 {
                     othersNotDone = true;
                     Console.WriteLine("tick!");
                 }
            }

            Console.WriteLine();
            Console.WriteLine("Thread 1: all 3 are done");
            Console.WriteLine("Thread 1: now I can continue, assuming that what I needed done is complete, and I can use the results");
            Console.ReadLine();
        }

        private static void WriteMsg2(object pA)
        {
            int[] localArray = (int[])pA;
            Random myRandom = new Random();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(myRandom.Next(1, 2) * 1000); // pretend the thread is doing useful work, buy taking a 3 to 4 second delay
                Console.WriteLine("thread 2");
            }
            Console.WriteLine(string.Join("  ", localArray));
        }

        private static void WriteMsg3(object pA)
        {
            int[] localArray = (int[])pA;
            Random myRandom = new Random();
             for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(myRandom.Next(1, 3) * 1000); // pretend the thread is doing useful work, buy taking a 4 to 5 second delay
                Console.WriteLine("thread 3");
            }
             Console.WriteLine(string.Join("  ", localArray));
        }

        // note there are NO dependencies between these 3 threads.  Any one of them can execute whenever they like.
    }
}
