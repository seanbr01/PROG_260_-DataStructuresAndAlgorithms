using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QwithThreads
{
    class OurAcctQueue  // very much like our queue that held integers, this one holds BankAcct objects
    {
        private int qTop;
        private int qBottom;

        BankAcct[] ourData;  // an underlying array, this time it will hold objects

        private int counter;

        public int QCount
        {
            get { return counter; }
           // set { counter = value; }  // read only
        }


        public OurAcctQueue(int qSize)  // constructor
        {
            qTop = 0;
            qBottom = 0;
            counter = 0;
            ourData = new BankAcct[qSize];
        }

        public void Enqueue(BankAcct newItem)  // almost identical, excpet we are using an object, not an int
        {
            if (counter >= ourData.Length)
            {
                throw new OverflowException("Q is full");
            }

            counter++;
            ourData[qBottom] = newItem;
            if ((qBottom + 1) == ourData.Length)
            {
                qBottom = 0;
            }
            else
            {
                qBottom = qBottom + 1;
            }
        }

        public BankAcct Dequeue()  // almost identical, excpet we are using an object, not an int
        {
            if (counter == 0)
            {
                throw new IndexOutOfRangeException("Q is empty");
            }
            BankAcct returnValue = ourData[qTop];
            counter--;
            if ((qTop + 1) == ourData.Length)
            {
                qTop = 0;
            }
            else
            {
                qTop = qTop + 1;
            }
            return returnValue;

        }

        public bool IsEmpty()  // same
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

        public BankAcct Peek()   // almost identical, excpet we are using an object, not an int
        {
            if (counter == 0)
            {
                throw new IndexOutOfRangeException("Q is empty");
            }
            else
            {
                return ourData[qTop];
            }
        }

        public void Clear()  // same
        {
            qTop = 0;
            qBottom = 0;
            counter = 0;
        }
    }
}
