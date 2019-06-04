using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog260_HeapSort
{
    class HeapSort
    {
        // impliments 2 different ways of getting the random array transformed into a valid heap
        // both versions start by building a Max-heap, so we end up with an array sorted from smallest to largest
        // we are using and array that uses the zero location!

        public void HeapSortDown(ref int[] PassedInArray)  // the public method that is called, with the array to be sorted passed in
                                                           // passed by reference so that when we are done, we have changed the values in the caller's array
        {
            FilterDown(ref PassedInArray);  // Stage 1: re-order the array to be a proper heap by calling our method to do it

            // at this point PassedInArray is now a proper heap, so on to Stage 2 
            int intEnd = PassedInArray.Length - 1;
            while (intEnd > 0)  // loop through as many times as there are values in the array
            {
                swap(ref PassedInArray[intEnd], ref PassedInArray[0]); // swap our top of the heap with the last element of the heap
                intEnd--;                                              //  and move the index of the last heap element up one 
                // the heap is now shorter by 1 and the sorted array is bigger by 1, and what was the top of the heap, is now in the sorted section of the array
                SiftDown(ref PassedInArray, 0, intEnd);                   // re-establish the heap property & repeat
            }
        }

        private void FilterDown(ref int[] intArray)  // used by HeapSortDown
        {
            int intLength = intArray.Length; // lenght of the the array is = the size of the heap (it can handle zero values at the end)
                                             // magic formula to find the bottom most partent that has a child is  (Array Length -1) / 2
            int intStart = (intLength - 1) / 2;   // Start with the last parent in heap and work down to the last element in the heap 
            while (intStart >= 0)
            {                                                    // 
                SiftDown(ref intArray, intStart, intLength - 1); // sift smaller elements down making sure the heap property
                                                                 // applies to each parent / children relationship
                                                                 // Sift down takes in the array we are working on, what node to start at, and the last node, which
                                                                 // is the lenght of the array -1 (because array's start at 0)
                intStart--;
            }
        }

        private void SiftDown(ref int[] intArray, int intStart, int intEnd) // used by HeapSortDown and FilterDown
        {
            int intRoot = intStart;   // pointer to the node in question

            while ((intRoot * 2) + 1 <= intEnd)                       // While the current "Root" node has a child...
            {
                int intChild = (intRoot * 2) + 1;                     // Set the current child to the left child
                if ((intChild < intEnd)
                    && (intArray[intChild] < intArray[intChild + 1])) // If right child is less than the current (left) child
                {
                    intChild++;                                       // Set the current child to the right child since it is larger
                }

                if (intArray[intRoot] < intArray[intChild])              // If the "Root" is smaller than the child
                {
                    swap(ref intArray[intRoot], ref intArray[intChild]); // Swap their values and
                    intRoot = intChild;                                  // make the child the "Root"
                }
                else
                {
                    return;
                }
            }
        }

        //=======================================================================================================
        //=======================================================================================================

        public void HeapSortUp(ref int[] intPassedArray)
        {
            FilterUp(ref intPassedArray);          // Have our dataset conform to the heap property
            int intEnd = intPassedArray.Length - 1;
            while (intEnd > 0)
            {
                int intCounter = 1;
                swap(ref intPassedArray[intEnd], ref intPassedArray[0]); // swap our largest element with the last
                intEnd--;                                                // element of the heap and move the index
                while (intCounter <= intEnd)                             // of the last heap element up on
                {                                                        // re-establish the heap property & repeat
                    SiftUp(ref intPassedArray, 0, intCounter);
                    intCounter++;
                }
            }
        }

        private void FilterUp(ref int[] intArray) // used by HeapSortUp
        {
            int intLength = intArray.Length;
            int intEnd = 1;
            while (intEnd < intLength)           // start with the root element and its first child and iteratively
            {                                    // work down the heap so that the largest element is worked up
                SiftUp(ref intArray, 0, intEnd); // to the root of the heap
                intEnd++;
            }
        }



        private void SiftUp(ref int[] intArray, int intStart, int intEnd)  // used by FilterUp
        {
            int intChild = intEnd;
            while (intChild > intStart)
            {
                int intParent = (intChild - 1) / 2;                        // Find the parent of the passed heap end
                if (intArray[intParent] < intArray[intChild])              // Is the parent smaller than the child?
                {
                    swap(ref intArray[intParent], ref intArray[intChild]); // If yes swap the parent and child values
                    intChild = intParent;                                  // and look at the parent node as a child and
                }                                                          // check its parent. Lather, rinse, repeat.
                else
                {
                    return;
                }
            }
        }




        private void swap(ref int intSwapA, ref int intSwapB) // used by both SiftDown and SiftUp
        // params are passed by ref so that this code will change the values in the code that calls them
        {
            int intTmp = intSwapA;
            intSwapA = intSwapB;
            intSwapB = intTmp;
        }
    }
}

