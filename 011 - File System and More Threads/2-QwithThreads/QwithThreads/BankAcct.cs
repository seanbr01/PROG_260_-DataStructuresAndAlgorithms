using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QwithThreads
{
    class BankAcct
    {
        private static int _AcctNumSeed = 1000;  // use static to keep an asending set of account numbers
        public int AcctNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Balance { get; set; }

        public BankAcct(string fn, string ln, int bal)
        {
            _AcctNumSeed++;
            AcctNum = _AcctNumSeed;
            FirstName = fn;
            LastName = ln;
            Balance = bal;
        }
    }
}
