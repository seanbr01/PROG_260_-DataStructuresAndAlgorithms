using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OurQueueClass;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Test 1: fill the q, then add and remove until counters have wrapped completely around back to 0
        [TestMethod]
        public void TestMethod_TestCounter()
        {
            OurQueue myQ = new OurQueue(4); 
            myQ.Enqueue(1);  // fill the q completely (with 4 entries)
            myQ.Enqueue(2);
            myQ.Enqueue(3);
            myQ.Enqueue(4);

            // remove and add an element 5 times to make sure the top and bottom pointers have all looped back to zero
            myQ.Dequeue(); // remove one
            myQ.Enqueue(5);  // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(6); // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(7); // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(8); // fill the last empty slot

            myQ.Dequeue(); // remove one
            myQ.Enqueue(9); // fill the last empty slot

            int actual = myQ.QCount;
            int expected = 4;
            Assert.AreEqual(expected, actual, "seems my counters are broken");
        }

        //  Test 2: test that clear does clear the q
        [TestMethod]
        public void TestMethod_clear()
        {
            OurQueue myQ = new OurQueue(4);
            myQ.Enqueue(1);  // fill the q completely (with 4 entries)
            myQ.Enqueue(2);
            myQ.Enqueue(3);
            myQ.Enqueue(4);

            myQ.Clear();

            int actual = myQ.QCount;
            int expected = 0;

            Assert.AreEqual(expected, actual, "seems my q is not empty after a clear");
        }

        //  Test 3: test values are correct after looping the pointers. Fill the Q, then pop and push 5 times and check the top
        // of the Q to make sure the correct value is stored there.
        [TestMethod]
        public void TestMethod_ValfterMovingPointersPast0()
        {
            OurQueue myQ = new OurQueue(4);
            myQ.Enqueue(1);  // fill the q  Q:  1
            myQ.Enqueue(2);  // Q: 2  1
            myQ.Enqueue(3);  // Q: 3  2  1
            myQ.Enqueue(4);  // Q: 4  3  2  1

            // walk the empty element 5 times to make sure the top and bottom pointers have all looped back to zero
            myQ.Dequeue(); // remove one
            myQ.Enqueue(5);  // fill the last empty slot    Q: 5  4  3  2

            myQ.Dequeue(); // remove one
            myQ.Enqueue(6); // fill the last empty slot    Q: 6  5  4  3

            myQ.Dequeue(); // remove one
            myQ.Enqueue(7); // fill the last empty slot    Q: 7  6  5  4

            myQ.Dequeue(); // remove one
            myQ.Enqueue(8); // fill the last empty slot    Q: 8  7  6  5

            myQ.Dequeue(); // remove one
            myQ.Enqueue(9); // fill the last empty slot    Q: 9  8  7  6

            int actual = myQ.Dequeue();
            int expected = 6;
            Assert.AreEqual(expected, actual, "Top of queue has incorrect value");

        }

        // Test 4: make sure queue is storing data correctly, fill it with known values and then pop them all out to verify
        [TestMethod]
        public void TestMethod_QstoresValues()
        {
            OurQueue myQ = new OurQueue(4);
            myQ.Clear();
            myQ.Enqueue(1111);  // fill the q
            myQ.Enqueue(2222);
            myQ.Enqueue(3333);
            myQ.Enqueue(4444);

            int actual = myQ.Dequeue() + myQ.Dequeue() + myQ.Dequeue() + myQ.Dequeue();
            int expected = 11110;
            Assert.AreEqual(expected, actual, "queue is not storing data accrurately");
        }

        [TestMethod]
        //Test 5 check that we throw the correct exception when trying to pop an empty Q
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethod_ThrowExceptionDequeueEmpty()
        {
            OurQueue myQ = new OurQueue(4);
            myQ.Clear();
            myQ.Dequeue();
        }


        [TestMethod]
        //Test 6 check that we throw the correct exception when we try to put an entry in when the queue is already full
        [ExpectedException(typeof(OverflowException))]
        public void TestMethod_ThrowExceptionEnqueueFull()
        {
            OurQueue myQ = new OurQueue(4);
            myQ.Clear();
            myQ.Enqueue(10);  // fill the q
            myQ.Enqueue(11);
            myQ.Enqueue(12);
            myQ.Enqueue(13);
            // try to put in one too many
            myQ.Enqueue(5);  // throw a full exception
        }

        [TestMethod]
        //Test 7 check that we throw the correct exception when we try to peek at an empty queue
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethod_ThrowExceptionPeekEmpty()
        {
            OurQueue myQ = new OurQueue(4);
            myQ.Clear();
            myQ.Peek();
        }

        //Test 8: check if peak 2 times gives correct value
        [TestMethod]
        public void TestMethod_PeakTwice()
        {
            OurQueue myQ = new OurQueue(4);
            myQ.Enqueue(1234);  // put stuff in Q
            myQ.Enqueue(2222);
            myQ.Enqueue(3333);
            myQ.Enqueue(4444);

            myQ.Peek(); // peek the 1st time, but does it really leave the Q unaltered?
            int actual = myQ.Peek(); // peek second time
            int expected = 1234;
            Assert.AreEqual(expected, actual, "Problem with peak, 2nd time is wrong");
        }
    }
}
