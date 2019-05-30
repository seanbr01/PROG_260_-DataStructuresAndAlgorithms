using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog260MergeSort
{
    public class ArrayReader
    {
        int[] RawData;

        public int[] ReadArray(string filename, int arraySize)
        {
            RawData = new int[arraySize];

            StreamReader arrayReader;
            arrayReader = new System.IO.StreamReader(filename);
            int i = 0;
            while (!arrayReader.EndOfStream)
            {
                RawData[i] = Convert.ToInt32(arrayReader.ReadLine());
                i++;
            }
            
            return RawData;
        }
    }
}
