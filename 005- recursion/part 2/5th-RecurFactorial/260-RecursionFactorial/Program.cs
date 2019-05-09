using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260_RecursionFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Factorial myCountDownFactorial = new Factorial(); // instantiate an object of our use

            // get user input
            Console.Write("Please enter a positive interger that you would like the factorial value of: ");
            int userInput = Convert.ToInt32( Console.ReadLine());
            
            // call our method and write answer
            Console.WriteLine("The factorial value of {0}, is: {1}",userInput, myCountDownFactorial.Calculate(userInput));

            Console.ReadLine();
        }
    }

    public class Factorial   // actually does math backwards, e.g. not 1*2*3*4 but rather 4*3*2*1
    {
        public int Calculate(int input) //use a public wrapper for set up
        {
            if (input < 0)
            {
                input = input * -1; // our code won't work with - values
            }

            return CalcWork(input);  // let the recursive method do the work
        }
        private int CalcWork(int IntermediateAnswer)  // use a private method for the iterative work
        {
            // Cover 0, 1 being passed in initially as well as our end case when we have counted down
            if (IntermediateAnswer <= 1)
            {
                return 1;
            }

            // Setting up the recursion call across multiple statements..
            int returnValue = IntermediateAnswer;
            IntermediateAnswer = IntermediateAnswer - 1;  // keep counting down so we will get out
            int answer = CalcWork(IntermediateAnswer);
            returnValue = returnValue * answer;  // here we do the actual math

            return returnValue;

            // or the more simplier..
            //return input * CalcWork(input - 1);

        }

    }
}
