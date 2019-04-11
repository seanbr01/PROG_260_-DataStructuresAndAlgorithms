using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestProjectStack
{
    [TestClass]
    public class UnitTest1
    {
        // verify that a newly created stack has no entries
        [TestMethod]
        public void IsInitialStackEmpty()
        {
            Stack TestStack = new Stack();
            int expected = 3;
            int actual = TestStack.Count;
            Assert.AreEqual(expected, actual, "stack was not zero length");
        }
        
        // varify peek works
        [TestMethod]
        public void PeakWorks()
        {
            Stack TestStack = new Stack();
            for (int i = 0; i < 3; i++)
            {
                TestStack.Push(i);
            }
            int expected = 2;
            int actual = (int)TestStack.Peek();
            Assert.AreEqual(expected, actual, "are not equal");
        }

        // verify pop works after 3 pushes
        [TestMethod]
        public void PopsAfter3Pushes()
        {
            Stack TestStack = new Stack();
        }
    }
}
