using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
      
        static void Main(string[] args)
        {
            // make up 20 possible strings to store in hash table, using an empty [0] location for convenience, so array has 21 spots
            // will use loc's 1 thru 20 in our code below
            string[] dataArray = new string[21] {"empty by design", "Ella", "Joseph", "Cameron", "Bethany", "Luke", "Holly", "Courtney",
                "Amber", "Caitlin", "William", "Jake", "Joshua", "Jamie", "Eleanor", "Olivia", "Laura", "Lewis", "Benjamin", "Ethan", "Jade"};

            // these next two variables can be experimented with to see how they affect probability of collisions
            int HashTableSize = 20;  // how much array space we will allow for our table
            int howMany = 19;  // how many names we will try and save in the hash table

            // instantiate our hash table instance
            OurHashTable theHashTable = new OurHashTable(HashTableSize);

            // now generate random keys to assign to these 20 names, random so that the program runs differently each time it is run
            // allowed key range is 1 to 20, since that's how many unique names we might store from our string dataArray
            Random myRandom = new Random();
            // this part is just to replace a human entering data, just a simulation to test our hash table
            // first create specified number of  unique random numbers bewteen 1 and 20 (to point to some of our strings)
            int[] ourKeys = UniqueRandomArray(21, 1, 21); // create 21 random keys with values between 1 and 21, use parallel arrays 
            // to assign these random keys to our names array

            string value;  // the string value corresponding to the human readable key, the value stored with the key, in this case, a name
            int numcollisions = 0;  // we will keep track of how many
            bool success; // did the insert into hash table succeed?

            int userKey; // the human readable key we will insert with
            // using our 2 arrays, create entries to put in our hash table
            for (int loopPointer = 1; loopPointer < howMany+1; loopPointer++)  // insert each of "howMany" entries into the hash table
            // storing the value for a particular key into the hashtable at the location specified by doing the hash algo on that key
            {
                userKey = ourKeys[loopPointer];  // get its key from the key array
                value = dataArray[loopPointer];  // get our string from out dataArray
                success = theHashTable.AddItem(userKey, value);
                if (!success)
                {
                     numcollisions++;  // count the collision occurance
                }
                
            }

            // ok, done storing data into the hash table, write out its contents
            //theHashTable.PrintState();

           
            Console.WriteLine();
            Console.WriteLine("We lost {0} pieces of data", numcollisions);
            Console.WriteLine();

            // ok, lets try and retrieve the data
            Console.WriteLine();
            Console.WriteLine("now we will see what our hashtable returns based on the keys we used to enter data");
            Console.WriteLine("for every collision we had storing the data, we get erroneous data returned");
            Console.WriteLine("find the duplicate values returned.");
            Console.WriteLine();
            //int counter = 0;
            for (int i = 1; i < howMany+1; i++)
            {
                Console.WriteLine("if enter key of {0} we get back: {1}", ourKeys[i],  theHashTable.GetItem(ourKeys[i]) );
                //counter = i;
            }
            //Console.WriteLine(counter);
            for (int i = 1; i < howMany+1; i++)
            {
                Console.WriteLine("if enter key of {0} we get back: {1}", ourKeys[i],  theHashTable.GetItem(ourKeys[i]) );
            }
            Console.ReadLine();
        }

     
     

        // this method is just part of replacing a human entering data with simualtion code
        // this method will build an array of random numbers, making sure no two are the same
        // you set the range of the randmon numbers, lower and upper.
        public static int[] UniqueRandomArray(int arraySize, int Min, int Max)
        {
            int[] UniqueArray = new int[arraySize];
            Random rnd = new Random();
            int Random;
            for (int arrayIndex = 0; arrayIndex < arraySize; arrayIndex++) // walk thru the array and do something for each element
            {
                Random = rnd.Next(Min, Max+1); // have to add 1 to max because of goofy .NET implimentation of Random
                for (int j = arrayIndex; j >= 0; j--)  // walk from the current arrayPointer backwards down to the 0 element 
                {
                    if (UniqueArray[j] == Random)  // check if we have already used this random number in any of the already assigned spots
                    { 
                        Random = rnd.Next(Min, Max+1);  // if we have used it already, pick a new number, and start back at the current arrayPointer again
                        j = arrayIndex;   // reset the inner loop to start all over again
                    }
                }
                UniqueArray[arrayIndex] = Random; // if none of the slots have used this number, we are free to use it here.
            }
            return UniqueArray;
        }


    }
}
