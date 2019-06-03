using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartArrayLibrary
{
    public class SmartArray
    {
        int[] UnderlyingArray; // using the C# simple array to hold our data

        public SmartArray(int origSize)  // constructor sets initial size
        {
            UnderlyingArray = new int[origSize];
        }

        public void SetAtIndex(int index, int val)
        {
            if (index < 0) 
            {
                throw new IndexOutOfRangeException("underflow");
            }
            else if (index > UnderlyingArray.Length - 1)
            {
                throw new IndexOutOfRangeException("overflow");
            }
            else
            {
                UnderlyingArray[index] = val;
                return;
            }
        }

        public int GetAtIndex(int index)
        {
            try
            {
                return UnderlyingArray[index];
            }
            catch (Exception)
            {

                if (index < 0)
                {
                    throw new IndexOutOfRangeException("underflow");
                }
                else if (index > UnderlyingArray.Length - 1)
                {
                    throw new IndexOutOfRangeException("overflow");
                }
            }
            finally
            {
                
            }
            return Int32.MinValue;
        }

        public void PrintAllElements()
        {
            for (int i = 0; i < UnderlyingArray.Length; i++)
            {
                Console.WriteLine(UnderlyingArray[i]);
            }
        }

        public bool Find(int val)
        {
            for (int i = 0; i < UnderlyingArray.Length; i++)
            {
                if (UnderlyingArray[i] == val)
                {
                    return true;
                }
            }
            return false;
        }

        public int Length // returns the array's length as a property
        {
            get { return UnderlyingArray.Length; }
        }

        public void Resize(int newsize)

        {
            int[] newArray = new int[newsize];

            //resize array larger
            if (UnderlyingArray.Length < newsize)
            {
                for (int i = 0; i < UnderlyingArray.Length; i++)
                {
                    newArray[i] = UnderlyingArray[i];
                }

                UnderlyingArray = newArray;
            }

            //resize array smaller
            else if (UnderlyingArray.Length > newsize)
            {
                for (int i = 0; i < newsize; i++)
                {
                    newArray[i] = UnderlyingArray[i];
                }

                UnderlyingArray = newArray;
            }

            //only gets here if the value is NaN
            else
            {
                throw new ArrayTypeMismatchException("Wrong data type");
            }
        }

    }  // end of SmartArray class
}

