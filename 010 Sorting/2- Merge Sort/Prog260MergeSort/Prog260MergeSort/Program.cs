using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog260MergeSort
{
    class Program  // started code using code from:  http://www.softwareandfinance.com/CSharp/MergeSort_Recursive.html
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MergeSort By Recursive Method");
            int arrayLenght;
          
                    
            int[] testArray1 = new int[] { 39, 35, 23, 12, 47, 42, 15, 28 };
            int[] testArray2 = new int[]  { 39, 24, 44, 31, 36, 9, 50, 23, 49, 2, 27, 43, 40, 10, 32, 48,22, 5, 3, 21, 26, 37, 11, 47, 6, 42, 20, 25,
                    12, 19, 1, 28, 7, 35, 33, 18, 13, 41, 17, 4, 46, 29, 14, 16, 34, 8, 30, 45, 15, 38 };
            int[] theArray = testArray1;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Before:");
            Console.WriteLine(string.Join("  ", theArray));
            arrayLenght = theArray.Length;
            MergeSortClass.MergeSort_Recursive(theArray, 0, arrayLenght - 1);

            Console.WriteLine();
            Console.WriteLine("After");
            Console.WriteLine(string.Join("  ", theArray));

            Console.WriteLine();
            Console.WriteLine("end of program");
            Console.ReadLine();

        }

       

       
    }
}
