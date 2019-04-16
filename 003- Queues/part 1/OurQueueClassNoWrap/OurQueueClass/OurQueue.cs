using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurQueueClass
{
    public class OurQueue
    {
        private int qTop;
        private int qBottom;
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
            qTop = 0;  // next one to take out --> value makes no sense as queue is empty
            qBottom = 0;  // next unused is top of array
            counter = 0;  // zero makes sense
	    }

     

        public void Enqueue(int newItem)
        {
            counter++;  // adding one, so up the count on entries
            ourData[qBottom] = newItem;  // put it where our bottom is
            qBottom = qBottom + 1;  // otherwise, just bump it one
        }

        public int Dequeue()
        {
            int returnValue = ourData[qTop];  // use our pointer to find it
            counter--;    // one less, so adjust count
            qTop = qTop + 1; // else just bump it 1
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
            qTop = 0;
            qBottom = 0;
            counter = 0;
        }
    }
}
