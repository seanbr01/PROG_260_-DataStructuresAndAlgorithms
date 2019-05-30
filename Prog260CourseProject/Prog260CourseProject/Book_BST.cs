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

        public void AddRec(Book book)
        {
            if (bstTop == null)
            {
                bstTop = new BSTnode(book);
                return;
            }
            else
            {
                bstTop.AddRec_BSTnode(book);
            }
        }
        
        public Book FindRec(int isbn)
        {
            if (bstTop == null)
            {
                throw new ApplicationException("no such ISBN"); ;
            }
            else
            {
                return bstTop.FindRec_BSTnode(isbn);
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

        public void Remove(int isbn)
        {
            if (bstTop == null)
            {
                throw new ApplicationException("The Tree is Empty");
            }
            
            BSTnode parentNode = bstTop;
            BSTnode childNode;
            bool CameFromParentsLeftPointer = false;

            if (parentNode.BookObject.ISBN == isbn)
            {
                if (parentNode.LeftNode == null && parentNode.RightNode == null)
                {
                    bstTop = null;
                    return;
                }
                
                if (parentNode.LeftNode != null && parentNode.RightNode == null)
                {
                    bstTop = parentNode.LeftNode;
                    return;
                }
                if (parentNode.RightNode != null && parentNode.LeftNode == null)
                {
                    bstTop = parentNode.RightNode;
                    return;
                }
                
                BSTnode NodeWithKeyValueToOverWrite = parentNode;
                childNode = parentNode.LeftNode;
                
                CameFromParentsLeftPointer = true;
                while (childNode.RightNode != null)
                {
                    CameFromParentsLeftPointer = false;
                    parentNode = childNode;
                    childNode = parentNode.RightNode;
                }
                
                if (childNode.LeftNode == null)
                {
                    if (CameFromParentsLeftPointer)
                    {
                        parentNode.LeftNode = null;
                    }
                    else
                    {
                        parentNode.RightNode = null;
                    }

                    NodeWithKeyValueToOverWrite.BookObject.ISBN = childNode.BookObject.ISBN;
                }
                
                else
                {
                    if (CameFromParentsLeftPointer)
                    {
                        parentNode.LeftNode = childNode.LeftNode;
                    }
                    else
                    {
                        parentNode.RightNode = childNode.LeftNode;
                    }
                    
                    NodeWithKeyValueToOverWrite.BookObject.ISBN = childNode.BookObject.ISBN;
                }
                return;
            }

            while (true)
            {
                if (isbn < parentNode.BookObject.ISBN)
                {
                    if (parentNode.LeftNode == null)
                    {
                        throw new ApplicationException("Item is not in the Tree.");
                    }
                    childNode = parentNode.LeftNode;
                    CameFromParentsLeftPointer = true;
                }
                else
                {
                    if (parentNode.RightNode == null)
                    {
                        throw new ApplicationException("Item is not in the Tree.");
                    }
                    childNode = parentNode.RightNode;
                    CameFromParentsLeftPointer = false;
                }
                
                if (isbn == childNode.BookObject.ISBN)
                {
                    if (childNode.LeftNode == null && childNode.RightNode == null)
                    {
                        if (CameFromParentsLeftPointer)
                        {
                            parentNode.LeftNode = null;
                        }
                        else
                        {
                            parentNode.RightNode = null;
                        }

                        return;
                    }

                    if (childNode.LeftNode != null && childNode.RightNode == null)
                    {
                        if (CameFromParentsLeftPointer)
                        {
                            parentNode.LeftNode = childNode.LeftNode;
                        }
                        else
                        {
                            parentNode.RightNode = childNode.LeftNode; ;
                        }
                        return;
                    }
                    if (childNode.RightNode != null && childNode.LeftNode == null)
                    {
                        if (CameFromParentsLeftPointer)
                        {
                            parentNode.LeftNode = childNode.RightNode;
                        }
                        else
                        {
                            parentNode.RightNode = childNode.RightNode;
                        }
                        return;
                    }
                    
                    BSTnode NodeWithKeyValueToOverWrite = childNode;
                    parentNode = childNode;
                    childNode = parentNode.LeftNode;
                    CameFromParentsLeftPointer = true;
                    while (childNode.RightNode != null)
                    {
                        parentNode = childNode;
                        childNode = parentNode.RightNode;
                        CameFromParentsLeftPointer = false;
                    }
                    
                    if (childNode.LeftNode == null)
                    {
                        if (CameFromParentsLeftPointer)
                        {
                            parentNode.LeftNode = null;
                        }
                        else
                        {
                            parentNode.RightNode = null;
                        }
                        NodeWithKeyValueToOverWrite.BookObject.ISBN = childNode.BookObject.ISBN;
                    }
                    else
                    {
                        if (CameFromParentsLeftPointer)
                        {
                            parentNode.LeftNode = childNode.LeftNode;
                        }
                        else
                        {
                            parentNode.RightNode = childNode.LeftNode;
                        }
                        NodeWithKeyValueToOverWrite.BookObject.ISBN = childNode.BookObject.ISBN;
                    }
                    return;
                } 
                else
                {
                    parentNode = childNode;
                }
            }
        }

        public List<Book> GetTestData()
        {
            Random random = new Random();
            List<Book> books = new List<Book>()
            {
                new Book(){ ISBN = 6, Title = "Eternal Spring", Author = "Mandy Fletcher", PubYear = 1909, Rating = random.Next(6) },
                new Book(){ ISBN = 3, Title = "Dream Boat", Author = "Kellie Franklin", PubYear = 1938, Rating = random.Next(6) },
                new Book(){ ISBN = 4, Title = "2619: Rigel", Author = "Mable Henry", PubYear = 1958, Rating = random.Next(6) },
                new Book(){ ISBN = 5, Title = "Unleash The Truth", Author = "Noel Pearson", PubYear = 2014, Rating = random.Next(6) },
                new Book(){ ISBN = 8, Title = "Sean Bruce, The Book", Author = "Sean Bruce", PubYear = 1980, Rating = random.Next(6) },
                new Book(){ ISBN = 7, Title = "2015: Pollux", Author = "Beatrice Barber", PubYear = 2016, Rating = random.Next(6) }
            };
            return books;
        }
    }
}
