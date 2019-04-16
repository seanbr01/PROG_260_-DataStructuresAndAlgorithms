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
            string[,] fakeData = new string[,]  // this array is just a convenience to help me build my que up easily without requiring real user input
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
            OurAcctQueue NewAccountsQ = new OurAcctQueue(20); // create a new Queue object that holds BankAcct objects
           
            // This process will simulate a bank teller entering new account information 
            // into an application and submitting these to another department
            
            Thread t2 = new Thread(ProcessApp); // create second Thread and tell it what to do (give it a delagate method)
            
            // start the 2nd thread, it represents the bank dept that  "processes" the applicaitons to create the new accounts
            t2.Start(NewAccountsQ);

            // Note the Start method passes by ref an object.
            // since it is an object, it is "by ref", so the queue in this 1st thread where new bank account applications are put
            // is able to be used by the second thread.  They both have a name for the same underlying data structure in memory
         
            // instead of having a user manually fill in a form 10 times to create new applications ...
            // we will simulate creating 10 applications, and adding them to the queue
            for (int i = 0; i < 10; i++) 
            {
                Thread.Sleep(myRandom.Next(2, 5) * 1000); // pretend it takes a 2 to 4 seconds to create a new account  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // this creates a new account applicaiton using data from the fakeData array and a random balance, 
                // then puts the "application" in the shared queue
                NewAccountsQ.Enqueue(new BankAcct(fakeData[i, 0], fakeData[i, 1], myRandom.Next(50, 101)));
                Console.WriteLine("Submitted Account Data for account {0}", i);
            }
            Console.WriteLine("Thread 1 has entered 10 new account applications and is now done.");
            Console.ReadLine();
        }

        //==============================================================================================================
        //==============================================================================================================


        // here is the instructions for the 2nd thread, 
        // representing another dept in the bank that actually creates new bank accounts from the applicaitons

        // The start method takes a delegate method as an argument, 
        // but our delegate method is not allow to "type" the one object that a thread start is allowed to pass
        // so we can start the thread and give it a specific type in the start call, 
        // but the delegate method passed to a thread must always cast the object it receives to the type you were intending
        
        private static void ProcessApp(object NewAccountsQ)      
        {
            Random myRandom = new Random();
            int i = 0; // part of a hack to have this thread stop, and not run forever. 
            // In real world, we might want an infinate loop as long as it has a sleep timer so it doesn't waste the CPU cycles

            // so we take the "plain" object passed and cast it (tell the system how to interpert it) to our special acct queue object
            OurAcctQueue ProcessAccountsQ = (OurAcctQueue)NewAccountsQ;  

            BankAcct currentlyProccessingAccount;  // create a local instance of a BankAcct so we can pull them out of the queue
            

            while (true) // this sets up an infinate loop, as we want to sit here watching the queue for new accounts forever
            {
                if (ProcessAccountsQ.QCount != 0) // if the queue is empty, just wait a while. 
                {
                    currentlyProccessingAccount = ProcessAccountsQ.Dequeue();
                    Thread.Sleep(myRandom.Next(4, 6) * 1000); // pretend the thread is doing lots of useful work, by taking a 4 to 6 second delay
                    Console.WriteLine("Finished creating account for {0} {1} with a new balance of ${2}", currentlyProccessingAccount.FirstName, currentlyProccessingAccount.LastName, currentlyProccessingAccount.Balance);
                    
                    // break our infinate loop after 10 accounts
                    i++;
                    if (i>= 10)
	                {
		                break;
	                }
                }
                else
                {
                    Thread.Sleep(2000); // wait two seconds before checking the queue again so we don't waste CPU.
                }
            }
            Console.WriteLine("Thread 2 done.");
        }
        // Our threads are independent, just sharing one queue.
    }
}
