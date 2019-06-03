using StackClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOurStack
{
    class Program
    {
        static void Main(string[] args)
        {
            string palindrome = Console.ReadLine().ToLower();

            OurStack myStack = new OurStack(palindrome.Length);  // build a short stack, easier to test edge conditions

            // students write program that asks for a word, then 
            // tells if was an Palindrome or not.

            // good words:  rotator  deified  reviver  civic  kayak  level  radar  tenet

            // algo:
            // split the letters into a char array
            char[] letters = palindrome.ToCharArray();
            // push the letters into our stack so can read them in reverse order
            for (int i = 0; i < letters.Length; i++)
            {
                myStack.Push(letters[i]);
            }
            // compare left to rigth [] with right to left (stack.Pop)
            int success = 0;
            foreach (char letter in letters)
            {
                if (letter == myStack.Pop())
                {
                    success++;
                }
            }
            // count of success will = length of word if success
            Console.WriteLine(success == letters.Length ? " SUCCESS!! The word is a Palindrome!!" : "FAILED! The word is not a palindrome.");

            Console.ReadLine();
        }

    }
}