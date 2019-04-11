using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackClass
{
    public class OurStack
    {
        private int topPointer;
        int [] ourData;

        public OurStack(int sSize)  // constructor
	    {
            // instead of a counter, we use an array index pointer = -1 to say "empty"
            // so our pointer points to the current top of stack, if it is a zero, then array element 0 holds a valid value which is the top of the stack
            ourData = new int[sSize];
            topPointer = -1;
	    }

        public void Push(int item)  // add an item to the stack
        {
            // if we are already pointing to the last element of the array, so we are full,  throw new OverflowException("Stack is full");
            if (topPointer == ourData.Length -1)
            {
                throw new OverflowException("Stack is full");
            }
            else
            {
                topPointer++;
                ourData[topPointer] = item;
            }

            // move our pointer to the next empty aray slot
            // copy the passed in value to the top of the stack (actaully, the highest occupied index of the array)
        }

        public int Pop() // remove and return an item from the stack
        {
            // check if stack is empty, if it is,  throw new IndexOutOfRangeException("Stack is empty");
            int temp;
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Stack is empty");
            }
            else
            {
                temp = ourData[topPointer];
                topPointer--;
                return temp;
            }

           // grab the value of the current top of stack
           // back up the top pointer to what is now the top of the stack
           // return  the Value;
        }

        public bool IsEmpty()
        {
            return (topPointer == -1) ? true : false;
        }

        public int Peek()
        {
            return IsEmpty() ? throw new IndexOutOfRangeException("Stack is empty") : ourData[topPointer];
             // again, check for empty
           // otherwise, return the value, but don't move the pointer
       }

        public void Clear()
        {
            ourData = new int[ourData.Length];
            topPointer = -1;
            // ??
        }
    }
}

