using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260LL_RecPrinting
{
    class IntLinkedList
    {
        protected class LinkedListNode
        {
            public int node_data;
            public LinkedListNode node_next_pointer;

            // constructor: call it to create and set value of data, note the m_next field will be null by default      
            public LinkedListNode(int value)
            {
                node_data = value;
            }
        }

        // variable to hold name of first LL entry  (starts at null, which is good)
        protected LinkedListNode frontOfList;

        //**************************************************************************************
        //  methods
        //**************************************************************************************
      

        //**************************************************************************************
        // itterative print
        //**************************************************************************************
        public void Print()
        {
            LinkedListNode cur = frontOfList;
            while (cur != null)
            {
                Console.WriteLine(cur.node_data);   // Walk down the list moving a reference pointer
                cur = cur.node_next_pointer;
            }
        }


        //**************************************************************************************
        // recursuve print forward  public method
        //**************************************************************************************
        public void RecursivelyPrintForward()  // walk the LL and print out value in the order they are in the list
        {
            LinkedListNode cur = frontOfList;  // set up our name pointer
            if (cur != null)   // make sure the list is not empty
            {
                RecursivelyPrintForwardWorker(cur); // call the recursive routine
            }
        }


        // recursuve print forward  recursive worker private method
        private void RecursivelyPrintForwardWorker(LinkedListNode cur)
        {
            Console.WriteLine(cur.node_data);  // do work on the way DOWN the rabbit hole
            if (cur.node_next_pointer != null)   // check if done, if not, go down further
            {
                cur = cur.node_next_pointer;
                RecursivelyPrintForwardWorker(cur);
                //-------------------------------------------------------------------------------  nothing done on return from call
            }
            return;
        }



        //**************************************************************************************
        // recursuve print backward -- pretty hard to do with an iterative loop
        //**************************************************************************************
        public void RecursivelyPrintBackward()  // walk the LL and print out value in the order they are in the list from the back to the front
        {
            LinkedListNode cur = frontOfList;  // set up our name pointer
            if (cur != null)  // make sure the list is not empty
            {
                RecursivelyPrintBackwardWorker(cur);  // call our recusive list
                //------------------------------------------------------------------------- work gets done only AFTER retrun
                Console.WriteLine(cur.node_data);
            }
        }

        private void RecursivelyPrintBackwardWorker(LinkedListNode cur)
        {
            if (cur.node_next_pointer != null)  // are we done?  if not, just walk down
            {
                cur = cur.node_next_pointer;
                RecursivelyPrintBackwardWorker(cur);
                //--------------------------------------------------------------------------------- work gets done only AFTER retrun
                Console.WriteLine(cur.node_data);
            }

        }


        //**************************************************************************************
        // Prior non-recursive methods
        //**************************************************************************************

        public void InsertAtFront(int value)
        {
            if (value == Int32.MinValue)
            {
                throw new Exception("illegal data value"); //we use this value as the error return value, so we don't let it in as good data
            }
            LinkedListNode newNode = new LinkedListNode(value);  // create a new node

            newNode.node_next_pointer = frontOfList; // make the new first node point to what was just the first node
            frontOfList = newNode; // change the pointer to front of list point to the new one, which itself now points to the prior front of list
        }


    }


}