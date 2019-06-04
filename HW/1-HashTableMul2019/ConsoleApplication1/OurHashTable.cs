using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class OurHashTable
    {
        class LLnode
        {
            public int key { get; set; }
            public string value { get; set; }
        }

        // hash TABLE is size pSize, stores data in aarray that goes from 0 to pSize-1
        LinkedList<LLnode>[] betterHashTable;
        int tableSize;
        // constructor --- user specifies how big the table they want to use
        public OurHashTable(int pSize)
        {
            betterHashTable = new LinkedList<LLnode>[pSize];
            //hashTable = new string[pSize];
            tableSize = pSize;
        }

        public bool AddItem(int key, string value)
        {
            LLnode lLnode = new LLnode()
            {
                key = key,
                value = value
            };
            int hashedKey = HashMul(key);  // the "human readable" key gets hashed it into this value using the division method below

            Console.Write("next random key " + key + "  its hashedKey is " + hashedKey);  // as we walk thru our loop, show what we are doing
            if (betterHashTable[hashedKey] == null)  // null value means this slot is empty, so we can write our data (now a string) here.
            {
                var newLL = new LinkedList<LLnode>();
                newLL.AddFirst(lLnode);
                betterHashTable[hashedKey] = newLL;
                Console.WriteLine();
                return true;
            }
            else
            {
                betterHashTable[hashedKey].AddFirst(lLnode);

                Console.WriteLine("  <<< collision  at " + hashedKey); // else this spot was used, we will loose this data!
                return false;
            }
            
        }

        public string GetItem(int key)  // notice has fast a look up is!
        {
            LLnode lLnode = new LLnode();
            foreach (LLnode node in betterHashTable[HashMul(key)])
            {
                if (node.key == key)
                {
                    lLnode = node;
                }
            }
            return lLnode == null ? string.Empty : lLnode.value;
        }

        internal void PrintState()  // this is sort of a diagnostic aid, wouldn't normally have this
        {
            Console.WriteLine();
            Console.WriteLine("This is what is in the hash table.");
            Console.WriteLine();
            for (int j = 0; j < tableSize; j++)
            {
                Console.WriteLine("{0,3}    {1,3}", j, GetItem(j));
            }
        }

        // this is our key hashing algorithm, (using multiply) we could repalce this with other ones to try them out
        public int HashMul(int key)
        {
            double Multiplier = .6180339887;  // must be > 0 but less than 1
            // Knuth suggests .6180339887 Multiplier 
            double dblKey = key; // convert the int key into a double precision floating point
            double percent = Multiplier * dblKey;
            percent = percent - (int)percent; // get the fractional part
            return (int)(Math.Floor(percent * tableSize)); // round down to make sure you have a number that is within the table size
        }

    }
}
