using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Masrofy4.Classes
{
    
    public class BankAccount
    {
        public string accNum { get; set; }
        public double balance { get; set; }
        public string accType { get; set; }

        public BankAccount(string number, double balance, string accType = "Credit")
        {
            this.accNum = number;
            this.balance = balance;
            this.accType = accType;
        }

    }
}