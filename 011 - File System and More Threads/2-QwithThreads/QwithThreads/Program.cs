using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QwithThreads
{
    class Program
    {

        static void Main(string[] args)
        {
            string[,] fakeData = new string[,]
	        {
	            {"Joe", "Blow"},
	            {"Jane", "Doe"},
	            {"Sam", "Sunny"},
	            {"Ned", "Night"},
	            {"Mary", "Contrary"},
                {"Linda", "Last"},
	            {"Fred", "First"},
	            {"June", "Day"},
	            {"August", "Night"},
	            {"Fall", "Weather"}
	        };
            // we are in the first thread, which you started when you told VS to "start" (at class Program, method Main)
            Random myRandom = new Random();
            OurAcctQueue NewAccountsQ = new OurAcctQueue(20); // create a new Queue that holds BankAcct objects
            // This process will simulate a bank teller entering new account information into an application and submitting these to another department
            
            Thread t2 = new Thread(ProcessApp); // create second Thread and point it to the code (method) to execute
            t2.Start(NewAccountsQ);  // start the new thread, this 2nd thread represents the bank dept that  "processes" the applicaitons to create the new accounts
            // Note the Start method passes by ref (all the class objects we define are by ref) a ref to the queue where new bank account applications are put
         
            for (int i = 0; i < 10; i++)  // we will simulate creating 10 applications, and adding them to the queue
            {
                Thread.Sleep(myRandom.Next(2, 5) * 1000); // pretend it takes a 2 to 4 seconds to create a new account  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // this creates a new applicaiton useing data from the fakeData array and a random balance, then puts the "application" in the shared queue
                NewAccountsQ.Enqueue(new BankAcct(fakeData[i, 0], fakeData[i, 1], myRandom.Next(50, 101)));
                Console.WriteLine("Submitted Account Data for account {0}", i);
            }
            Console.WriteLine("Thread 1 done.");
            Console.ReadLine();
        }


        // here is the 2nd thread, representing another dept in the bank that actually creates new bank accounts from the applicaitons
        private static void ProcessApp(object NewAccountsQ)  // The start method takes a delegate method as an argument, but our delegate method doesn't seem to allow passing specific object types
        {
            Random myRandom = new Random();
            int i = 0; // hack to get out of following infinate loop
            OurAcctQueue ProcessAccountsQ = (OurAcctQueue)NewAccountsQ;  // so we take the vanila object passed and cast it to our specail acct queue object
            BankAcct currentlyProccessingAccount;  // create a local instance of a BankAcct so we can pull them out of the queue
            while (true) // this sets up an infinate loop, as we want to sit here watching the queue for new accounts forever
            {
                if (ProcessAccountsQ.QCount != 0) // if the queue is empty, just wait a while. This would be wasteful of cpu, so we would put in a sleep here to free the cpu for other work
                {
                    currentlyProccessingAccount = ProcessAccountsQ.Dequeue();
                    Thread.Sleep(myRandom.Next(3, 5) * 1000); // pretend the thread is doing lots of useful work, byy taking a 3 to 4 second delay
                    Console.WriteLine("Finished creating account for {0} {1} with a new balance of ${2}", currentlyProccessingAccount.FirstName, currentlyProccessingAccount.LastName, currentlyProccessingAccount.Balance);
                    i++;
                    if (i>= 10)
	                {
		                break;
	                }
                }   
            }
            Console.WriteLine("Thread 2 done.");
        }
        // Threads are independent, just sharing one queue.
    }
}
