using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Bank.Program;

namespace Bank
{
    public class BankAccount
    {
        private int id;
        private Money balance;
        private double rate;
        public List<string> HistoryOfTransactions;

        
        public BankAccount(int id, Money balance, double rate)
        {
                if (!ValidateId(id))
                {
                throw new ArgumentException("Id length is out of bounds");
                }
            
                this.id = id;
                this.balance = balance;
                this.rate = rate;
                HistoryOfTransactions = new List<string>();
                

        }
        public Money Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        public void GetHistoryOfTransactions()
        {
            foreach (var info in HistoryOfTransactions)
            {
                Console.WriteLine(info);
            }
        }

        public void Deposit( Money amount)
        {
            
            balance += amount;
            HistoryOfTransactions.Add($"[{id}] Deposit {amount}");
        }
        
        public void Withdraw(Money amount)
        {
           if(ValidateBalance(amount))
            {
                balance -= amount;
                HistoryOfTransactions.Add($"[{id}] Withdraw {amount}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient balance to perform operation");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        
        public void Transfer(BankAccount recipient, Money amount)
        {
            if (ValidateBalance(amount))
            {
                balance -= amount;
                recipient.Deposit(amount);
                HistoryOfTransactions.Add($"[{id}] Transfer {amount} account number of the recipient: [{recipient}]");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient balance to perform operation");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public override string ToString()
        {
            return $"{id}";
        }
    }
    public enum TypeOfOperation
    {
        Transfer,
        Withdraw,
        Deposit
    }
}
