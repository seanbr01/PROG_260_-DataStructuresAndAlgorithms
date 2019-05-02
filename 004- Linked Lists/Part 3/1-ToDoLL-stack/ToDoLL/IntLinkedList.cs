using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLL
{
    class IntLinkedList
    {
        //*********************************************************************************************
        // define our Nested Class, a class that defines the objects that are in the linked lists
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

        //*********************************************************************************************

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

        // Method to remove the node from the front of the list
        public int RemoveFromFront()  // returns the "value" that the list object stores, in this case, an int
        {
            int returnVal;
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
        // new methods
        //*********************************************************************************************
        //*********************************************************************************************
        public void Print()
        {
            // As a quick summary, the four steps in the "Linked List Traversal" schema are:
            // 1.	Setup
            // 2.	Iteration Logic
            // 3.	Work (that is done at each iteration)
            // 4.	Teardown (anything that happens after the iteration)

            // a simple 'list traversal' schema, 
            // just start at top, grab one, use it, then use its pointer to change the current one to the next one.

            LinkedListNode cur = frontOfList;    // 1.	Setup
            while (cur != null)              // 2.	Iteration Logic
            {
                Console.WriteLine(cur.node_data);   // 3.	Work (that is done at each iteration)
                cur = cur.node_next_pointer;             // 2.	Iteration Logic
            }
            // 4.	Teardown (anything that happens after the iteration)
        }
        //*********************************************************************************************
        // Try to find a given BY VALUE
        public bool Find(int target)
        {
            LinkedListNode cur = frontOfList;    // 1.	Setup
            while (cur != null)              // 2.	Iteration Logic
            {
                if (cur.node_data == target)   // 3.	Work (that is done at each iteration)
                {
                    return true;
                }
                cur = cur.node_next_pointer;             // 2.	Iteration Logic
            }
            return false;
        }
        //*********************************************************************************************
        // RemoveByValue - imagine we used the Value as a key, and our LinkedListNode definition also included a data property, which could be an object like a Account, or Student
        public bool RemoveByValue(int target) // will return true if found one, false if there was not one
        {
            if (frontOfList == null)  // if list is empty
            {
                return false; //  not found
            }
            LinkedListNode current = frontOfList;
            bool myReturn = false;
            if (current.node_data == target)  // found it in the first entry, which requires changing the frontOfList to remove it
            {
                frontOfList = current.node_next_pointer;  // even if this was the only node, still works as frontOfList will get the null value
                return true;  // success
            }
            else // list was not empty, and the first item was not the one we wanted
            {
                // we already checked the first one, now we need to look past the current one to the next one to 
                // see if thats the one to be deleted.  Since we will need to chance the pointer on the node before the one
                // we remove, we don't want to move cur to the one to delete, but rather, have it one node in back of it
                while (current.node_next_pointer != null)              // this exits while we are at the n-1 node, but looking at the value of the last node
                {
                    if (current.node_next_pointer.node_data == target)   // look ahead one node, is the value what we are looking for
                    {
                        current.node_next_pointer = current.node_next_pointer.node_next_pointer;  // point the current node to the node after the next
                        // again, the value might be null, which is ok, we are done

                        return true; //success
                    }
                    current = current.node_next_pointer;             // move down the list

                }
            }
            return myReturn; // if walked the entire list and did not find, will return false
        }
       
    }
}