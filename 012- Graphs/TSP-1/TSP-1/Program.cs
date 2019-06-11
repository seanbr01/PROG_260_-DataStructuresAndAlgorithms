using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> distance = new Dictionary<string, int>();
            // hold distances between citites
            distance.Add("AB", 2);
            distance.Add("AC", 4);
            distance.Add("AD", 7);
            distance.Add("AE", 6);
            distance.Add("BA", 2);
            distance.Add("BC", 5);
            distance.Add("BD", 6);
            distance.Add("BE", 8);
            distance.Add("CA", 4);
            distance.Add("CB", 5);
            distance.Add("CD", 5);
            distance.Add("CE", 3);
            distance.Add("DA", 7);
            distance.Add("DB", 6);
            distance.Add("DC", 5);
            distance.Add("DE", 7);
            distance.Add("EA", 6);
            distance.Add("EB", 8);
            distance.Add("EC", 3);
            distance.Add("ED", 7);
            
            Console.Write("List the cities to be visited, from A B C D and E: ");
            string inputLine = Console.ReadLine();  // get the users set of cities they want to compute
            inputLine = inputLine.ToUpper();

            Factorial myFactorial = new Factorial();

            int PathsCount = myFactorial.Calculate(inputLine.Length);  // number of perms is just number factorial
            Console.Write("# of Permutations should be: " + PathsCount);
            Console.WriteLine();
            Console.WriteLine();
                    
            AllPermuationsRecursive GetPermutations = new AllPermuationsRecursive(PathsCount);
            GetPermutations.InputSet = GetPermutations.MakeCharArray(inputLine);
            GetPermutations.CalcPermutation(0);

            string[] MainAllPerms = GetPermutations.AllPerms;  // just give the returned array a nicer name

            Console.Write("# of Permutations: " + GetPermutations.PermutationCount);
            Console.WriteLine();
            Console.WriteLine();

            string firstChar = "";  // need to add the first city to the end of our trip
            for (int i = 0; i < MainAllPerms.Length; i++)
            {
                firstChar = MainAllPerms[i].Substring(0, 1);
                MainAllPerms[i] = MainAllPerms[i] + firstChar;
            }

            // now have distances in dictionary and MainAllPerms array with the permutations
            // now calculate the distances for each trip
            int[] totalDis = new int[PathsCount];  // array to hold the distances

            for (int pathNum = 0; pathNum < PathsCount; pathNum++) // do for each possible path
            {
                string perm = MainAllPerms[pathNum]; // get the current path permutation
                string segment;
                for (int segmentCount = 0; segmentCount < (inputLine.Length-1) +1 ; segmentCount++)
                {
                    segment = perm.Substring(segmentCount, 2);
                    totalDis[pathNum] = totalDis[pathNum] + distance[segment];
                }
            }

            // write out results
            // pick a good path too
            string goodPath = "";
            int goodPathDist = 99999; // seed it with a big number
            for (int i = 0; i < PathsCount; i++)
            {
                Console.WriteLine("With this path: {0}, total distance is: {1}", MainAllPerms[i], totalDis[i]);
                if (totalDis[i] < goodPathDist)
                {
                    goodPath = MainAllPerms[i];
                    goodPathDist = totalDis[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine("One of the best paths is {0}, which takes {1} miles.", goodPath, goodPathDist);


            Console.ReadLine();  // leave the cmd window open
        }
    }

        
}
