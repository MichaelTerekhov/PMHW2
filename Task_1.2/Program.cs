using System;
using Library;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Length = 1000000;
            Account[] accounts =new Account[Length];
            for (var i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account();
            }

            accounts = GetSortedAccounts(accounts);
            Console.WriteLine("First ten accounts are: ");
            for (var i = 0; i < 10; i++) Console.WriteLine(accounts[i].Id);
            Console.WriteLine("Last ten accounts are: ");
            for (var i = Length - 10; i < accounts.Length; i++) Console.WriteLine(accounts[i].Id);

            Console.ReadKey();
        }

        static Account[] GetSortedAccounts(Account[] income)
        {
            Account[] SortedAccounts = income;
            Account temporary;
            for (int j = 0; j <= SortedAccounts.Length - 2; j++)
            {
                for (int i = 0; i <= SortedAccounts.Length - 2; i++)
                {
                    if (SortedAccounts[i].Id > SortedAccounts[i + 1].Id)
                    {
                        temporary = SortedAccounts[i + 1];
                        SortedAccounts[i + 1] = SortedAccounts[i];
                        SortedAccounts[i] = temporary;
                    }
                }
            }
            return SortedAccounts;
        }
    }
}
