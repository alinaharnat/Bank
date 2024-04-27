using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.Program;

namespace Bank
{
    public class Bank
    {
        private List<Client> AllClients;
        private List<BankAccount> AllBankAccounts;

        public Bank()
        {
            AllClients = new List<Client>();
            AllBankAccounts = new List<BankAccount>();
        }

        public void AddClient(Client client)
        {
            AllClients.Add(client);
        }
        public void AddBankAccount(BankAccount bankAccount)
        {
            AllBankAccounts.Add(bankAccount);
            AllBankAccounts.Add((BankAccount)bankAccount);
        }

        public void OpenBankAccount(Client client, BankAccount bankAccount)
        {
            client.AddAccount(bankAccount);
            AllBankAccounts.Add((BankAccount)bankAccount);

        }

        public void OpenBankAccount(BankAccount bankAccount)
        {
            AllBankAccounts.Add((BankAccount)bankAccount);
        }
        public void GetAllClients()
        {
            foreach (var client in AllClients)
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void GetAllBankAccounts()
        {
            foreach (var account in AllBankAccounts)
            {
                Console.WriteLine(account.ToString());
            }
        }
    }
}
