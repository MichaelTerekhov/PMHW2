using System;
using Library;

namespace Task_1._4
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

            accounts = GetSortedAccountsByQuickSort(accounts, 0, accounts.Length - 1);

            Console.WriteLine("First ten accounts are: ");
            for (var i = 0; i < 10; i++) Console.WriteLine(accounts[i].Id);
            Console.WriteLine("Last ten accounts are: ");
            for (var i = Length - 10; i < accounts.Length; i++) Console.WriteLine(accounts[i].Id);
            Console.ReadKey();
        }

        static Account[] GetSortedAccountsByQuickSort(Account[] sortaccounts, int low, int high)
        {
            Account[] accounts = sortaccounts;
            if (low < high)
            {
                int pi = Partition(accounts, low, high);
                GetSortedAccountsByQuickSort(accounts, low, pi - 1);
                GetSortedAccountsByQuickSort(accounts, pi + 1, high);
            }
            return accounts;
        }
        static int Partition(Account[] accounts, int low, int high)
        {
            int pivot = accounts[high].Id;
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (accounts[j].Id < pivot)
                {
                    i++;
                    Account temp = accounts[i];
                    accounts[i] = accounts[j];
                    accounts[j] = temp;
                }
            }
            Account temp1 = accounts[i + 1];
            accounts[i + 1] = accounts[high];
            accounts[high] = temp1;
            return i + 1;
        }
    }
}
