using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackClass;

namespace UnitTestStack
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // try the constuctor
        public void DoesConstructorThrowException()
        {
            OurStack testStack = new OurStack(10);
        }

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
            testStack.Push('7');
            Assert.AreEqual(false, testStack.IsEmpty());
        }

         [TestMethod]
         // try the myStack.IsEmpty_empty() property after pushing and popping
         public void IsEmptyAfterPopPropEmpty()
         {
             OurStack testStack = new OurStack(10);
             testStack.Push('7');
             testStack.Pop();
             Assert.AreEqual(true, testStack.IsEmpty());  
         }

         [TestMethod]
         // try the OverflowException when no room left in backing array
         [ExpectedException(typeof(OverflowException))]
      
        // [ExpectedException(typeof(OverflowException), "Stack is full");
         public void OverflowExceptionTest()
         {
             OurStack testStack = new OurStack(3);
             testStack.Push('7');
             testStack.Push('7');
             testStack.Push('7');
             testStack.Push('7');
         }

         [TestMethod]
        // try the IndexOutOfRangeException when try and pop and empty stack
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexOutOfRangeExceptionTest()
         {
            OurStack testStack = new OurStack(4);
            char x = testStack.Pop();
        }

         [TestMethod]
         // try the OverflowException when no room left in backing array, test message
         public void OverflowExceptionMessage()
         {
            string expected = "Stack is full";
            string actual = "";
            OurStack testStack = new OurStack(3);
            try
            {
                testStack.Push('7');
                testStack.Push('7');
                testStack.Push('7');
                testStack.Push('7');
            }
            catch (OverflowException ex)
            {
                actual = ex.Message;
            }
            finally
            {
                Assert.AreEqual(expected, actual);
            }
            
        }

         [TestMethod]
         // try the myStack.Peek() method
         public void PeekTest()
         {
            char expected = '4';
            OurStack testStack = new OurStack(5);
            testStack.Push(expected);
            char actual = testStack.Peek();
            Assert.AreEqual(expected, actual, "Peek returned wrong value.");
         }

         [TestMethod]
         // try the myStack.Peek() method again to make sure still there
         public void PeekAgainTest()
         {
            char expected = '4';
            OurStack testStack = new OurStack(5);
            testStack.Push(expected);
            char actual = testStack.Peek();
            actual = testStack.Peek();
            Assert.AreEqual(expected, actual, "Peek returned wrong value.");
        }
        
         [TestMethod]
         //clear method works
         public void ClearStackTest()
         {
            OurStack testStack = new OurStack(3);
            testStack.Push('7');
            testStack.Push('8');
            testStack.Push('9');
            testStack.Clear();
            Assert.IsTrue(testStack.IsEmpty());
        }

        

    }
}


