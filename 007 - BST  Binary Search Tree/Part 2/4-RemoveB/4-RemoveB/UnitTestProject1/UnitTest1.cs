using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _260BasicBSTclass;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TotalEmptyTree()
        {
            BST myBST = new BST();  // instantiate an object of the class BST

            int actual = myBST.SumValues();
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void TotalOneEntry()
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            myBST.Add(10);
            int actual = myBST.SumValues();
            Assert.AreEqual(10, actual);
        }

        // try the IndexOutOfRangeException when try and pop and empty stack
        [ExpectedException(typeof(System.ApplicationException))]
        [TestMethod]
        public void RemoveNonexistentNode()
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            myBST.Add(10);
            myBST.Remove(9);
        }

        [TestMethod]
        public void CanBuildBST()
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            // adding in an order to match PPT diagram
           // adding in this order: 50  17  72  12  23  54  76  9  14  19  67 ");
            myBST.Add(50); // add top 3 nodes
            myBST.Add(17);
            myBST.Add(72);

            myBST.Add(12); // add 2 to left
            myBST.Add(23);

            myBST.Add(54); // add 2 to rigth
            myBST.Add(76);

            myBST.Add(9);  // add bottom left 3 nodes
            myBST.Add(14);
            myBST.Add(19);

            myBST.Add(67);  // add bottom rigth node

            int actual = myBST.SumValues();
            Assert.AreEqual(413, actual);
        }

        [TestMethod]
        public void RemoveTopNode()
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            // adding in an order to match PPT diagram
            // adding in this order: 50  17  72  12  23  54  76  9  14  19  67 ");
            myBST.Add(50); // add top 3 nodes
            myBST.Add(17);
            myBST.Add(72);

            myBST.Add(12); // add 2 to left
            myBST.Add(23);

            myBST.Add(54); // add 2 to rigth
            myBST.Add(76);

            myBST.Add(9);  // add bottom left 3 nodes
            myBST.Add(14);
            myBST.Add(19);

            myBST.Add(67);  // add bottom rigth node
            myBST.Remove(50);

            int actual = myBST.SumValues();
            Assert.AreEqual(363, actual);
        }

        [TestMethod]
        public void RemoveTopNodeAndLeftBottom()
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            // adding in an order to match PPT diagram
            // adding in this order: 50  17  72  12  23  54  76  9  14  19  67 ");
            myBST.Add(50); // add top 3 nodes
            myBST.Add(17);
            myBST.Add(72);

            myBST.Add(12); // add 2 to left
            myBST.Add(23);

            myBST.Add(54); // add 2 to rigth
            myBST.Add(76);

            myBST.Add(9);  // add bottom left 3 nodes
            myBST.Add(14);
            myBST.Add(19);

            myBST.Add(67);  // add bottom rigth node
            myBST.Remove(50);
            myBST.Remove(9);

            int actual = myBST.SumValues();
            Assert.AreEqual(354, actual);
        }

        [TestMethod]
        public void RemoveLeftMidDualNodeAndLeftBottom()
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            // adding in an order to match PPT diagram
            // adding in this order: 50  17  72  12  23  54  76  9  14  19  67 ");
            myBST.Add(50); // add top 3 nodes
            myBST.Add(17);
            myBST.Add(72);

            myBST.Add(12); // add 2 to left
            myBST.Add(23);

            myBST.Add(54); // add 2 to rigth
            myBST.Add(76);

            myBST.Add(9);  // add bottom left 3 nodes
            myBST.Add(14);
            myBST.Add(19);

            myBST.Add(67);  // add bottom rigth node
            myBST.Remove(17);
            myBST.Remove(9);

            int actual = myBST.SumValues();
            Assert.AreEqual(387, actual);
        }


        [TestMethod]
        public void RemoveRightMidDualNodeAndRightBottom()
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            // adding in an order to match PPT diagram
            // adding in this order: 50  17  72  12  23  54  76  9  14  19  67 ");
            myBST.Add(50); // add top 3 nodes
            myBST.Add(17);
            myBST.Add(72);

            myBST.Add(12); // add 2 to left
            myBST.Add(23);

            myBST.Add(54); // add 2 to rigth
            myBST.Add(76);

            myBST.Add(9);  // add bottom left 3 nodes
            myBST.Add(14);
            myBST.Add(19);

            myBST.Add(67);  // add bottom rigth node
            myBST.Remove(72);
            myBST.Remove(67);

            int actual = myBST.SumValues();
            Assert.AreEqual(274, actual);
        }

        [TestMethod]
        public void RemoveRightBottomLastLeftSide()
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            // adding in an order to match PPT diagram
            // adding in this order: 50  17  72  12  23  54  76  9  14  19  67 ");
            myBST.Add(50); // add top 3 nodes
            myBST.Add(17);
            myBST.Add(72);

            myBST.Add(12); // add 2 to left
            myBST.Add(23);

            myBST.Add(54); // add 2 to rigth
            myBST.Add(76);

            myBST.Add(9);  // add bottom left 3 nodes
            myBST.Add(14);
            myBST.Add(19);

            myBST.Add(67);  // add bottom rigth node
            myBST.Remove(14);
            

            int actual = myBST.SumValues();
            Assert.AreEqual(399, actual);
        }

        [TestMethod]
        public void RemoveMidSingleFromRightSide()
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            // adding in an order to match PPT diagram
            // adding in this order: 50  17  72  12  23  54  76  9  14  19  67 ");
            myBST.Add(50); // add top 3 nodes
            myBST.Add(17);
            myBST.Add(72);

            myBST.Add(12); // add 2 to left
            myBST.Add(23);

            myBST.Add(54); // add 2 to rigth
            myBST.Add(76);

            myBST.Add(9);  // add bottom left 3 nodes
            myBST.Add(14);
            myBST.Add(19);

            myBST.Add(67);  // add bottom rigth node
            myBST.Remove(54);


            int actual = myBST.SumValues();
            Assert.AreEqual(359, actual);
        }

        [TestMethod]
        public void RemoveAllOver()
        {
            BST myBST = new BST();  // instantiate an object of the class BST
            // adding in an order to match PPT diagram
            // adding in this order: 50  17  72  12  23  54  76  9  14  19  67 ");
            myBST.Add(50); // add top 3 nodes
            myBST.Add(17);
            myBST.Add(72);

            myBST.Add(12); // add 2 to left
            myBST.Add(23);

            myBST.Add(54); // add 2 to rigth
            myBST.Add(76);

            myBST.Add(9);  // add bottom left 3 nodes
            myBST.Add(14);
            myBST.Add(19);

            myBST.Add(67);  // add bottom rigth node
            myBST.Remove(17);
            myBST.Remove(72);
            myBST.Remove(14);
            myBST.Remove(50);


            int actual = myBST.SumValues();
            Assert.AreEqual(260, actual);
        }


       
    }
}
