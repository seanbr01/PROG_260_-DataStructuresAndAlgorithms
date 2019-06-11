using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_1
{
    public class Factorial
    {
        public int Calculate(int input) //use a public wrapper for set up
        {
            int tempValue = input;
            if (tempValue == 0)
            {
                tempValue = 1; //factorial of zero is same as for 1, this lets the recursion logic work nicely
            }
            return CalcWork(tempValue);
        }
        private int CalcWork(int input)  // use a private method for the iterative work
        {
            int valuenow = input;
            int returnValue = 1;  //covers the case when input was a 1 (or zero)

            if (valuenow == 0)  // this is the exit for the recursion
            {
                return returnValue;
            }
            while (valuenow != 0)
            {
                returnValue = returnValue * valuenow; // do the work for 1 stage,
                valuenow = valuenow - 1; // count down so we will get out of here
                CalcWork(valuenow);  // recurse

            }
            return returnValue; // we will never get here, but have to keep the compiler happy

        }
    }
}
