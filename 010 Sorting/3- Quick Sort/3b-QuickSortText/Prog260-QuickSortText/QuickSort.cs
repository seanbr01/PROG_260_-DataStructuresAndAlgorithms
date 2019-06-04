using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog260_QuickSortText
{
    class QuickSort
    {
        public void QSort(string[] A)  // public method that users call
        {
            QSort_private(A, 0, A.Length - 1); // then we call the private method
            // passing in the full array, and a pointer to the left (top)
            // of the array and a pointer to the rigth (bottom) of the array
            // we don't return anything since arrays are passed by reference, so the array we pass in will be sorted.
            // so start down the recurrsive rabbit hole calling the private worked method, over and over
        }

        private void QSort_private(string[] A, int leftPointer, int rightPointer)
        {
            Console.WriteLine("array during sorting");
            Console.WriteLine(string.Join("  ", A));
            Console.WriteLine();

            int pivotIndex = FlipInPartition(A, leftPointer, rightPointer);  // call our Partition method to "do the work"
            Console.WriteLine("array during sorting");
            Console.WriteLine("pivot is: " + pivotIndex);
            Console.WriteLine(string.Join("  ", A));
            Console.WriteLine();

            // for this level of the recursion.  It will pick a a pivot value
            // and then swap items with smaller items moved to the left, and larger moved to the right
            // we will be in a recursive spiral, so we will keep picking new pivotIndexes as we spriral down to the bottom
            // we we return from FlipInPartition, the pivotIndex is set to be how far left the rigth pointer moved

            // now we will recurse and call ourself to qsort the left side, and then call it again to sort the rigth side
            // each of those two will return here, and then each will be split in two again, and again, dividing the array
            // into 2 stubs, then 4, then 8, etc until the stubs are of size one, at that point everything has been moved in order
            if (pivotIndex - 1 > leftPointer)
                QSort_private(A, leftPointer, pivotIndex - 1);  // go sort the latest left segment

            // we will walk down the left left sub-arrays until we hit the bottom,
            // then we will return back up a level, which allows us to fall thru down into the next right segment

            if (pivotIndex + 1 < rightPointer)
                QSort_private(A, pivotIndex + 1, rightPointer);  // go sort the latest right segment
        }


        private int FlipInPartition(string[] A, int leftPointer, int rightPointer)
        {
            string pivotValue = A[leftPointer];  // just pick the current left (top) value as guess that its a good midpoint
            // if we are lucky, it is, and the algorithm works quickly.  If not, it runs a little longer, if its already in order, it's terrible!
            Console.WriteLine("into FLipInPartion, pivot value = {0}  leftpointer = {1}  right pointer = {2}", pivotValue, leftPointer, rightPointer);
            while (leftPointer < rightPointer)  // do this until the pointers meet  << Breakpoint here to follow the XLS
            {
                while (A[rightPointer].CompareTo(pivotValue) > 0 ) // walk the right pointer towards the middle from the right (from the bottom) until you find a value
                    // that is on the wrong size (because it is less then the pivotValue
                    rightPointer--;  // stop walking when (if) you find one

                while (leftPointer < rightPointer && (A[leftPointer].CompareTo(pivotValue) < 0) )  // walk the left pointer towards the middle (from the top) as long as the pointer's haven't met
                    // and as long as the value currently pointing is less than the pivotValue
                    leftPointer++;

                if (leftPointer < rightPointer)  // if the pointers met, that means none were out of order for this segment
                    Swap(A, leftPointer, rightPointer);  // otherwise, we have a value on the left and right that should be swapped, go do that
            }
            // if we leave the while loop of while loops, we know there are no more to be swapped across the pivot point.
            return rightPointer; //return the value of how far left we moved the rigth pointer (to logic that will recurse on both sides of this location)

        }

        private void Swap(string[] A, int indexLeft, int indexRight)
        {
            //swap pivot & right index
            string temp = A[indexLeft];
            A[indexLeft] = A[indexRight];
            A[indexRight] = temp;
            return;
        }
    }
}
