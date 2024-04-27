using System.ComponentModel.DataAnnotations;
using System.Data;
using static Bank.Program;

namespace Bank
{
    internal class Program
    {
       public  static async Task Main(string[] args)
        {
           Bank bank = new Bank();
            var client1 = new Client("Mia", "Davis");
            var acc1 = new BankAccount(101123,new Money(1000,0),5);
            var acc2 = new BankAccount(101124, new Money(500, 90), 5);
            var acc3 = new BankAccount(101125, new Money(20000, 10), 5);
            client1.AddAccount(acc1);
            client1.AddAccount(acc2);
            client1.AddAccount(acc3);
            await Client.GetClientAccounts(client1);
        }
        //Client

        public static bool ValidateClient(Client client)
        {
            var type = typeof(Client);
            var attributes = type.GetCustomAttributes(typeof(ClientValidationAttribute), false);
            foreach (var attribute in attributes)
            {
                if (attribute is ClientValidationAttribute clientValidation)
                {
                    if (client.FirstName.Length < clientValidation.Length || client.LastName.Length < clientValidation.Length)
                    {
                        throw new ClientValidationException("Client is not valid");
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        [AttributeUsage(AttributeTargets.Class)]
        public class ClientValidationAttribute : Attribute
        {
            public int Length { get; private set; }

            public ClientValidationAttribute(int length)
            {
                Length = length;
            }
        }


        //Bank account
        public static bool ValidateBalance(Money amount)
        {
            {
                var type = typeof(Money);
                var attributes = type.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute is BalanceValidationAttribute balanceValidation)
                    {
                        return amount <= balanceValidation.Balance;
                    }
                }
                return true;
            }
        }

        [AttributeUsage(AttributeTargets.Method)]
        public class BalanceValidationAttribute : Attribute
        {
            public Money Balance { get; private set; }

            public BalanceValidationAttribute(Money balance)
            {
                Balance = balance;
            }
        }

        //id
        public static bool ValidateId(int id)
        {
            if (id < 0 || id.ToString().Length != 6)
            {
                return false;
            }
            return true;
        }
    }
}
