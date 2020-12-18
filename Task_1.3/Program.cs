using System;
using Library;

namespace Task_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Length = 1000000;
            Account[] accounts = new Account[Length];
            for (var i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account();
            }
            
            accounts = GetSortedAccounts(accounts);
            GetAccount(accounts, 23432134);

            Console.ReadKey();
        }

        static void GetAccount(Account[] accounts,int id)
        {
            int count = 0;
            int low = 0;
            int high = accounts.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (id < accounts[mid].Id)
                {
                    high = mid - 1;
                    count++;
                }
                else if (id > accounts[mid].Id)
                { 
                    low = mid + 1;
                    count++;
                }
                else if (id == accounts[mid].Id)
                {
                    Console.WriteLine($"{id} was found at location {mid+1} by {count} tries\n");
                    return;
                }
            }
            Console.WriteLine($"There is no account {id} in the list");
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
