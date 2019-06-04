using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads2019HW
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray1 = new int[]   // goes from 1 to 500
           {
                100, 201, 321, 402, 380, 465, 269,  45, 436, 415, 82,  74, 319,  12,  81, 497,  90, 233, 157, 374,
                345,  33, 208, 138, 207, 127, 129, 379, 161, 112, 186, 190, 347, 439, 254, 160, 121,  18, 323, 408,
                388,  79, 373, 343, 493, 171, 145, 119,  49,  96, 234,  88, 231, 381, 202, 365, 360, 179, 212, 288,
                328,   2, 132, 118, 218, 250, 165, 492,  97,  24, 64,   7, 178,  65, 173,  21, 419, 464, 258, 486,
                414, 409, 424,  10, 329, 399, 463, 166, 496, 461, 9, 368, 229, 261, 253, 257, 200, 164,  85,  61,
                22, 263,   8, 311, 401, 307, 271, 407, 266, 445, 14,  60, 246, 359, 252, 107, 456,  50, 278, 283,
                31, 286, 294,  76,  41, 406, 152, 242, 172, 472, 122, 284,  51, 378, 428, 35, 147, 336,  75, 473,
                324, 437, 393, 441, 366, 272, 482, 192, 298, 371, 5,  47,  83, 333, 182,  99, 341,  55, 169, 350,
                63, 181,  39, 133, 114, 140, 159,  78, 423,  29, 281, 305, 332, 468,  48,  25, 338, 235, 433, 355,
                128, 203, 289, 120, 255, 403, 162, 396, 499, 210, 80, 487, 116,  52, 386, 106, 163, 460, 131, 134,
                334, 430, 432,  27, 451, 123, 275,  84, 117, 130, 66,  46,  32, 187, 422, 217, 243, 306, 481, 276,
                425, 215,  93, 410, 282, 488, 268, 148,  53, 279, 466, 167, 297,  23, 361, 450, 362, 491, 170, 177,
                262, 340,  71, 413, 370, 176, 153, 126, 228,  43, 92, 400, 412, 302, 310, 277, 387, 195, 356, 256,
                417, 232, 205, 224, 498, 295, 249, 384, 101,  95, 135, 188, 455, 440, 454, 446, 125, 143, 191, 462,
                223,  67, 342, 478, 193, 459, 427, 326, 449, 245, 144, 394, 495, 313, 322, 236, 405, 308, 199,  89,
                292, 124, 377, 136,  54,  13,  30, 222, 375, 376, 315, 337, 346, 339, 103,  98, 216, 477, 357, 483,
                70, 290, 411,  38, 490, 220, 239, 476, 442, 404, 383, 259,  36,   4, 244,  40, 353,  73, 395, 453,
                367, 293, 227,  16, 364, 398, 348,  86,  28, 330, 309, 197, 185, 421, 108, 248, 189, 494, 447, 221,
                111,  19, 372, 331, 247, 105, 325, 211, 265, 150, 94, 209, 369,  42,  77, 196, 225, 267, 154, 485,
                109,  15, 301, 206, 382, 435,  26, 385, 500, 431, 204, 314, 304, 168, 418,  62, 149, 102, 429, 146,
                444, 438, 115, 349, 194, 354,  59, 240, 426, 363, 58,  20,  37, 420,  17, 285,  87, 397,  69, 180,
                274, 270,  44, 484, 113, 312, 184, 480, 300, 416, 174, 318, 327, 214, 389, 142, 316, 434, 213,  68,
                6, 317,  470, 303, 198, 351, 238,  91, 251,  34, 489, 352, 448, 230, 467, 296, 391, 479, 392, 475,
                11, 474, 141, 183, 264, 273, 390, 291, 299, 280, 358, 156, 344,  72, 443, 241, 137, 458,   3,  57,
                335, 219, 139,   1, 175, 471, 155, 287,  56, 260, 452, 237, 158, 104, 151, 469, 110, 457, 320, 226
           };
            int[] testArray2 = new int[]   // goes from 1 to 500
         {
                100, 201, 321, 402, 380, 465, 269,  45, 436, 415, 82,  74, 319,  12,  81, 497,  90, 233, 157, 374,
                345,  33, 208, 138, 207, 127, 129, 379, 161, 112, 186, 190, 347, 439, 254, 160, 121,  18, 323, 408,
                388,  79, 373, 343, 493, 171, 145, 119,  49,  96, 234,  88, 231, 381, 202, 365, 360, 179, 212, 288,
                328,   2, 132, 118, 218, 250, 165, 492,  97,  24, 64,   7, 178,  65, 173,  21, 419, 464, 258, 486,
                414, 409, 424,  10, 329, 399, 463, 166, 496, 461, 9, 368, 229, 261, 253, 257, 200, 164,  85,  61,
                22, 263,   8, 311, 401, 307, 271, 407, 266, 445, 14,  60, 246, 359, 252, 107, 456,  50, 278, 283,
                31, 286, 294,  76,  41, 406, 152, 242, 172, 472, 122, 284,  51, 378, 428, 35, 147, 336,  75, 473,
                324, 437, 393, 441, 366, 272, 482, 192, 298, 371, 5,  47,  83, 333, 182,  99, 341,  55, 169, 350,
                63, 181,  39, 133, 114, 140, 159,  78, 423,  29, 281, 305, 332, 468,  48,  25, 338, 235, 433, 355,
                128, 203, 289, 120, 255, 403, 162, 396, 499, 210, 80, 487, 116,  52, 386, 106, 163, 460, 131, 134,
                334, 430, 432,  27, 451, 123, 275,  84, 117, 130, 66,  46,  32, 187, 422, 217, 243, 306, 481, 276,
                425, 215,  93, 410, 282, 488, 268, 148,  53, 279, 466, 167, 297,  23, 361, 450, 362, 491, 170, 177,
                262, 340,  71, 413, 370, 176, 153, 126, 228,  43, 92, 400, 412, 302, 310, 277, 387, 195, 356, 256,
                417, 232, 205, 224, 498, 295, 249, 384, 101,  95, 135, 188, 455, 440, 454, 446, 125, 143, 191, 462,
                223,  67, 342, 478, 193, 459, 427, 326, 449, 245, 144, 394, 495, 313, 322, 236, 405, 308, 199,  89,
                292, 124, 377, 136,  54,  13,  30, 222, 375, 376, 315, 337, 346, 339, 103,  98, 216, 477, 357, 483,
                70, 290, 411,  38, 490, 220, 239, 476, 442, 404, 383, 259,  36,   4, 244,  40, 353,  73, 395, 453,
                367, 293, 227,  16, 364, 398, 348,  86,  28, 330, 309, 197, 185, 421, 108, 248, 189, 494, 447, 221,
                111,  19, 372, 331, 247, 105, 325, 211, 265, 150, 94, 209, 369,  42,  77, 196, 225, 267, 154, 485,
                109,  15, 301, 206, 382, 435,  26, 385, 500, 431, 204, 314, 304, 168, 418,  62, 149, 102, 429, 146,
                444, 438, 115, 349, 194, 354,  59, 240, 426, 363, 58,  20,  37, 420,  17, 285,  87, 397,  69, 180,
                274, 270,  44, 484, 113, 312, 184, 480, 300, 416, 174, 318, 327, 214, 389, 142, 316, 434, 213,  68,
                6, 317,  470, 303, 198, 351, 238,  91, 251,  34, 489, 352, 448, 230, 467, 296, 391, 479, 392, 475,
                11, 474, 141, 183, 264, 273, 390, 291, 299, 280, 358, 156, 344,  72, 443, 241, 137, 458,   3,  57,
                335, 219, 139,   1, 175, 471, 155, 287,  56, 260, 452, 237, 158, 104, 151, 469, 110, 457, 320, 226
         };
            // Create a new thread named tDotNet that uses a method named DotNetSort
            Thread tDotNet = new Thread(DotNetSort);
            // create another new thread name tBubble that uses a method name BubbleSort
            Thread tBubble = new Thread(BubbleSort);
            // start the tDotNet thread passing in testArray 1
            tDotNet.Start(testArray1);
            // start the tBubble thread, passing in testArray2
            tBubble.Start(testArray2);
            // after your program runs successfully, record the time for each of the sorts.
            // then start the threads in the opposite order, re-run your code, and again write down
            // time for the two sorts.  Does it matter which one you start first?
            
            tBubble = new Thread(BubbleSort);
            tBubble.Start(testArray2);
            tDotNet = new Thread(DotNetSort);
            tDotNet.Start(testArray1);

            endThread();
            Console.ReadLine();
        }

        //===========================================================
        // write your delegate method DotNetSort here
        // some of your code
        // in this method have these lines of code
        private static void DotNetSort(object tDotNet)
        {
            int[] localArray = (int[])tDotNet;
            DateTime startTime = DateTime.Now;
            Array.Sort(localArray);
            DateTime doneTime = DateTime.Now;
            TimeSpan diff = doneTime - startTime;
            Console.WriteLine("DotNetSort: " + diff);

            // when you think the program is running correctly, and you have recoded
            // the times twice, uncomment the next line and look at your output
            // to verify that the array is in fact sorted correctly
            //Console.WriteLine(string.Join("  ", localArray));
        }
        
        //===========================================================
        // write your delegate method BubbleSort here
        // some of your code
        // in this method have these lines of code
        private static void BubbleSort(object tBubble)
        {
            int[] localArray = (int[])tBubble;
            DateTime startTime = DateTime.Now;
            int temp;

            for (int j = 0; j <= localArray.Length - 2; j++)
            {
                for (int i = 0; i <= localArray.Length - 2; i++)
                {
                    if (localArray[i] > localArray[i + 1])
                    {
                        temp = localArray[i + 1];
                        localArray[i + 1] = localArray[i];
                        localArray[i] = temp;
                    }
                }
            }
            // here you need to write code to actaully do a bubble sort.
            // search the web if you do not know how
            DateTime doneTime = DateTime.Now;
            TimeSpan diff = doneTime - startTime;
            Console.WriteLine("BubbleSort: " + diff);
            // when you think the program is running correctly, and you have recoded
            // the times twice, uncomment the next line and look at your output
            // to verify that the array is in fact sorted correctly
            //Console.WriteLine(string.Join("  ", localArray));
        }

        private static void endThread()
        {
            Console.WriteLine();
            Console.WriteLine("main is done");
            Console.WriteLine();
        }
    }
}
