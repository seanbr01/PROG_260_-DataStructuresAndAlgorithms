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
        private int iTop;
        int [] ourData;
        private Stack myStack;

        public OurStack(int sSize)  // constructor
	    {
            // instead of a counter, we use an array index pointer = -1 to say "empty"
            // so our pointer points to the current top of stack, if it is a zero, then array element 0 holds a valid value which is the top of the stack
            myStack = new Stack(sSize);
            for (int i = 0; i < myStack.Count; i++)
            {
                myStack.Push(-1);
            }
	    }

        public void Push(int item)  // add an item to the stack
        {
            // if we are already pointing to the last element of the array, so we are full,  throw new OverflowException("Stack is full");
            myStack.Push(item);

            // move our pointer to the next empty aray slot
            // copy the passed in value to the top of the stack (actaully, the highest occupied index of the array)
        }

        public int Pop() // remove and return an item from the stack
        {
            // check if stack is empty, if it is,  throw new IndexOutOfRangeException("Stack is empty");
            return IsEmpty() ? -1 : (int)myStack.Pop();

           // grab the value of the current top of stack
           // back up the top pointer to what is now the top of the stack
           // return  the Value;
        }

        public bool IsEmpty()
        {
            return (myStack.Count == 0) ? true : false;
        }

        public int Peek()
        {
            return IsEmpty() ? -1 : (int)myStack.Peek();
             // again, check for empty
           // otherwise, return the value, but don't move the pointer
       }

        public void Clear()
        {
            myStack.Clear();
            // ??
        }
    }
}

