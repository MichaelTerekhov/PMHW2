using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Player
    {
        public Account account;
        private static List<int> container = new List<int> { }; //Container of all unique id
        private bool IsEmpty => container.Count == 0;
        private bool IsFull => container.Count == 99900000;
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Player(string firstName, string lastname,string email,string password,string currency)
        {
            Random rand = new Random();
            try
            {
                if (IsFull) throw new MethodAccessException(nameof(container.Count));
                if (currency.ToUpper() != "EUR" && currency.ToUpper() != "UAH" && currency.ToUpper() != "USD") throw new NotSupportedException(nameof(currency));
                if (IsEmpty)
                {
                    Id = rand.Next(100000, 100000000);
                    container.Add(Id);
                }
                else
                {
                    var temp = rand.Next(100000, 100000000);
                    for (var i = 0; i < container.Count; i++)
                    {
                        if (temp == container[i])
                        {
                            temp = rand.Next(100000, 100000000);
                            i = 0;
                        }
                        else continue;
                    }
                    Id = temp;
                    container.Add(temp);
                }
                FirstName = firstName;
                LastName = lastname;
                Email = email;
                Password = password;
                account = new Account(currency);
            }
            catch (MethodAccessException e)
            {
                Console.WriteLine($"Be carefully unique container overflows!");
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("Not supported Currency");
            }
        }
        public bool IsPasswordValid(string password)
        {
            if (Password.Length != password.Length) return false;
            for (var i = 0; i < Password.Length - 1; i++)
                if (Password[i] != password[i]) return false;
            return true;
        }
        public void Deposit(decimal amount, string currency)
        {
            try
            {
                if (currency.ToUpper() != "EUR" && currency.ToUpper() != "UAH" && currency.ToUpper() != "USD") throw new NotSupportedException(nameof(currency));
                if (account.Currency == "UAH" && currency.ToUpper() == "USD") account.Deposit(amount, currency);
                if (account.Currency == "USD" && currency.ToUpper() == "UAH") account.Deposit(amount, currency);
                if (account.Currency == "UAH" && currency.ToUpper() == "EUR") account.Deposit(amount, currency);
                if (account.Currency == "EUR" && currency.ToUpper() == "UAH") account.Deposit(amount, currency);
                if (account.Currency == "USD" && currency.ToUpper() == "EUR") account.Deposit(amount, currency);
                if (account.Currency == "EUR" && currency.ToUpper() == "USD") account.Deposit(amount, currency);
                if (account.Currency == "UAH" && currency.ToUpper() == "UAH") account.Deposit(amount, currency);
                if (account.Currency == "EUR" && currency.ToUpper() == "EUR") account.Deposit(amount, currency);
                if (account.Currency == "USD" && currency.ToUpper() == "USD") account.Deposit(amount, currency);
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("Not supported Currency");
            }
        }

        public void Withdraw(decimal amount, string currency)
        {
            try
            {
                if (currency.ToUpper() != "EUR" && currency.ToUpper() != "UAH" && currency.ToUpper() != "USD") throw new NotSupportedException(nameof(currency));
                if (account.Currency == "UAH" && currency.ToUpper() == "USD")
                {
                    account.Withdraw(amount,currency);
                }
                if (account.Currency == "USD" && currency.ToUpper() == "UAH")
                {
                    account.Withdraw(amount, currency);
                }
                if (account.Currency == "UAH" && currency.ToUpper() == "EUR")
                {
                    account.Withdraw(amount, currency);
                }
                if (account.Currency == "EUR" && currency.ToUpper() == "UAH")
                {
                    account.Withdraw(amount, currency);
                }
                if (account.Currency == "USD" && currency.ToUpper() == "EUR")
                {
                    account.Withdraw(amount, currency);
                }
                if (account.Currency == "EUR" && currency.ToUpper() == "USD")
                {
                    account.Withdraw(amount, currency);
                }
                if (account.Currency == "UAH" && currency.ToUpper() == "UAH")
                {
                    account.Withdraw(amount, currency);
                }
                if (account.Currency == "EUR" && currency.ToUpper() == "EUR")
                {
                    account.Withdraw(amount, currency);
                }
                if (account.Currency == "USD" && currency.ToUpper() == "USD")
                {
                    account.Withdraw(amount, currency);
                }
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("Not supported Currency");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Cannot perform this operation!");
            }
        }


    }
}
