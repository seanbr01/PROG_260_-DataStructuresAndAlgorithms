using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdRecursionNtothePowerM
{
    class Program
        /*  this program takes in an integer and raises it to some power as specified by the user
         * since raising a number to a power is done by multiplying the number by itself over and over again
         * (per the power), it is a perfect example of a useful, yet simple recursion program
         * 
         * ****************************************************************************************************
         * Progam also introduces idea of a public interface method, which in turn uses a private recursive interface 
         * *****************************************************************************************************
        */
    {
        static void Main(string[] args)
        {
            // Main just gathers the user's input, makes a call to the recursive method, and writes out the results.
            PowersRecursion myPowersRecursion = new PowersRecursion();
            Console.Write("enter the integer you want to raise to some power: ");
            int baseNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("enter the integer for power you want to raise your number to: ");
            int powerNumber = Convert.ToInt32(Console.ReadLine());

            string answer;
            try
            {
                answer = myPowersRecursion.raiseToPowerPublicInterface(baseNumber, powerNumber).ToString();
            }
            catch (Exception ex)
            {
                answer = ex.Message;
            }
            
            
            Console.WriteLine("The answer is: {0}", answer);
            Console.ReadLine();
        }
    }

    public class PowersRecursion
    {
        public int raiseToPowerPublicInterface(int baseValue, int power)  // this is the public interface, 
            // which will validate input and in general, do things that only need to be done once, not in 
            // the recursion.  Then it calls a private recursive method to do the work
        {
            int sign = 1;  // flag to deal with -x to the nth power, which we allow
            if (power < 0)
            {
                throw new IndexOutOfRangeException("This program does not process negative power values."); 
            }
            if (power == 0 && baseValue == 0)
            {
                throw new IndexOutOfRangeException("0 raised to the 0 power is undefined.");
            }

            if (baseValue < 0)
            {
                baseValue = baseValue * -1; // if they pass in a negative base number, flip it to postitive
                sign = -1; // but remember that it was negative
            }
            if (power % 2 == 0) // if its even, then a negative base to an even power is positive
            {
                sign = 1;
            }

            // Now we finally call the private recursive method, and let its return just pass right thru to our return
            // after we correct the answer if the base number was negative and the power odd
            int returnFromRec = raiseToPowerPublicInterface(baseValue, power);
            return sign * returnFromRec;
        }

        private int raiseToPowerPrivateRecurrsive(int baseValue, int power)  // this is the private recursive method
        {
            // BASE CASE
            // generally first deal with any Base Case, these are cases which should return without using recursion
            if (power == 0)
            {
                // this will handle the simple case when the user passes in a zero
                // as any number (except 0) raised to the zero power is 1 (don't ask me why, the mathematicians say so!)

                // but ALSO, it handles the case when the recursion winds down to the bottom of its iterations
                // we will keep calling ourself UNTIL the power gets to zero
                return 1;
            }

            //***********************************************************************************************************************
            // RECURSIVE CASE when baseValue and power are both ints of 1 or greater
            int intermediateResult = raiseToPowerPrivateRecurrsive(baseValue, power - 1);
            // note the -1, each time we reduce the power int by 1, so this will eventually count down to zero, 
            // and then the above check will get us out of here and return the true answer
            // the above code just keeps calling copies of this method, not really doing anything, 
            // except setting up how many times the code that comes
            // next will be excuted when the chain of returns starts happening.

            //***********************************************************************************************************************

            // DO THE ACTUAL WORK : this code only gets executed on the RETURNS,
            // so these next lines keep getting deffered onto the call stack until we start "returning back up the rabbit hole"
            intermediateResult = intermediateResult * baseValue;
            return intermediateResult;

            // the last 3 lines of coded could be condensed down to, 
            // return raiseToPowerPrivate(baseValue, power - 1) * baseValue;
            // but probably easier to understand as is, and the compiler will turn both into the same executable code

        }

    }
}
