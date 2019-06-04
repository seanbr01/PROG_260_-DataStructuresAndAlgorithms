using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackClass
{
    public class OurStack
    {
        private int TopPointer;
        char [] ourData;

        public OurStack(int sSize)  // constructor
	    {
            // instead of a counter, we use an array index pointer = -1 to say "empty"
            // so our pointer points to the current top of stack, if it is a zero, then array element 0 holds a valid value which is the top of the stack
            ourData = new char[sSize];
            TopPointer = -1;
        }

        public void Push(char item)  // add an item to the stack
        {
            // if we are already pointing to the last element of the array, so we are full,  throw new OverflowException("Stack is full");
            if (TopPointer == ourData.Length -1)
            {
                throw new OverflowException("Stack is full");
            }
            else
            {
                TopPointer++;
                ourData[TopPointer] = item;
            }
             // move our pointer to the next empty aray slot
             // copy the passed in value to the top of the stack (actaully, the highest occupied index of the array)
        }

        public char Pop() // remove and return an item from the stack
        {
            // check if stack is empty, if it is,  throw new IndexOutOfRangeException("Stack is empty");
            if (TopPointer == -1)
            {
                throw new IndexOutOfRangeException("stack is empty");
            }
            else
            {
                //int returnValue = ourData[TopPointer];
                //// grab the value of the current top of stack
                //// back up the top pointer to what is now the top of the stack
                //TopPointer--;
                // // return  the Value;
                return ourData[TopPointer--];
            }
        }

        public bool IsEmpty()
        {
            if (TopPointer == -1)
            {
                return true;
            }
          
            return false;
        }

        public char Peek()
        {
            // check if stack is empty, if it is,  throw new IndexOutOfRangeException("Stack is empty");
            if (TopPointer == -1)
            {
                throw new IndexOutOfRangeException("stack is empty");
            }
            else
            {
                return ourData[TopPointer];
            }
        }

        public void Clear()
        {
            TopPointer = -1;
        }
    }
}

