using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog260_QuickSortText
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort myQS = new QuickSort();

            // Create an unsorted array of string elements
            string[] A = { "are", "for", "tomatoes", "stomach", "apples", "than", "better", "my"};
            Console.WriteLine("before");
            Console.WriteLine(string.Join("  ", A));
            Console.WriteLine();
            // Sort the array

            myQS.QSort(A);

            // Print the sorted array
            Console.WriteLine("after");
            Console.WriteLine(string.Join("  ", A));
            
            Console.ReadLine();
        }
        
    }

}
