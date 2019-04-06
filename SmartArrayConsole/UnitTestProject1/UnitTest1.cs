using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartArrayConsole;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        const int SMART_ARRAY_SIZE = 5;

        // SmartArray should initialize with all zeros
        [TestMethod]
        public void ArrayStartWithAll_0s()
        {
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            //testSmartArray.SetAtIndex(2, 5);  //used to verify test is working
            int actual = 0;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                actual = actual + testSmartArray.GetAtIndex(i);
            }
            // assert
            int expected = 0;
            Assert.AreEqual(expected, actual, 0.000001, "SmartArray not initilized to all zeros");
        }

        // SmartArray should allow setting the 0 location
        [TestMethod]
        public void SetLocation_0()
        {
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(0, 5);
            // assert
            int actual = testSmartArray.GetAtIndex(0);
            int expected = 5;
            Assert.AreEqual(expected, actual, 0.000001, "Did not set SmartArray loc 0 correctly");
        }

        // Should proprerly assign values to all array elements
        [TestMethod]
        public void AddValueToAllLocations()
        {
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            int actual = 0;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                testSmartArray.SetAtIndex(i, i);
                actual += testSmartArray.GetAtIndex(i);
            }
            // actual should equal 0 + 1 + 2 + 3 + 4 = 10
            int expected = 10;
            Assert.AreEqual(expected, actual, 0.000001, "SmartArray did not add correct values");
        }

        // SmartArray throw exception trying to set location greater than size of array
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetLocationAtSizeOfArrayValue()
        {
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(SMART_ARRAY_SIZE, 15);

            // assert is handled by ExpectedException
        }

        // SmartArray throw exception trying to set location to a negative location
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetNegativeLocation()
        {
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(SMART_ARRAY_SIZE, -5);

            // assert is handled by ExpectedException
        }

        // SmartArray should return true when using Find
        [TestMethod]
        public void FindValue_4()
        {
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            int test = 4;
            testSmartArray.SetAtIndex(2, test);
            
            Assert.IsTrue(testSmartArray.Find(test));
        }

        // SmartArray should return false when using Find
        [TestMethod]
        public void NotFindValue_4()
        {
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            int test = 4;

            Assert.IsFalse(testSmartArray.Find(test));
        }

        // SmartArray should resize to 10
        [TestMethod]
        public void Resize_10()
        {
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            int resize = 10;
            testSmartArray.Resize(resize);

            Assert.IsNotNull(testSmartArray.GetAtIndex(resize - 1));
        }

        // SmartArray should preserve values after resize from 5 to 10
        [TestMethod]
        public void ResizePreserveValues()
        {
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            int actual = 0;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                testSmartArray.SetAtIndex(i, i);
                actual += testSmartArray.GetAtIndex(i);
            }

            testSmartArray.Resize(10);

            // actual should equal 0 + 1 + 2 + 3 + 4 = 10
            int expected = 10;
            Assert.AreEqual(expected, actual, 0.000001, "SmartArray did not add correct values");
        }

        // SmartArray should resize to 5
        [TestMethod]
        public void Resize_5()
        {
            SmartArray testSmartArray = new SmartArray(10);
            testSmartArray.Resize(SMART_ARRAY_SIZE);

            Assert.IsNotNull(testSmartArray.GetAtIndex(SMART_ARRAY_SIZE - 1));
        }

        // SmartArray should preserve values after resize from 10 to 5
        [TestMethod]
        public void ResizePreserveValues_()
        {
            SmartArray testSmartArray = new SmartArray(10);
            int actual = 0;
            for (int i = 0; i < 10; i++)
            {
                testSmartArray.SetAtIndex(i, i);
                actual += testSmartArray.GetAtIndex(i);
            }

            testSmartArray.Resize(SMART_ARRAY_SIZE);

            // actual should equal 0 + 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 = 45
            int expected = 45;
            Assert.AreEqual(expected, actual, 0.000001, "SmartArray did not add correct values");
        }
    }
}
