using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog260CourseProject
{
    class Book_BST
    {
        protected BSTnode bstTop;
        
        protected class BSTnode
        {
            public Book BookObject;
            public BSTnode LeftNode;
            public BSTnode RightNode;

            public BSTnode(Book key)
            {
                BookObject = key;
            }
            
            public void AddRec_BSTnode(Book keyParam)
            {
                if (keyParam == this.BookObject)
                {
                    throw new ApplicationException("Msg from BSTnode class: tried to add a duplicate value");
                }

                if (keyParam.ISBN < this.BookObject.ISBN)
                {
                    if (this.LeftNode == null)
                    {
                        BSTnode newBSTnode = new BSTnode(keyParam);
                        this.LeftNode = newBSTnode;
                        return;
                    }
                    else
                    {
                        this.LeftNode.AddRec_BSTnode(keyParam);
                        return;
                    }
                }
                else
                {
                    if (this.RightNode == null)
                    {
                        BSTnode newBSTnode = new BSTnode(keyParam);
                        this.RightNode = newBSTnode;
                        return;
                    }
                    else
                    {
                        this.RightNode.AddRec_BSTnode(keyParam);
                        return;
                    }
                }
            }
            
            public Book FindRec_BSTnode(int target)
            {
                BSTnode current = this;

                if (target == current.BookObject.ISBN)
                {
                    return current.BookObject;
                }
                else if (target > current.BookObject.ISBN)
                {
                    if (current.RightNode == null)
                    {
                        throw new ApplicationException("no such ISBN");
                    }
                    else
                    {
                        current = current.RightNode;
                        return current.FindRec_BSTnode(target);
                    }

                }
                else
                {
                    if (current.LeftNode == null)
                    {
                        throw new ApplicationException("no such ISBN");
                    }
                    else
                    {
                        current = current.LeftNode;
                        return current.FindRec_BSTnode(target);
                    }
                }
            }
        }

        public void AddRec(Book keyParam)
        {
            if (bstTop == null)
            {
                bstTop = new BSTnode(keyParam);
                return;
            }
            else
            {
                bstTop.AddRec_BSTnode(keyParam);
            }
        }
        
        public Book FindRec(int target)
        {
            if (bstTop == null)
            {
                throw new ApplicationException("no such ISBN"); ;
            }
            else
            {
                return bstTop.FindRec_BSTnode(target);
            }
        }

        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            GetAllRecr(bstTop, books);
            return books;
        }

        private void GetAllRecr(BSTnode current, List<Book> books)
        {
            if (current == null)
            {
                return;
            }

            GetAllRecr(current.LeftNode, books);
            books.Add(current.BookObject);
            GetAllRecr(current.RightNode, books);
        }
    }
}
