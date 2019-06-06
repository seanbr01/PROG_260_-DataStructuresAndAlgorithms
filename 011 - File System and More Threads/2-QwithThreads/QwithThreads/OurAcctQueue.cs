using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QwithThreads
{
    class OurAcctQueue
    {
        private int qTop;
        private int qBottom;

        BankAcct[] ourData;

        private int counter;

        public int QCount
        {
            get { return counter; }
            set { counter = value; }
        }


        public OurAcctQueue(int qSize)  // constructor
        {
            qTop = 0;
            qBottom = 0;
            counter = 0;
            ourData = new BankAcct[qSize];
        }

        public void Enqueue(BankAcct newItem)
        {
            if (counter >= ourData.Length)
            {
                throw new OverflowException("Q is full");
            }

            counter++;
            ourData[qBottom] = newItem;
            qBottom = ((qBottom + 1) == ourData.Length) ? qBottom = 0 : qBottom = qBottom + 1;
        }

        public BankAcct Dequeue()
        {
            if (counter == 0)
            {
                throw new IndexOutOfRangeException("Q is empty");
            }
            BankAcct returnValue = ourData[qTop];
            counter--;
            qTop = (qTop + 1 == ourData.Length) ? qTop = 0 : qTop = qTop + 1;
            return returnValue;

        }

        public bool IsEmpty()
        {
            return (counter == 0) ? true : false;
        }

        public BankAcct Peek()
        {
            return (counter == 0) ? throw new IndexOutOfRangeException("Q is empty") : ourData[qTop];
        }

        public void Clear()
        {
            qTop = 0;
            qBottom = 0;
            QCount = 0;
        }
    }
}
