using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stLinkedList
{
    public class IntLinkedList
    {
        //*********************************************************************************************
        // define our Nested Class, a class that defines the objects that are in the linked lists
        // could be private, but when you get into testing methodology, many times you will want child versions to use for testing.
        protected class LinkedListNode
        {
            public int node_data;  // Property holds the "data", this could be a complex object, like a Customer object
            public LinkedListNode node_next_pointer;  // Property holds the "pointer" (actually a node with a pointer in it)  to the next node in the list

            // constructor: call it to create and set value of data, note the node_next_pointer property is set to null by default      
            public LinkedListNode(int value)
            {
                node_data = value;
            }
        }
        //*********************************************************************************************

        // now define the IntLinkedList Class

        // the only data item the class has is the pointer (actually a node with a pointer in it) to the first item in the list 

        protected LinkedListNode frontOfList; // No constructor, but an undefined object has the value null; which is our flag that the list is empty

        // Method to add a node to the front of the list:
        public void InsertAtFront(int value)
        {
            LinkedListNode newNode = new LinkedListNode(value);  // create a new node
            newNode.node_next_pointer = frontOfList; // make this new first node point to what was just the first node;
            // if the List had been empty, then we just made the newNode point to "null", which says there is no 2nd node.
            frontOfList = newNode; // change the "reference" to front of list to point to this new one, which itself now points to the prior front of list
            // we are dealing with this frontOfList because this method specifically says to add to the front.  Later we will insert into other places.
        }

        //*********************************************************************************************
        //*********************************************************************************************
        // Method to remove the node from the front of the list
        public int RemoveFromFront()  // returns the "value" that the list object stores, in this case, an int
        {
<<<<<<< HEAD
            int returnVal;
=======
            int returnVal; 
>>>>>>> 95485143828fc4e7dc5ff24b0698dc63d7a3725e
            if (frontOfList == null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }
            else
            {
                returnVal = frontOfList.node_data; // get the data from the node at the front of the list
                frontOfList = frontOfList.node_next_pointer;  // copy the front of list's node's pointer to the next node, into the front of List
                // if there was not another node, we just copied a null into the pointer, which says the list is now empty
            }
            return returnVal;
        }

        //*********************************************************************************************
        //*********************************************************************************************
        public void Print()
        {
            // The four steps in the "Linked List Traversal" schema are:
            // 1.Setup
            // 2.Iteration Logic
            // 3.Work (that is done at each iteration)
            // 4.Teardown (anything that happens after the iteration)

            // a simple 'list traversal' schema, 
            // just start at top, grab one, use it, then use its pointer to change the current one to the next one.

            LinkedListNode current = frontOfList;     // 1.Setup
            while (current != null)                   // 2.Iteration Logic
            {
                Console.WriteLine(current.node_data); // 3.Work (done at each iteration)
                current = current.node_next_pointer;      // 2.Iteration Logic
            }
            // 4.Teardown (anything that happens after the iteration)
        }

        //*********************************************************************************************
        //*********************************************************************************************
        public bool Find(int target)
        {
            LinkedListNode cur = frontOfList;                         // 1.Setup
            while (cur != null) //if list empty, or at end of list: done 2.Iteration Logic
            {
                if (cur.node_data == target)                          // 3.Work 
                {
                    return true;                                     // 4. Tear down
                }
                cur = cur.node_next_pointer;                    // 2.Iteration Logic
            }
            return false;                                           // 4. Tear down
        }

        //*********************************************************************************************
        //*********************************************************************************************
<<<<<<< HEAD
        //RemoveByValue(value)

        public bool RemoveByValue(int target) // return true if found, false if not
        {
            // deal with condition if list is empty
=======
        // add and code a method  RemoveByValue(value)

        public bool RemoveByValue(int target) // return true if found, false if not
        {
            //    deal with condition if list is empty
>>>>>>> 95485143828fc4e7dc5ff24b0698dc63d7a3725e
            if (frontOfList == null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }
<<<<<<< HEAD

            // create a current “reference” variable
            LinkedListNode cur = frontOfList;

            // Since this code might have to change the value of frontOfList, we must deal with
            // that special condition.  So if value is found in the very first entry, we will return true
            // but first we have to remove this top node. To do that, we just change the frontOfList contents
            // to become the name of the 2nd node (or null if there was none), which effectively removes that 1st node
            // and makes what was the second node, the new top of node.  (if there was one)
            if (cur.node_data == target)  // Is the top node the one we are looking for?
            {
                frontOfList = cur.node_next_pointer;  // if yes, that cur.node_next_pointer is the name of the 2nd node
                // so now front of list thinks the top node is the one that used to be 2nd (or null)
                return true;
            }
            //Otherise, since the list was NOT empty, and the first item was NOT the one we wanted,
            // we will enter a loop and walk down the rest of all nodes looking for the one we want.

            // since we already checked 1st node, need to look past current one to next one to see if that’s the one. 
            // To remove any of the other nodes, we need to change the pointer on the node BEFORE the one we remove, 
            // so we want current to point to the node just BEFORE the one we want to remove

            // use while loop, where it either finds what it is looking for, and does a "return" to exit the loop
            // or it exits the loop when it gets to the 2nd to last node, and sees that the next node,
            // the last node, is still not the one it wants as the pointer in the 2nd to last is null. 
            while (cur.node_next_pointer != null)
            {
                // if the current node’s pointer sees that the next node has the value we are looking for, 
                // re-wire the current node’s next pointer to point to the node AFTER the next node, which will
                // which will leave the node we were looking for disconnected as an orphan.
                // and return true  (found it)
                if (cur.node_next_pointer.node_data == target)  // is this the one I want?
                {
                    // if yes, remove it by changing the pointer to jump to the next node.
                    cur.node_next_pointer = cur.node_next_pointer.node_next_pointer;
                    // cur is a 2nd name for the node about the one we want to remove, so by changing
                    // the value in cur, we are also changing it in the node element just above the one we remove.
                    return true;
                }
                cur = cur.node_next_pointer;    // if not, move the pointer, current, to the next node
                // the value might be null, which is ok, our while loop we detect we are done
            }
            return false;  // if walked the entire list and did not find, will return false
        }


    }
}
=======
            //    create a current “reference” variable
            LinkedListNode current = frontOfList;
            //     if value is found in the first entry, change the frontOfList contents to effectively remove that node, and return true, for success
            if (current.node_data == target)
            {
                frontOfList = current.node_next_pointer;
                return true;
            }

            //     else list was not empty, and the first item was not the one we wanted
            while (current.node_next_pointer != null)
            {
                if (current.node_next_pointer.node_data == target)
                {
                    current.node_next_pointer = current.node_next_pointer.node_next_pointer;
                    return true;
                }
                current = current.node_next_pointer;
            }
            //    already checked 1st one, need to look past current one to next one to see if that’s the one.As we need to
            //    change the pointer on the node BEFORE the one we remove, so we want current to point to node just before it


            //     do a while loop, where it exits if the current node’s pointer to the next node sees that the next node is null, which indicates we are at bottom of list
            //     in the while loop

            //     if the current node’s pointer sees that the next node has the value we are looking for,
            //     re - wire the current node’s next pointer to point to the node AFTER the next node, which will
            //     which will leave it disconnected as an orphan.
            //     and return true(found it)

            //     if not, move the pointer, current, to the next node
            //     the value might be null, which is ok, our while loop we detect we are done

            //     if walked the entire list and did not find, will return false

            return false;
        }




    }
    }
>>>>>>> 95485143828fc4e7dc5ff24b0698dc63d7a3725e
