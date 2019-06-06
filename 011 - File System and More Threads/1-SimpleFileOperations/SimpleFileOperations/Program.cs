using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use FileStream

            string streamtest = @"C:\Users\Sean\Documents\streamtest.txt";
            string testText = @"C:\Users\Sean\Documents\testText.txt";

            Console.WriteLine("Use FileStream to write bytes of data");
            Console.WriteLine();
            System.IO.FileStream useFileStream;
            byte[] byteData = new byte[] { 1, 44, 107, 117, 114, 116, 26, 3 };
            useFileStream = new FileStream(streamtest, FileMode.Append);
            useFileStream.Write(byteData, 0, byteData.Length);
            useFileStream.Close();

            useFileStream = new FileStream(streamtest, FileMode.Open);
            byte[] readData = new byte[14];
            useFileStream.Read(readData, 4, 7); // where to put it, offset to start, how many

            Console.WriteLine("what will this output?");
            Console.ReadLine();

            for (int i = 0; i < readData.Length; i++)
            {
                Console.Write(" - {0} ", readData[i]);
            }
            useFileStream.Close();

            //  What will this output?

            Console.ReadLine();

            //========================================================

            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine("========================================================");
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Use TextWriter");
            Console.WriteLine();
            string line1 = "Line 1.";
            string line2 = "how did this get here?";
            string line3 = "Line 2.";
            string readLine;
            System.IO.TextWriter writeFile = new StreamWriter(testText);
            writeFile.WriteLine(line1);
            writeFile.WriteLine(line2);
            writeFile.WriteLine(line3);
            writeFile.WriteLine(); // write an End Of File
            writeFile.Close();
            bool done = false;

            Console.WriteLine("what will this output?");
            Console.ReadLine();
            

            System.IO.TextReader readFile = new StreamReader(testText);
            while (!done)
            {
                readLine = readFile.ReadLine();
                if (readLine != null)
                {
                    Console.WriteLine(readLine);
                }
                else
                {
                    done = true;
                }
            }
            readFile.Close();

            Console.ReadLine();

            //==============================================================================

            // now use TextReader to read the FileStream from first part

            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine("========================================================");
            Console.WriteLine("========================================================");
            Console.WriteLine();
            
            
            Console.WriteLine();
            Console.WriteLine("use TextReader to read the FileStream");
            Console.WriteLine();
            Console.WriteLine("what will this output?");
            Console.ReadLine();
            
            done = false;
            System.IO.TextReader readFile2 = new StreamReader(streamtest);
            while (!done)
            {
                readLine = readFile2.ReadLine();
                if (readLine != null)
                {
                    Console.WriteLine(readLine);
                }
                else
                {
                    done = true;
                }
            }
            readFile2.Close();

            File.Delete(testText);  // clean up our files
            File.Delete(streamtest);

            //======================================================

           

            Console.ReadLine(  );
        }
    }
}
