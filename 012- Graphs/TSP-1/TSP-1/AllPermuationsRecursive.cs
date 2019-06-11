using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_1
{
    /// <summary>
    /// Basic Algorithm Source: A. Bogomolny, Counting And Listing 
    /// All Permutations from Interactive Mathematics Miscellany and Puzzles
    /// http://www.cut-the-knot.org/do_you_know/AllPerm.shtml, Accessed 11 June 2009
    /// modified by Kurt Friedrich to save all the permutations in an array
    /// </summary>
    public class AllPermuationsRecursive
    {
        public AllPermuationsRecursive(int arraySize)  // consturctor
        {
            allPerms = new string[arraySize];
        }

        private string[] allPerms;
        public string[] AllPerms
        {
            get { return allPerms; }
            set { allPerms = value; }
        }

        private int elementLevel = -1;
        private int numberOfElements;
        private int[] permutationValue = new int[0];

        private char[] inputSet;
        public char[] InputSet
        {
            get { return inputSet; }
            set { inputSet = value; }
        }

        private int permutationCount = 0;
        public int PermutationCount
        {
            get { return permutationCount; }
            set { permutationCount = value; }
        }


        public char[] MakeCharArray(string InputString)
        {
            char[] charString = InputString.ToCharArray();
            Array.Resize(ref permutationValue, charString.Length);
            numberOfElements = charString.Length;
            return charString;
        }

        public void CalcPermutation(int k)
        {
            elementLevel++;
            permutationValue.SetValue(elementLevel, k);

            if (elementLevel == numberOfElements)
            {
                OutputPermutation(permutationValue);
            }
            else
            {
                for (int i = 0; i < numberOfElements; i++)
                {
                    if (permutationValue[i] == 0)
                    {
                        CalcPermutation(i);
                    }
                }
            }
            elementLevel--;
            permutationValue.SetValue(0, k);
        }

        private void OutputPermutation(int[] value)
        {
            string nextPerm = "";
            foreach (int i in value)
            {
                Console.Write(inputSet.GetValue(i - 1));
                nextPerm = nextPerm + inputSet.GetValue(i - 1).ToString(); // concatenate each letter into a string
            }
            AllPerms[PermutationCount] = nextPerm;
            Console.WriteLine();
            PermutationCount++;
        }
    }
}
