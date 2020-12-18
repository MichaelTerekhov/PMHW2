using System;
using Library;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account ac1 = new Account("EUR");
            Account ac2 = new Account("USD");
            Account ac3 = new Account();

            Console.WriteLine($"Currencies: {ac1.Currency} {ac2.Currency} {ac3.Currency}\n");

            ac1.Deposit(10, "EUR");
            ac1.Withdraw(3, "UAH");

            ac3.Deposit(121, "USD");

            ac2.Withdraw(5, "USD");

            Account acPLN = new Account("PLN");

            Console.WriteLine($"Account currency: {ac1.Currency} has {ac1.Amount}\n" +
               $"Account currency: {ac2.Currency} has {ac2.Amount}\n" +
              $"Account currency: {ac3.Currency} has {ac3.Amount}\n");

            Console.ReadKey();
        }
    }
}
