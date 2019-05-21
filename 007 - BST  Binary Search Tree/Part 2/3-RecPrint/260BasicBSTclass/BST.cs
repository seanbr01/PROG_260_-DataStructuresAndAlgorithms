using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260BasicBSTclass
{
    class BST
    {
        protected BSTnode bstTop;  // our refernece node at the top of the BST

        // Note creating a class within a class.  Makes sense as this new class is really a data strcuture
        // which is unique to the outer class.
        protected class BSTnode  // private (by default) class within BST class, for the exclusive use of BST (protected so autotest code can get at it)
        {
            public int bstKey;  // uses key as "the data item" in our prior linked lists
            public BSTnode LeftNode;  // points to the next node on the left
            public BSTnode RightNode; // points to the next node on the right

            public BSTnode(int key)  // constuctor to create a new node.  It sets the key (data) value, but not the pointers, since 
            // we don'd know at this point where this new node will go in the BST
            // presumably, we could add more data fields to our nodes (Name, Address, State, etc)
            // and then this "value" would be like a primary key in a DB.
            {
                bstKey = key;
            }
            // >>>>>>> now adding recursive methods inside the BSTnode class, not the BST class!!  <<<<<<<<<<<<<<<<<

            // this method of a node is designed to be called recursively, moving itself (as a pointer to where we are in the tree)
            // down the left and rigth branches of the BST to find where we need to insert
            public void AddRec_BSTnode(int keyParam)  // TRICKY ***** this is a method of the BSTnode class, not the outer BST class!
            {
                // when we arrive here, we are in the context of a current node
                // first check if this node's key == the keyParam passed in.  The policy of our program (not all programs, just ours)
                // is that if the tree already has a node with this value, we  don't add a node.  We do not want to deal with duplicates
                if (keyParam == this.bstKey)
                {
                    throw new ApplicationException("Msg from BSTnode class: tried to add a duplicate value");
                }

                // otherwise, the question is, should I add a new node off one of the pointers in this node, or should I
                // pass that problem down a level (a node) using recusrion
                // the 2 "easy" cases are if based on the value of this node's key and the key value passed in,
                // I determine that I want to look left or rigth, and there is no node in the correct direction.
                // in that case I just add a new node at the end of this branch
                if (keyParam < this.bstKey)  // says this new node needs to go to the left of here
                {
                    if (this.LeftNode == null) // we want to add to the left, and there is no nodes there, so 
                    {
                        BSTnode newBSTnode = new BSTnode(keyParam);  // just create a new one
                        this.LeftNode = newBSTnode;  // and add it to the current nodes left pointer
                        return;
                    }
                    else  // there is a node already on the left, , so pass the problem down to that node
                    {
                        this.LeftNode.AddRec_BSTnode(keyParam);  // so make a recursive call ON THE LEFT NODE pointed to by the current node
                        return; // this return might not happen for a while ... if we recurse down a few more levels, then we'll have a chain of returns back to here
                    }
                }
                else // got here if the new node needs to go to the right side
                {
                    if (this.RightNode == null) // we want to add to the rigth, and there is no nodes there, so 
                    {
                        BSTnode newBSTnode = new BSTnode(keyParam);  // just create a new one
                        this.RightNode = newBSTnode;  // and add it to the current nodes right pointer
                        return;
                    }
                    else  // there is a node already on the right, so pass the problem down to that node 
                    {
                        this.RightNode.AddRec_BSTnode(keyParam);  // so make a recursive call ON THE Right NODE pointed to by the current node
                        return; // this return might not happen for a while ... if we recurse down a few more levels, then we'll have a chain of returns back to here
                    }
                }

            }

            // this method of a node is designed to be called recursively, moving itself (as a pointer to where we are in the tree)
            // down the left and rigth branches of the BST to find the one we are looking for
            public bool FindRec_BSTnode(int target)  // TRICKY ***** this is a method of the BSTnode class, not the outer BST class!
            {
                BSTnode current = this;  // could have passed in prior current node as a param, 
                // so we could use that to figure out where we are in the BST 
                // but with the recursive call to a method in >>ourself<<
                // the new current node IS the node we are executing this code in!
                // Had to create the CURRENT variable as it won't let me say  this = this.LeftNode
                // "this" is read only (it is a pointer to the current object, the code couldn't tolerate you moving the pointer
                // to ourself, that would be weird

                if (target == current.bstKey) // if the current node has the correct value
                {
                    return true;  // we have a match; other wise, we need to move down the right or left branch
                }
                else if (target > current.bstKey) // if target is bigger, we go down the right fork
                {
                    if (current.RightNode == null)
                    {
                        return false;  // we reached the end of the rigth side without finding a match
                    }
                    else
                    {
                        current = current.RightNode;  // set the value of the current object we are in to the one
                        // our current object is pointing to in its RightNode param, then step down into that node with the next line of code
                        return current.FindRec_BSTnode(target); // walk down the right fork one node by passing in the next node
                    }

                }
                else // must have been less than, so go down left fork
                {
                    if (current.LeftNode == null)
                    {
                        return false;  // we reached the end of the left side without finding a match
                    }
                    else
                    {
                        current = current.LeftNode;  // just like the Right code above
                        return current.FindRec_BSTnode(target); // walk down the left fork one node by passing in the next node
                    }
                }
            }  // end of class FindRec_BSTnode(int target) 

          


        }  // end of  BSTnode class defintion  

        //*****************************************************************************************************
        //*****************************************************************************************************
        // New method in our BST class defintion
        //*****************************************************************************************************
        //*****************************************************************************************************

        public void Print()
        {
            PrintRecr(bstTop);  // just start at the top, and then call the recursive print
        }

        private void PrintRecr(BSTnode current)
        {
            if (current == null)  { return; }
            PrintRecr(current.LeftNode);  // 3 lines walk down the left side until null, 
            Console.WriteLine(current.bstKey); // “do work” on the return,
            PrintRecr(current.RightNode);     // then turn down the rigth branch
            
            
            
            // what will it do if swap the 2 print (left and right) lines??

            //PrintRecr(current.RightNode);
            //Console.WriteLine(current.bstKey);
            //PrintRecr(current.LeftNode); 
        }


        //******************************************************************************************************
        //  Below are 4 mehthods from our two BST programs.
        //******************************************************************************************************

        // this method will add a new node at the correct location using a recursive approach
        public void AddRec(int keyParam)  // keyParam is the "value" that the node will hold
        {
            if (bstTop == null) // deal with an empty BST
            {
                bstTop = new BSTnode(keyParam); // add a new node in the bstTop position
                return;   // LeftNode and RightNode will default to null, which is correct
            }
            else
            {
                bstTop.AddRec_BSTnode(keyParam);
            }
        }



        // this is the Find in a BST using a recursive method of an internal class
        public bool FindRec(int target)  //  TRICKY *****  this is a method of the BST class, it sort of sets things up, then calls
        // the recursive method in our internal class to walk the tree
        {
            if (bstTop == null) // deal with an empty BST
            {
                return false;   // can't be here if there are none
            }
            else  // call the recursive method in the BSTnode class 
            {
                return bstTop.FindRec_BSTnode(target);  // calls a method in the current node
            }
        }



        //******************************************************************************************************
        //  Below are 2 mehthods from our first BST program.
        //******************************************************************************************************
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
                            break;  //  we are bailing out of the while
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

        // this is the Find in BST that does not use recursive logic
        public bool Find(int targetKey)  // return true if target value is in the tree 
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
                    if (targetKey == current.bstKey) // if the current node has the correct value
                    {
                        return true;  // we have a match; other wise, we need to move down the right or left branch
                    }
                    else if (targetKey > current.bstKey) // check if we want to follow the left or rigth pointer
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
