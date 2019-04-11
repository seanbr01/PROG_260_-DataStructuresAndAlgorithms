﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackClass;

namespace UnitTestStack
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // try the myStack.IsEmpty_empty() property
        public void IsEmptyPropEmpty()
        {
            OurStack testStack = new OurStack(10);
            Assert.AreEqual(true, testStack.IsEmpty());
        }

         [TestMethod]
        // try the myStack.IsEmpty_notempty() property
        public void IsEmptyPropNotEmpty()
        {
            OurStack testStack = new OurStack(10);
            testStack.Push(77);
            Assert.AreEqual(false, testStack.IsEmpty());
        }

         [TestMethod]
         // try the myStack.IsEmpty_empty() property after pushing and popping
         public void IsEmptyAfterPopPropEmpty()
         {
             OurStack testStack = new OurStack(10);
             testStack.Push(77);
             testStack.Pop();
             Assert.AreEqual(true, testStack.IsEmpty());  
         }

         [TestMethod]
         // try the OverflowException when no room left in backing array
         [ExpectedException(typeof(OverflowException))]
         public void OverflowExceptionTest()
         {
             OurStack testStack = new OurStack(3);
             testStack.Push(77);
             testStack.Push(77);
             testStack.Push(77);
             testStack.Push(77);
         }

         [TestMethod]
         // try the IndexOutOfRangeException when try and pop and empty stack
         [ExpectedException(typeof(IndexOutOfRangeException))]
         public void IndexOutOfRangeExceptionTest()
         {
            OurStack testStack = new OurStack(1);
            int test = testStack.Pop();
         }

         [TestMethod]
         // try the OverflowException when no room left in backing array, test message
         [ExpectedException(typeof(OverflowException))]
         public void OverflowExceptionMessage()
         {
            OurStack testStack = new OurStack(1);
            testStack.Push(1);
            testStack.Push(2);
         }

         [TestMethod]
         // try the myStack.Peek() method
         public void PeekTest()
         {
            var testStack = new OurStack(3);
            int expected = 10;
            testStack.Push(30);
            testStack.Push(20);
            testStack.Push(expected);
            int actual = testStack.Peek();
            Assert.AreEqual(expected, actual);
        }

         [TestMethod]
         // try the myStack.Peek() method again to make sure still there
         public void PeekAgainTest()
         {
            var testStack = new OurStack(3);
            int expected = 10;
            testStack.Push(30);
            testStack.Push(20);
            testStack.Push(expected);
            int actual = testStack.Peek();
            actual = testStack.Peek();
            Assert.AreEqual(expected, actual);
        }
        
         [TestMethod]
         //empty the stack
         public void EmptyStackTest()
         {
            var testStack = new OurStack(1);
            testStack.Push(10);
            Assert.IsFalse(testStack.IsEmpty());
         }

        

    }
}


