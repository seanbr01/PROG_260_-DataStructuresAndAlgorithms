using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurRevString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string to check it is palindrome or not : ");
            Console.WriteLine("Enter the word exit to exit the program.");
            string word = Console.ReadLine();
            bool yesItIs;  // is it a Palindrome?
            word = word.ToLower(); // force to lower case
          
            while (word != "exit")
            {
                Console.WriteLine(RecStingRevPub(word));
                if (word == RecStingRevPub(word))  // compare the input to the string returned from the method
                {
                    yesItIs = true;
                }
                else
	            {
                    yesItIs = false;
	            }

                if (yesItIs)
                    Console.WriteLine("{0} is a Palindrome string\n", word);
                else
                    Console.WriteLine("{0} is not a Palindrome string\n", word);

                // do it again
                Console.WriteLine("Enter string to check it is palindrome or not : ");
                Console.WriteLine("Enter the word exit to exit the program.");
                word = Console.ReadLine();
                word = word.ToLower(); // force to lower case
            }

            Console.WriteLine("Goodbye.");
            Console.ReadLine();
        }

        //===================================================================================================
        // You must write code for this method that takes in a word and returns that word after reversing the order of the letters
        // You algorium MUST use recursion.  Any other solution is worth zero points, even if it works.

        //  method takes in original word and returns the result of a series of recursive calls
        public static string RecStingRevPub(string input) 
        {
            // write code here that calls itself (RecStingRevPub) over and over
            // and eventually returns the input word reversed, 
            // if input was "party" it would return to the call in Main  "ytrap"
            // I would expect your code to deal with 1 letter of the word in each cycle through
            // the recurion, either on the way down, or the way back out.

            if (input.Length > 0) // tests for empty string
            {
                char letter = input[input.Length - 1]; // gets last letter
                return letter + RecStingRevPub(input.Substring(0, input.Length - 1));
                //---------------------RECURSION-------------------------
            }
            else
            {
                return input;
            }
        }

    }
}
