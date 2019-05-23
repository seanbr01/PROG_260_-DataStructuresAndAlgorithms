using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class OurHashTable
    {
        // hash TABLE is size pSize, stores data in aarray that goes from 0 to pSize-1
        string[] hashTable;  // Relying on new string array is initialized with all values = null
       
        // constructor --- user specifies how big the table they want to use
        public OurHashTable(int pSize)
        {
            hashTable = new string[pSize];
        }

        public bool AddItem(int key, string value)
        {
            int hashedKey;  // the "human readable" key gets hashed it into this value using the division method below
            hashedKey = HashMul(key);

            Console.Write("next random key " + key + "  its hashedKey is " + hashedKey);  // as we walk thru our loop, show what we are doing
            if (hashTable[hashedKey] == null)  // null value means this slot is empty, so we can write our data (now a string) here.
            {
                hashTable[hashedKey] = value;
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("  <<< collision  at " + hashedKey); // else this spot was used, we will loose this data!
                return false;
            }
            
        }

        public string GetItem(int key)  // notice has fast a look up is!
        {
            return hashTable[HashMul(key)];
        }

        internal void PrintState()  // this is sort of a diagnostic aid, wouldn't normally have this
        {
            Console.WriteLine();
            Console.WriteLine("This is what is in the hash table.");
            Console.WriteLine();
            for (int j = 0; j < 15; j++)
            {
                Console.WriteLine("{0,3}    {1,3}", j, hashTable[j]);
            }
        }

        // this is our key hashing algorithm, (using multiply) we could repalce this with other ones to try them out
        static public int HashMul(int key)
        {
            int tableSize = 15;
            double Multiplier = .6180339887;  // must be > 0 but less than 1
            // Knuth suggests .6180339887 Multiplier 
            double dblKey = key; // convert the int key into a double precision floating point
            double percent = Multiplier * dblKey;
            percent = percent - (int)percent; // get the fractional part
            return (int)(Math.Floor(percent * tableSize)); // round down to make sure you have a number that is within the table size
        }

    }
}
