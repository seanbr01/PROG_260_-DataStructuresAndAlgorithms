using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

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
    }
}
