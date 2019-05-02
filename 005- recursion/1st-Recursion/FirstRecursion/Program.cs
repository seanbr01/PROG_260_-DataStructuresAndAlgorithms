using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintClass myPrintClass = new PrintClass();  // instantiate an instance of the class
            int endResult = myPrintClass.recursionDemo(3);  // call the recurives method the first time from Main
            Console.WriteLine();
            Console.WriteLine("End result: " + endResult);  // write out the value retuned
            Console.ReadLine();
        }
    }


    class PrintClass
    {
        public int recursionDemo(int f)
        {
            int result = 0;
            Console.WriteLine("Handed " + f);  // always write a line out before calling itself
            if (f <= 0)   // recursive code needs a way to come to an end of the recursion, this one counts down the value passed in
                return 10;  // I picked 10 just to make this counting distinct from the counting down of f
                // critcal thing to understand, where is the above return statement returning to???
            else
            {
                f = f - 1;  // this is key, this is where we are counting down the number of times to do the recursion
                result = recursionDemo(f);  // calling >> ourself <<  this is what makes it "recursion"
                // it keeps getting delayed (put on the call stack), as we jump away to another copy of ourself
                // when we hit the bottom of the recursion, we will "unwind" our way back up, and do the WriteLine 3 times

                // these lines will not execute the first time we call recursionDemo,
                result = result + 1;  // this is just a way for us to see the order of how things happen.
                              
                // the first Console.WriteLine gets called 4 times, 
                // but only when the recursion gets to its limit will this bottom Console.WriteLine finally execute 4 times
                Console.WriteLine("Returning " + result);  

                return result;
            }

        }
    }

   

}
