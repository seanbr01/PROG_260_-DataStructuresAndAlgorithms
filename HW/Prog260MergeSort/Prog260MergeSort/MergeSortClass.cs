using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog260MergeSort
{
    public static class MergeSortClass
    {
        public static void MergeSort_Recursive(int[] inputArray, int sLeftPointer, int sRightPointer)
        {  // add breakpoint here
            int midPointer;

            if (sRightPointer > sLeftPointer) // this is the bottom detector, when these pointers have walked till they meet, we 
            // stop calling ourself and start unwinding back to the top, 
            {
                // otherwise, continue the divide and conquer process
                midPointer = (sRightPointer + sLeftPointer) / 2;  // break the current array segment in to 2 segments (note int math truncates)
                MergeSort_Recursive(inputArray, sLeftPointer, midPointer); // call ourself to sort (and later on the unwind, merge) this left segment
                MergeSort_Recursive(inputArray, (midPointer + 1), sRightPointer); // call ourself to sort (and later on the unwind, merge) this right segment
                // when we finally get here, we are down to the smallest partition segments (left and rigth) and we merge them, pop up a layer in the recursion, and merge the next layer etc.
                DoMerge(inputArray, sLeftPointer, (midPointer + 1), sRightPointer);
            }
            // might help to think there is a else if { return } here, since that is what happens.
        }

        private static void DoMerge(int[] inputArray, int mLeftPointer, int mMidPointer, int mRightPointer)
        {
            // this is called over and over, on the returns "back up" from the bottom of the recursion to the top
            // it just copies values from the 2 segments into a temp array into correct order, 
            // but it is faster because it knows that each segment is already in order, 
            // so it can just keep comparing the current left to current rigth to make each decision
            int[] temp = new int[inputArray.Length];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mMidPointer - 1);
            tmp_pos = mLeftPointer;
            num_elements = (mRightPointer - mLeftPointer + 1);

            while ((mLeftPointer <= left_end) && (mMidPointer <= mRightPointer))
            {
                if (inputArray[mLeftPointer] <= inputArray[mMidPointer])
                    temp[tmp_pos++] = inputArray[mLeftPointer++];
                else
                    temp[tmp_pos++] = inputArray[mMidPointer++];
            }

            while (mLeftPointer <= left_end)
                temp[tmp_pos++] = inputArray[mLeftPointer++];

            while (mMidPointer <= mRightPointer)
                temp[tmp_pos++] = inputArray[mMidPointer++];

            for (i = 0; i < num_elements; i++)  // this copies over the values back to the orig array
            {
                inputArray[mRightPointer] = temp[mRightPointer];
                mRightPointer--;
            }
        }  // second break point here
    }
}
