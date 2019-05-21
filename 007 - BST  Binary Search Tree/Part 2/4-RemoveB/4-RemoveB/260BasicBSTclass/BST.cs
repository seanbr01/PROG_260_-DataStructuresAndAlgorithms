using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260BasicBSTclass
{
    public class BST
    {
        BSTnode bstTop;  // our refernece node at the top of the BST

        // our inner "node" class.
        class BSTnode  // private (by default) class used by BST
        {
            public int bstKey;  // uses key as "the data item" in our prior linked lists
            public BSTnode LeftNode;  // points to the next node on the left
            public BSTnode RightNode; // points to the next node on the right
            
            public BSTnode(int key)  // constuctor to create a new node.  It sets the key alue, pointers left null
            {
                bstKey = key;
            }
        }

        // this method will remove a new node with a given key value from the BST
        public void Remove(int keyParam)
        {



            //********************************************************************************************
            // handle case if the tree is empty
            //********************************************************************************************

            if (bstTop == null) // deal with an empty BST
            {
                throw new ApplicationException("Trying to remove a node from and empty tree.");
            }
            // done with empty tree case





            //********************************************************************************************
            // There is at least one node
            //********************************************************************************************
            
                // create variables we'll need for the top node or any other node
                BSTnode parentNode = bstTop; // set our walking pointer node to the top node
                BSTnode childNode; // define a node one level down from parent, when we find the right one, 
                // its what we will remove
                bool CameFromParentsLeftPointer = false; // Need to keep track if we got to the child from a parents 
                    // left or right pointer, so when we patch up the links, we patch back up to the correct left or right one

                //********************************************************************************************
                // All the rest of this method is 2 large sections, 
                // top section for removing the top node
                // then latter big section is for removing any other node
                //********************************************************************************************
                if (parentNode.bstKey == keyParam) // are we removing the top node?


                //***************************************************************************************************
                // so here is the first big section dealing with the top node
                // we will not have to walk the tree to find the node, we know its the top node
                // if the top node has 0 or 1 child, we will just adjust the value in the BSTtop pointer
                // but if the top node has 2 children, we will have to walk the tree to find the node to "promote" to the top
                //**************************************************************************************************
                {
                    // There are 3 possibilities for the top node, no children, 1 child, or 2 children
                    //********************************************************************************************
                    // top node has no children
                    //********************************************************************************************
                    if (parentNode.LeftNode == null && parentNode.RightNode == null)  // removing the one and only node
                    {
                        bstTop = null;
                        return; // and then leave
                    }

                    //********************************************************************************************
                    // top node has only 1 child
                    //********************************************************************************************
                    // at this point we know the child node has either one or two children, so check if its just one
                    if (parentNode.LeftNode != null && parentNode.RightNode == null) // parentNode has only a left node
                    {
                        bstTop = parentNode.LeftNode; // put the top node's one child node up into the the top  pointer
                        return; // and then leave
                    }
                    if (parentNode.RightNode != null && parentNode.LeftNode == null) // parentNode has only a right node
                    {
                        bstTop = parentNode.RightNode; // put the top node's one child node up into the the top  pointer
                        return; // and then leave
                    }
                    // if we got here, the 2 if's failed, so we know ...
                    
                    //********************************************************************************************
                    //  node has 2 children
                    //********************************************************************************************
                                      
                    BSTnode NodeWithKeyValueToOverWrite = parentNode; // save a pointer to the node to be removed by overwriting
                    
                    // walk left then rigth to find largest key on the left side of the BST
                    // move left  first
                    childNode = parentNode.LeftNode; // we know we have a left node at this point, as we know we had 2 children

                    // now walk down all right nodes until there are no more
                    CameFromParentsLeftPointer = true;  // we always start from the first left node, so remember this
                    while (childNode.RightNode != null) // now loop down the right
                    {
                        CameFromParentsLeftPointer = false; // if we got inside this while loop, then it is NOT the first left node to remove
                        parentNode = childNode;
                        childNode = parentNode.RightNode;
                    }
                    
                    //*********************************************************************************************
                    // at this point the childNode pointer is a copy of the node we want to copy to the top and then remove
                    // either the bottom far right node or it might have been the lonely 1st left node
                    // as we remove this node, there are only 2 cases, this node has no children, or it has 1 left node
                    // else we would have moved further to the right.
                    //*********************************************************************************************

                    // first see if this node to remove has no children
                    if (childNode.LeftNode == null) // if left is null, there are no children <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        if (CameFromParentsLeftPointer) // this is that one case where it was the first node on left we want to get ride of
                        {
                            parentNode.LeftNode = null; // snip off from the parent's left side and its gone
                        }
                        else // must have CameFromParents Right Pointer
                        {
                            parentNode.RightNode = null; // snip off from the parent's right side and its gone
                        }

                        // before we leave, we want to overwrite the NodeWithKeyValueToOverWrite's keyValue (the one we are logically removing)
                        //  with the keyValue of this childNode's keyValue. 
                        NodeWithKeyValueToOverWrite.bstKey = childNode.bstKey;// (in this top section, the NodeWithKeyValueToOverWrite is really the top node
                        // but the algorithm works here, and then below in the second section where it won't be the top node we are overwriting.
                    }
                        //*********************************************************************************
                    else  // if hit this else, it means the node to remove DOES have a valid left pointer (but it cannot have a rigth pointer, else we wouldn't be here)
                    {
                        if (CameFromParentsLeftPointer) // this is that one case where it was the first node on left we want to get ride of
                        {
                            parentNode.LeftNode = childNode.LeftNode; // clone the childs left branch onto the parent's pointer, leaving the child an orphan
                        }
                        else // we had started moving downt he rigth, so we want to wire up this orphan LeftNode to the parent's rigth pointer
                        {
                            parentNode.RightNode = childNode.LeftNode; // clone the childs left branch onto the parent's pointer, leaving the child an orphan
                        }

                        // before we leave, we want to overwrite the NodeWithKeyValueToOverWrite's keyValue (the one we thought we
                        // wanted to remove) with the keyValue of this "1 to the left, all the way to the right" node's keyValue.
                        NodeWithKeyValueToOverWrite.bstKey = childNode.bstKey;
                    }
                    return;  // we have removed the node


                }
                //********************************************************************************************
                // end of case where we were removing the top node
                //********************************************************************************************

                //********************************************************************************************
                //********************************************************************************************
                //********************************************************************************************


                //********************************************************************************************
                // Now enter the cases where we are removing some node OTHER than the top.
                // code is almost the same as removing the top node, but first we must walk the tree to find 
                // the node to remove, so we might have TWO walk processes
                // first we have to walk the tree to find the node to "remove" (overwrite) 
                // and then if that node has 2 children, we will have to walk the tree the res tof the way down
                // to find the node to "promote" to the top
                //********************************************************************************************

                //**********************************
                // find the node to remove
                //*********************************
                while (true) // loop as we walk down the tree and find the node, (or not)
                {
                    // as we come in, we know the parentNode is not the one we want to remove
                    if (keyParam < parentNode.bstKey) // if key less than, then we go left
                    {
                        // need to throw exception if there is no left node, means value does not exist in BST
                        if (parentNode.LeftNode == null)
                        {
                            throw new ApplicationException("No node with that value in the tree.");
                        }
                        childNode = parentNode.LeftNode;
                        CameFromParentsLeftPointer = true;
                    }
                    else // keyParam is greater, so we want to walk to ther rigth to find the node.
                    {
                        // need to throw exception if there is no right node, means value does not exist in BST
                        if (parentNode.RightNode == null)
                        {
                            throw new ApplicationException("No node with that value in the tree.");
                        }
                        childNode = parentNode.RightNode;
                        CameFromParentsLeftPointer = false;
                    }

                    //*********************************************************************************************
                    if (keyParam == childNode.bstKey) // if the current node has the correct value
                    // begin giant section where we have found that the childnode key is a match, so we want to remove the
                    // child node.  Again, there are the 3 cases, the child has 0, 1, or 2 children.
                    {
                                //********************************************************************************************
                                //  node has no children
                                //********************************************************************************************
                                if (childNode.LeftNode == null && childNode.RightNode == null) // true if no children
                                {
                                    if (CameFromParentsLeftPointer)
                                    {
                                        parentNode.LeftNode = null; // snip off from the parent's left side and its gone
                                    }
                                    else  // must have CameFromParents Right Pointer
                                    {
                                        parentNode.RightNode = null; // snip off from the parent's right side and its gone
                                    }

                                    return; // and then leave
                                }
                                //********************************************************************************************
                                //  node has only 1 child
                                //********************************************************************************************
                                // we know the child node has either one or two childer 
                                if (childNode.LeftNode != null && childNode.RightNode == null) // child has only a left node
                                {
                                    if (CameFromParentsLeftPointer)
                                    {
                                        parentNode.LeftNode = childNode.LeftNode; // put the child's one child node up into the parents pointer
                                    }
                                    else  // must have CameFromParents Right Pointer
                                    {
                                        parentNode.RightNode = childNode.LeftNode; ;
                                    }
                                    return; // and then leave
                                }
                                if (childNode.RightNode != null && childNode.LeftNode == null) // child has only a right node
                                {
                                    if (CameFromParentsLeftPointer)
                                    {
                                        parentNode.LeftNode = childNode.RightNode; // put the child's one child node up into the parents left pointer
                                    }
                                    else  // must have CameFromParents Right Pointer
                                    {
                                        parentNode.RightNode = childNode.RightNode; // put the child's one child node up into the parents right pointer
                                    }
                                    return; // and then leave
                                }


                                //********************************************************************************************
                                //  If we got here, the node to overwrite has 2 children, so we have to finsih the walk to find the highest value to copy here
                                //********************************************************************************************
                        
                                BSTnode NodeWithKeyValueToOverWrite = childNode; // save a pointer to this node we found that we will remove (replace)
                                parentNode = childNode; //  move the parent pointer down to this node we want to overwrite its value with
                                // and then start the walk first one time to the left, then rigth right right
                                childNode = parentNode.LeftNode; 
                                CameFromParentsLeftPointer = true;  // need to remember which parent pointer got us here, first time it is the left one
                                while (childNode.RightNode != null) // if we don't enter this while, means it was that first left node we will "promote"
                                {
                                    parentNode = childNode;  // otherwise, we start the loop of rigth rigth right
                                    childNode = parentNode.RightNode;
                                    CameFromParentsLeftPointer = false; // remember we got her from a parents rigth pointer
                                }
                                // when we get here, we reach the highest value node, at the end of the rigth chain (or it might have been the lonely 1st left node).

                                // we will have 2 possibiliiteis, this node to promite had 0 children, or it has one left node (it cannot have a rigth!)

                                // first see if this node to remove has no children
                                if (childNode.LeftNode == null) // are there no children?
                                {
                                    // yep, there are no children
                                    if (CameFromParentsLeftPointer) // this is that one case where it was the first node on left we want to get ride of
                                    {
                                        parentNode.LeftNode = null; // snip off from the parent's left side and its gone
                                    }
                                    else // we walked the right pointers, so 
                                    {
                                        parentNode.RightNode = null; // snip off from the parent's right side and its gone
                                    }

                                    // after removing this bottom of the chain node, we "re-instate it" by copying its value back up to the node
                                    // we wanted to "remove", by overwriting the NodeWithKeyValueToOverWrite's keyValue 
                                    // with the keyValue of this "1 to the left, all the way to the right" node's keyValue.
                                    NodeWithKeyValueToOverWrite.bstKey = childNode.bstKey;
                                }
                                else  // if hit this else, it means the node to remove has a valid left pointer
                                {
                                    if (CameFromParentsLeftPointer) // this is that one case where it was the first node on left we want to get ride of
                                    {
                                        parentNode.LeftNode = childNode.LeftNode; // clone the childs left branch onto the parent's pointer, leaving the child an orphan
                                    }
                                    else // we had turned and had been moving down the chain of rigth pointers
                                    {
                                        parentNode.RightNode = childNode.LeftNode; // clone the childs left branch onto the parent's pointer, leaving the child an orphan
                                    }

                                    // after removing this bottom of the chain node, we "re-instate it" by copying its value back up to the node
                                    // we wanted to "remove", by overwriting the NodeWithKeyValueToOverWrite's keyValue 
                                    // with the keyValue of this "1 to the left, all the way to the right" node's keyValue.
                                    NodeWithKeyValueToOverWrite.bstKey = childNode.bstKey;
                                }

                                return;

                    }  // end of if we found the node
                    else   // since we did not find the node with the key value, walk down a node
                    {
                        parentNode = childNode; // move the pointer down to the childnode, and do the while loop again
                        // if the childNode is a null, our existing code above will detect and throw exception
                    }

                }  // End of While loop -------------------------------------------------------------------------------

        }  // end of Remove method

        
        
        
        //================================================================================================================
        //================================================================================================================
        // method is like print, but used for testing
        //=================================================================================================================
        //================================================================================================================

        public int SumValues() // adds up the values of all node keys using recursion
        {
            return SumValuesRecur(bstTop, 0);
        }

        private int SumValuesRecur(BSTnode current, int pTotal)
        {
           
            if (current == null)
            {
                return pTotal;
            }
            pTotal = SumValuesRecur(current.LeftNode, pTotal);
            pTotal = pTotal + (current.bstKey);
            pTotal = SumValuesRecur(current.RightNode, pTotal);

            return pTotal; // code should never get here, have to keep the compiler happy
        }

        //====================================================================================
        // end of the SumValues method
        //====================================================================================



        //====================================================================================
        //====================================================================================
        // older methods below:  Print (rec), Add, and Find (non recur)
        //====================================================================================
        //====================================================================================

        public void Print()
        {
            PrintRecr(bstTop);
        }

        private void PrintRecr(BSTnode current)
        {
            if (current == null)
            {
                return;
            }
            PrintRecr(current.LeftNode);
            Console.WriteLine(current.bstKey);
            PrintRecr(current.RightNode);              // what will it do if swap hte 2 print (left and right) lines??
        }


        // this method will add a new node at the correct location
        public void Add(int keyParam)
        {
            if (bstTop == null) // deal with an empty BST
            {
                bstTop = new BSTnode(keyParam); // add a new node in the bstTop position
                return;   // LeftNode and RightNode will default to null, which is correct
            }
            else  // need to walk the 2 dim tree to find where to add this  
            {
                BSTnode current = bstTop; // since we got here, we know top is not empty

                while (true)
                {
                    if (keyParam < current.bstKey) // if true need to check off to the left
                    {
                        if (current.LeftNode == null) // would mean there are no more nodes on the left
                        {
                            current.LeftNode = new BSTnode(keyParam); // so make a new one, and change the existing
                            // node's left pointer to point to a new node
                            break;  // or return?    we are bailing out of the while
                        }
                        else
                        {
                            current = current.LeftNode;  // walk down a node, and let the while clause do it again
                        }
                    }
                    else if (keyParam > current.bstKey) // else need to check to the rigth
                    {
                        if (current.RightNode == null) // would mean there are no more nodes on the right
                        {
                            current.RightNode = new BSTnode(keyParam); // so make a new one, and change the existing
                            // node's right pointer to point to a new node
                            break;  //  we are bailing out of the while
                        }
                        else
                        {
                            current = current.RightNode;  // walk down a node, and let the while clause do it again
                        }
                    }
                    else  // the key is equal to and existing node, and we don't allow duplicates
                    {
                        throw new Exception("duplicate values not allowed");
                    }

                }
            }
        }

        public bool Find(int target)  // return true if target value is in the tree 
        {
            if (bstTop == null) // deal with an empty BST
            {
                return false;   // can't be here is there are none
            }
            else  // need to walk the 2 dim tree to try and find it  
            {
                BSTnode current = bstTop; // set our walking pointer node to the top node
                while (current != null) // loop as we walk down the tree unless we get to the bottom before finding it
                {
                    if (target == current.bstKey) // if the current node has the correct value
                    {
                        return true;  // we have a match; other wise, we need to move down the right or left branch
                    }
                    else if (target > current.bstKey) // check if we want to follow the left or rigth pointer
                    {
                        current = current.RightNode;  // since target is bigger, we go down the right fork
                        // which might be a null pointer, but our while loop will handle this
                    }
                    else
                    {
                        current = current.LeftNode; // must have been less than, so go down left fork
                    }

                }
                return false;
            }
        }
    }
}


