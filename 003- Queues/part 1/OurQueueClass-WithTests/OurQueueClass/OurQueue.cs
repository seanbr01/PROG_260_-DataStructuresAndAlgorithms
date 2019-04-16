using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurQueueClass
{
    public class OurQueue
    {
        private int qServNext;
        private int qEndOfLine;  // is really a pointer to the next unused slot in the array
        
        int [] ourData; // underlying array to hold the data

        private int counter;

        public int QCount  // propery to get size of queue
        {
            get { return counter; }
           // set { counter = value; }  do not let outside program change this value
        }
        
        
        public OurQueue (int qSize)  // constructor
	    {
            qServNext = 0;
            qEndOfLine = 0;
            counter = 0;
            ourData = new int[qSize];
	    }

     

        public void Enqueue(int newItem)
        {
            if (counter >= ourData.Length)
            {
                throw new OverflowException("Q is full");
            }
            
            counter++;
            ourData[qEndOfLine] = newItem;
            qEndOfLine = qEndOfLine + 1;
            if (qEndOfLine == ourData.Length)
            {
                qEndOfLine = 0;
            }
        }

        public int Dequeue()
        {
            if (counter == 0)
            {
                throw new IndexOutOfRangeException("Q is empty");  // again, there is no "underflow" exception, so using this one
            }
            int returnValue = ourData[qServNext];
            counter--;
            qServNext = qServNext + 1;
            if (qServNext == ourData.Length)
            {
                qServNext = 0;
            }

            return returnValue;

        }

        public bool IsEmpty()
        {
            if (counter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Peek()
        {
            if (counter == 0)
            {
                throw new IndexOutOfRangeException("Q is empty");
            }
            else
	        {
                return ourData[qServNext];
	        }
       }

        public void Clear()
        {
            qServNext = 0;
            qEndOfLine = 0;
            counter = 0;
        }
    }
}
