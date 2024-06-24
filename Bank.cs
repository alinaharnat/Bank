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

        
        public async Task AddClient(Client client)
        {
            await Task.Run(() => AllClients.Add(client));
        }
      
        public async Task AddBankAccount(BankAccount bankAccount)
        {
            await Task.Run(() => AllBankAccounts.Add(bankAccount));
        }

        public async Task OpenBankAccount(Client client, BankAccount bankAccount)
        {
            await Task.Run(() =>
            {
            client.AddAccount(bankAccount);
                AllBankAccounts.Add(bankAccount);
            });
        }

        public async Task OpenBankAccount(BankAccount bankAccount)
        {
            await Task.Run(() => AllBankAccounts.Add(bankAccount));
        }

        public async Task GetAllClients()
        {
            await Task.Run(() =>
        {
            foreach (var client in AllClients)
            {
                Console.WriteLine(client.ToString());
            }
            });
        }
      
        public async Task GetAllBankAccounts()
        {
            await Task.Run(() =>
        {
            foreach (var account in AllBankAccounts)
            {
                Console.WriteLine(account.ToString());
            }
            });
        }
    }
}
