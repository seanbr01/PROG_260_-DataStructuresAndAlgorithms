using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog260_HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2 demos

            // 1st just tries sort out on a small array
            //SortSmallArray();

            // 2nd sorts random arrays, many times, and verifies they are sorted correctly.
            SortBigArray();

            Console.ReadLine();
        }

        private static void SortSmallArray()
        {
            // use a small simple array to learn code, and a big array to test code
            int[] simpleArray = new int[] { 16, 19, 3, 11, 13, 12, 1, 24, 5 };

            Console.WriteLine("The small array before sorting");
            Console.WriteLine(string.Join("  ", simpleArray));
            Console.WriteLine();

            HeapSort smallTry = new HeapSort();

            // Comment out one of the two following statements, to pick which one of the 2 implimentations to use
            //smallTry.HeapSortUp(ref simpleArray); // This is the "sift up" implementation
            smallTry.HeapSortDown(ref simpleArray);  // This is the "sift down" implementation

            Console.WriteLine("The small array sorted");
            Console.WriteLine(string.Join("  ", simpleArray));
            Console.WriteLine();


        }

        private static void SortBigArray()
        {
            Console.WriteLine("Be patient, this might take a while to run.");

            // create an array of ints and then randomize the numbers in it
            int[] intArrayTest = new int[500];  // 500 is about as many that will fit nicely in a dos window)
            int[] intTempArray = new int[intArrayTest.Length];  // use this to remember state of array before the sort
            bool GoodIsOK = true;  // flag set to indicate if the sort worked correctly
            int intCount = 0;


            HeapSort hsTry = new HeapSort();

            // Let do a few thousands sorts of random sets to see if we can find a sequence that breaks the code
            while (GoodIsOK == true && intCount <= 1000) // try 1000 random arrays
            {
                BuildRandomArray(intArrayTest); // call the method that fills the array with random numbers

                for (int i = 0; i < intTempArray.Length; i++)  // copy our test array, before sort, so we can compare it later after the sort
                {
                    intTempArray[i] = intArrayTest[i];
                }



                // Comment out one of the two following statements, to pick which one of the 2 implimentations to use
                //hsTry.HeapSortUp(ref intArrayTest); // This is the "sift up" implementation
                hsTry.HeapSortDown(ref intArrayTest);  // This is the "sift down" implementation

                // test to make sure the array is sorted corretly
                for (int i = 0; i < intArrayTest.Length; i++)
                {
                    if (i + 1 != intArrayTest[i])
                    {
                        GoodIsOK = false;
                    }
                }
                Console.WriteLine("finished cycle " + intCount);
                intCount++;

            }

            Console.WriteLine();
            Console.WriteLine("The last unsorted set used.\n If our sorted set isn't right this is the set that broke it.");
            int j = 1;
            foreach (int i in intTempArray)
            {
                Console.Write(" {0,3}", i);
                if (j++ == 20)
                {
                    Console.WriteLine();
                    j = 1;
                }
            }
            Console.WriteLine();

            j = 1;
            Console.WriteLine("The set sorted.\n If this is not right, the previous string broke the sort code.");
            foreach (int i in intArrayTest)
            {
                Console.Write(" {0,3}", i);
                if (j++ == 20)
                {
                    Console.WriteLine();
                    j = 1;
                }
            }
            Console.WriteLine();
        }

        private static void BuildRandomArray(int[] intArrayTest)
        {
            // Assumes an existing array is passed in, current element values are ignored, and the array
            // is returned as a set of non-repeating random numbers from 1 up to the size of the array.

            // because we are going to fill the array with random numbers that run the range of the size of the array,
            // we can initialize the array to have the range of valid values (1 to n), putting the numbers in order
            // Then start at the bottom, and pick a random index between the last one we haven't done and 1, and fill
            // it with the value of the current last one
            Random rndRandomNumbers = new Random();
            for (int i = 0; i < intArrayTest.Length; i++)
            {
                intArrayTest[i] = i + 1; // initialize the array to have values starting at 1, 2, 3, .. up to the size
            }

            int intRndNum;
            int intTemp;
            for (int i = intArrayTest.Length - 1; i > 0; i--)  // walk from the max to the min+1 in our test array
            {                                                  // no reason to do i = 0 as this will copy to ourselves
                intRndNum = rndRandomNumbers.Next(i + 1);
                intTemp = intArrayTest[intRndNum];
                intArrayTest[intRndNum] = intArrayTest[i];
                intArrayTest[i] = intTemp;
            }


        }
    }
}

