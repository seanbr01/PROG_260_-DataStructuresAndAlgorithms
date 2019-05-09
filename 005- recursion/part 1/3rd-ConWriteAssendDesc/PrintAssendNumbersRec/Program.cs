using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAssendNumbersRec
{
    class Program
    {
        static void Main(string[] args)
        {
            // program will  write out numbers from 1 to max using a recursive method
            // often when you get your recursion scheme wrong, it will call itself forever, 
            // and then you will get this error msg:  "Process is terminated due to StackOverflowException."
            
            Console.WriteLine("first do the count up");
            Console.WriteLine();
            Console.Write("enter the value you want to count from 1 up to:  ");
            int max = Convert.ToInt16(Console.ReadLine());
            CountUp myCountUp = new CountUp();
            myCountUp.CounterUp(max); 

            // now it will count down
            Console.WriteLine();
            Console.WriteLine("then do the count down");
            CountDown myCountDown = new CountDown();
            myCountDown.CounterDown(max);

            
           
            Console.ReadLine();
        }
    }

    class CountUp
    {
        public void CounterUp(int value) // recurse, then do the work
        {
            int myCount = value;
            if (myCount < 1) // handles the case where the user passed in a zero or negative number
                // but also, this will terminate the recursion
            {
               return;
            }
            else
            {
                CounterUp(--myCount); // call myself  as count down 4,3,2,1,0
            }
            // here we "do the work", after coming back from each return
            Console.WriteLine("Next number is: {0}", myCount +1);  // since we decrement (--Count) before we get to the WriteLine, my printable value is off by 1
            return;

        }
    }

    class CountDown
    {
        public void CounterDown(int value) // do the work, then recurse
        {
            int myCount = value;
            Console.WriteLine("Next number is: {0}", myCount);   // notice we do "the work" before the recursive call
            if (myCount <= 1) // handles the case where the user passed in a zero or negative number
            // but also, this will terminate the recursion
            {
                return;
            }
            else
            {
                CounterDown(--myCount); // call myself  as count down 4,3,2,1,0
            }
            //just pop the returns
           // return;

        }
    }
  
}
