using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.Program;

namespace Bank
{

    [ClientValidation(2)]
    public class Client
    {
        private string firstName;
        private string lastName;
        public List<BankAccount> Accounts;

        public Client(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            Accounts = new List<BankAccount>();
        }

        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }

        public void AddAccount(BankAccount account)
        {
            Accounts.Add(account);
        }

        public Money GetBalance()
        {
            var totalBalance = new Money(0, 0);
            foreach (var account in Accounts)
            {
                totalBalance += account.Balance;
            }
            return totalBalance;
        }

        public void GetClientAccounts()
        {
            foreach (var account in Accounts)
            {
                Console.WriteLine(account);
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
    public class ClientValidationException : Exception
    {
        public ClientValidationException(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
