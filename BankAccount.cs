using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account_Simulator
{
    class BankAccount
    {
        //Field for balance
        private decimal _balance;
        //Constructor 
        public BankAccount(decimal startingBalance)
        {
            _balance = startingBalance;
        }
        //Balance property is read-only here
        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }
        //Deposit method
        public void Deposit(decimal amount)
        {
            _balance += amount;
        }
        //A withdrawl method.
        public void Withdraw(decimal amount)
        {
            _balance -= amount;
        }
    }
}
