using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1stLinkedList;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // does LL hold data correctly, and in the correct order
        // insert 3 values at top, remove 2 from top, total should be = val of the last two added
        public void StoreAndRetrieveFromTop()
        {
            IntLinkedList myLL = new IntLinkedList();
            int total = 0;
            myLL.InsertAtFront(111);
            myLL.InsertAtFront(222);
            myLL.InsertAtFront(333);
            total = total + myLL.RemoveFromFront();
            total = total + myLL.RemoveFromFront();
            Assert.AreEqual<int>(555, total);
        }

        [TestMethod]
        // try and remove from top from an empty LL
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveFromEmptyLL()
        {
            IntLinkedList myLL = new IntLinkedList();
            myLL.RemoveFromFront();
        }

        [TestMethod]
        // Add entries, remove entries, make sure LL says its empty
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IsEmptyLLafterAddAndRemove()
        {
            IntLinkedList myLL = new IntLinkedList();
            myLL.InsertAtFront(111);
            myLL.InsertAtFront(222);
            myLL.RemoveFromFront();
            myLL.RemoveFromFront();
            myLL.RemoveFromFront();
        }

        [TestMethod]
        // does LL store negative numbers
        public void StoreNegativeNumbers()
        {
            IntLinkedList myLL = new IntLinkedList();
            int total = 0;
            myLL.InsertAtFront(-111);
            myLL.InsertAtFront(-222);
            total = total + myLL.RemoveFromFront();
            total = total + myLL.RemoveFromFront();
            Assert.AreEqual<int>(-333, total);
        }

        [TestMethod]
        // does LL store largest int32
        public void StoreLargestInt32()
        {
            IntLinkedList myLL = new IntLinkedList();
            myLL.InsertAtFront(Int32.MaxValue);
            int actual = myLL.RemoveFromFront();
            Assert.AreEqual<int>(2147483647, actual);
        }

        //*************************************************************************
        // new tests
        //*************************************************************************
        //*************************************************************************
        [TestMethod]
        // test Find(value) works when the value IS there
        public void TestFindValuePositive()
        {
            IntLinkedList myLL = new IntLinkedList();
            myLL.InsertAtFront(111);
            myLL.InsertAtFront(222);
            myLL.InsertAtFront(333);
            Assert.IsTrue(myLL.Find(222));
        }

        [TestMethod]
        // test Find(value) works when the value IS NOT there
        public void TestFindValueNegative()
        {
            IntLinkedList myLL = new IntLinkedList();
            myLL.InsertAtFront(111);
            myLL.InsertAtFront(222);
            myLL.InsertAtFront(333);
            Assert.IsFalse(myLL.Find(555));
        }

        [TestMethod]
        // test RemoveByValue(value) works when the values ARE there
        // remove first, middle, and last to test pointers are not getting corrupted
        public void RemoveByValue()
        {
            IntLinkedList myLL = new IntLinkedList();
            myLL.InsertAtFront(111);
            myLL.InsertAtFront(222);
            myLL.InsertAtFront(333);
            myLL.InsertAtFront(444);
            myLL.InsertAtFront(555);
            myLL.RemoveByValue(111);
            myLL.RemoveByValue(333);
            myLL.RemoveByValue(555);
            int actual = myLL.RemoveFromFront() + myLL.RemoveFromFront();
            Assert.AreEqual<int>(666, actual);
        }

        [TestMethod]
        // test RemoveByValue(value) returns true when the value IS there
        // remove first, middle, and last
        public void RemoveByValueTrue()
        {
            IntLinkedList myLL = new IntLinkedList();
            myLL.InsertAtFront(111);
            myLL.InsertAtFront(222);
            myLL.InsertAtFront(333);
            bool actual = myLL.RemoveByValue(222);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        // test RemoveByValue(value) works when the value IS NOT there
        // remove first, middle, and last
        public void RemoveByValueFalse()
        {
            IntLinkedList myLL = new IntLinkedList();
            myLL.InsertAtFront(111);
            myLL.InsertAtFront(222);
            myLL.InsertAtFront(333);
            bool actual = myLL.RemoveByValue(555);
            Assert.IsFalse(actual);
        }
    }
}