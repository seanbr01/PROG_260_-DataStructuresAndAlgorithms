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
            // does merge sort and also counts the inversions, note testarray5 is a huge file

            Console.WriteLine("MergeSort By Recursive Method");
            int len;
            ArrayReader myArrayReader = new ArrayReader();
            // create 3 test array cases
            int[] testArray1 = new int[] { 1, 2, 3, 4, 5, 6, 7 }; // result 0
            int[] testArray2 = new int[] { 7, 6, 5, 4, 3, 2, 1 };  // 21
            int[] testArray3 = new int[] { 1, 3, 2, 4, 5, 7, 6 };  // reuslt 2
            int[] testArray4 = myArrayReader.ReadArray(@"C:\Users\kurt.friedrich\Documents\IntegerArray.txt", 100000);
            // does 2,407,905,288 inversions


            int[] current;
            
            current = testArray3;   // change the array name 

            Console.WriteLine();
            Console.WriteLine(); 
                    Console.WriteLine(string.Join("  ", current));
            Console.WriteLine();
            Console.WriteLine();
                    len = current.Length;
                    Int64 inversionCount = MergeSort_Recursive(current, 0, len - 1, 0);
                    Console.WriteLine(string.Join("  ", current));
            Console.WriteLine();
            Console.WriteLine("saw {0} inversions", inversionCount);
            Console.WriteLine();
            Console.WriteLine();



        
            Console.WriteLine("end of program");
            Console.ReadLine();

        }

        static public Int64 MergeSort_Recursive(int[] inputArray, int leftPointer, int rightPointer, Int64 count)
        {
            int midPointer;
           
            if (rightPointer > leftPointer) // this is the bottom detector, when these pointers have walked till they meet, we 
                // stop calling ourself and start unwinding back to the top, 
            {
                midPointer = (rightPointer + leftPointer) / 2;  // break the current array segment in to 2 segments (note int math truncates)
                count =  MergeSort_Recursive(inputArray, leftPointer, midPointer, count); // call ourself to sort (and later on the unwind, merge) this left segment
                // passing any inversion count back out so can be passed along to next layer of recursion
                count =  MergeSort_Recursive(inputArray, (midPointer + 1), rightPointer, count); // call ourself to sort (and later on the unwind, merge) this right segment
                // when we finally get here, we are down to the smallest partition segments (left and rigth) and we merge them, pop up a layer in the recursion, and merge the next layer etc.
                count = count + DoMerge(inputArray, leftPointer, (midPointer + 1), rightPointer);  // here is where we accumulate the inversions from each segment
              
            }
            return count;
        }

        static private Int64 DoMerge(int[] inputArray, int leftPointer, int midPointer, int rightPointer)
        {
            // this is called over and over, on the returns "back up" from the bottom of the recursion to the top
            // it just copies values from the 2 segments into a temp array into correct order, 
            // but it is faster because it knows that each segment is already in order, 
            // so it can just keep comparing the current left to current rigth to make each decision
            int[] temp = new int[inputArray.Length];
            int i, left_end, num_elements, tmp_pos;
            Int64 inverCount = 0;
            
            // segment is inputArray [ leftPointer  midPointer  rightPointer]

            left_end = (midPointer - 1);
            tmp_pos = leftPointer;
            num_elements = (rightPointer - leftPointer + 1);

            // segment is inputArray [ leftPointer  midPointer  rightPointer]
            // copy to array is [tmp_pos (starts as leftPointer)      
                               
            // loop while walking the input array's leftPointer to the right until it counts up to the value of the left end (1 less than the midpoint)
            // and the midpointer of the input array is less than the right hand pointer
            while ((leftPointer <= left_end) && (midPointer <= rightPointer))
            {
                if (inputArray[leftPointer] <= inputArray[midPointer])  // if the value pointed to by the leftPointer is less than the midpointer
                    // then it was on the correct side, 
                {
                    temp[tmp_pos++] = inputArray[leftPointer++]; // so copy that value over to the temp array, and move both pointers
                }
                else  // otherwise, copy the value pointed by the mid pointer into the temp, (the mid pointer is pointing to the low side edge of the right side)
                {
                    temp[tmp_pos] = inputArray[midPointer];
                    inverCount = inverCount + (midPointer - tmp_pos);  // everything still on the right is an inversion 
                   // this is an inversion, plus every number still on the left side of the 2 halves.  Using temp_pos as it has moved along to where we are looking at on the left
                   
                    tmp_pos++;  // and inc both the temp pointer and the mid point pointer
                    midPointer++; 
                }
            }
            // next 2 whiles take care of left over right or left sides when the opposite side is empty
            while (leftPointer <= left_end)
            {
                temp[tmp_pos++] = inputArray[leftPointer++];
            }

            while (midPointer <= rightPointer)
            {
                temp[tmp_pos++] = inputArray[midPointer++];
            }

            for (i = 0; i < num_elements; i++)  // this copies over the values back to the orig array
            {
                inputArray[rightPointer] = temp[rightPointer];
                rightPointer--;
                
            }
            return inverCount;
        }

       
    }
}
