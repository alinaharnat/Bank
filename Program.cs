using System.ComponentModel.DataAnnotations;
using System.Data;
using static Bank.Program;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            try
            {
                var acc1 = new BankAccount(123456, new Money(100, 10), 1);
                var acc2 = new BankAccount(123457, new Money(2000, 0), 1);
                acc1.Transfer(acc2, new Money(100, 10));
                Console.WriteLine(acc2.Balance);
                acc1.Withdraw(new Money(50, 0));
                Console.WriteLine(acc2.Balance);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("\n");
            try
            {
                var client = new Client("Henry", "D");
                ValidateClient(client);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("\n");
            try
            {
                var acc5 = new BankAccount(12345, new Money(300, 0), 1);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
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
