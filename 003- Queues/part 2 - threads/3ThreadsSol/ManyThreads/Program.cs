using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManyThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            // our array with the 90 values
            int[] myArray = { 43, 12, 93, 40, 1, 25, 4, 63, 92, 86, 46, 48, 18, 75, 82, 97, 89, 66, 49, 7, 62, 24, 47, 67, 88, 2, 74, 99, 23, 80,
            43, 12, 93, 40, 1, 25, 4, 63, 92, 86, 46, 48, 18, 75, 82, 97, 89, 66, 49, 7, 62, 24, 47, 67, 88, 2, 74, 99, 23, 80,
            43, 12, 93, 40, 1, 25, 4, 63, 92, 86, 46, 48, 18, 75, 82, 97, 89, 66, 49, 7, 62, 24, 47, 67, 88, 2, 74, 99, 23, 80};

            // create 3 threads and assign their "instructions"
            Thread t1 = new Thread(workerBeeTask1);
            Thread t2 = new Thread(workerBeeTask2);
            Thread t3 = new Thread(workerBeeTask3);
            
            //instantiate and initialize the taxi class to allow sharing of data with threads
            Taxi taxi = new Taxi();
            taxi.theArray = myArray;
            taxi.subTotal_1 = 0;
            taxi.subTotal_2 = 0;
            taxi.subTotal_3 = 0;

            //start the threads, passing in a reference to the shared object
            t1.Start(taxi);
            t2.Start(taxi);
            t3.Start(taxi);

            // wait for them to complete
            bool allThreadnotDone = true;

            while (allThreadnotDone)
            {
                allThreadnotDone = false; // assume they are all done, but then
                //check if any are still alive
                if (t1.IsAlive || t2.IsAlive || t3.IsAlive)
                {
                    allThreadnotDone = true; // set the semiphore saying we need to wait longer
                    Console.WriteLine("at least one thread has not ended.");
                }
                // give back the CPU to another task for 1 second
                Thread.Sleep(1000);
                
            }
            Console.WriteLine("All 3 threads are done.");
            Console.WriteLine("The sum of all array elements is {0}", taxi.subTotal_1 + taxi.subTotal_2 + taxi.subTotal_3);

            Console.ReadLine();

        }
        // define the delegate methods, only difference is which part of array they work on
        public static void workerBeeTask1(object taxi)
        {
            Taxi mytaxi = (Taxi)taxi;  // MUST cast the object back to what we passed in, a Taxi
            int sum = 0;
            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(100);
                sum += mytaxi.theArray[i];
            }
            mytaxi.subTotal_1 = sum;
        }
        public static void workerBeeTask2(object taxi)
        {
            Taxi mytaxi = (Taxi)taxi;
            int sum = 0;
            for (int i = 30; i < 60; i++)
            {
                Thread.Sleep(100);
                sum += mytaxi.theArray[i];
            }
            mytaxi.subTotal_2 = sum;
        }
        public static void workerBeeTask3(object taxi)
        {
            Taxi mytaxi = (Taxi)taxi;
            int sum = 0;
            for (int i = 60; i < 90; i++)
            {
                Thread.Sleep(100);
                sum += mytaxi.theArray[i];
            }
            mytaxi.subTotal_3 = sum;

        }
    }




}
