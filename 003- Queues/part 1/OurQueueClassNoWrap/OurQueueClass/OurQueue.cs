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
        private int qEndOfLine;
        // is really a pointer to the next unused slot in the array

        int[] ourData; // underlying array to hold the data

        private int counter; // our field to keep track of how many

        public int QCount  // simple property to expose number in queue
        {
            get { return counter; }
            // set do not let outside program change this value
        }




        public OurQueue (int qSize)  // constructor, allow user to pick a reasonable upper limit for size
	    {
            ourData = new int[qSize];  // set the size of the array
            qServNext = 0;  // next one to take out --> value makes no sense as queue is empty
            qEndOfLine = 0;  // next unused is top of array
            counter = 0;  // zero makes sense
	    }

     

        public void Enqueue(int newItem)
        {
            counter++;  // adding one, so up the count on entries
            ourData[qEndOfLine] = newItem;  // put it where our bottom is
            qEndOfLine = qEndOfLine + 1;  // otherwise, just bump it one
        }

        public int Dequeue()
        {
            int returnValue = ourData[qServNext];  // use our pointer to find it
            counter--;    // one less, so adjust count
            qServNext = qServNext + 1; // else just bump it 1
            return returnValue;
        }

        public bool IsEmpty()
        {
            if (counter == 0)  // just check the count
            {
                return true;
            }
            else
            {
                return false;
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
