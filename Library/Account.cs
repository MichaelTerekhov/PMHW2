using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Account
    {
        private static List<int> container = new List<int> { }; //Container of all unique id
        private bool IsEmpty => container.Count == 0;
        private bool IsFull => container.Count == 99900000;
        public int Id { get; private set; } 
        public string Currency { get; private set; } = "UAH";
        public decimal Amount { get; private set; }
        public Account()
        {
            Random rand = new Random();
            try
            {
                if (IsFull) throw new MethodAccessException(nameof(container.Count));
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
                    Amount = 0;
                }
            }
            catch (MethodAccessException e)
            {
                Console.WriteLine($"Be carefully unique container overflows!");
            }
        }
        public Account(string currency)
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
                    Amount = 0;
                }
                Currency = currency.ToUpper();
                Amount = 0;
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
        public void Deposit(decimal amount, string currency)
        {
            try
            {
                if (currency.ToUpper() != "EUR" && currency.ToUpper() != "UAH" && currency.ToUpper() != "USD") throw new NotSupportedException(nameof(currency));
                if (Currency == "UAH" && currency.ToUpper() == "USD" ) Amount += amount * 28.36m;
                if (Currency == "USD" && currency.ToUpper() == "UAH") Amount += amount / 28.36m;
                if (Currency == "UAH" && currency.ToUpper() == "EUR") Amount += amount * 33.63m;
                if (Currency == "EUR" && currency.ToUpper() == "UAH") Amount += amount / 33.63m;
                if (Currency == "USD" && currency.ToUpper() == "EUR") Amount += amount * 1.19m;
                if (Currency == "EUR" && currency.ToUpper() == "USD") Amount += amount / 1.19m;
                if (Currency == "UAH" && currency.ToUpper() == "UAH") Amount += amount;
                if (Currency == "EUR" && currency.ToUpper() == "EUR") Amount += amount;
                if (Currency == "USD" && currency.ToUpper() == "USD") Amount += amount;

            }
            catch(NotSupportedException e)
            {
                Console.WriteLine("Not supported Currency");
            }
        }

        public void Withdraw(decimal amount, string currency)
        {
            decimal tempUSD;
            decimal tempUAH;
            decimal tempEUR;
            try
            {
                if (currency.ToUpper() != "EUR" && currency.ToUpper() != "UAH" && currency.ToUpper() != "USD") throw new NotSupportedException(nameof(currency));
                if (Currency == "UAH" && currency.ToUpper() == "USD")
                {
                    tempUSD = Amount / 28.36m;
                    if (tempUSD < amount || amount <= 0) throw new InvalidOperationException(nameof(amount));
                    Amount = (tempUSD - amount) * 28.36m;
                }
                if (Currency == "USD" && currency.ToUpper() == "UAH")
                {
                    tempUAH = Amount * 28.36m;
                    if (tempUAH < amount || amount <= 0) throw new InvalidOperationException(nameof(amount));
                    Amount = (tempUAH - amount) / 28.36m;
                }
                if (Currency == "UAH" && currency.ToUpper() == "EUR")
                {
                    tempEUR = Amount / 33.63m;
                    if (tempEUR < amount || amount <= 0) throw new InvalidOperationException(nameof(amount));
                    Amount = (tempEUR - amount) * 33.63m;
                }
                if (Currency == "EUR" && currency.ToUpper() == "UAH")
                {
                    tempUAH = Amount * 33.63m;
                    if (tempUAH < amount || amount <= 0) throw new InvalidOperationException(nameof(amount));
                    Amount = (tempUAH - amount) / 33.63m;
                }
                if (Currency == "USD" && currency.ToUpper() == "EUR")
                {
                    tempEUR = Amount / 1.19m;
                    if (tempEUR < amount || amount <= 0) throw new InvalidOperationException(nameof(amount));
                    Amount = (tempEUR - amount) * 1.19m;
                }
                if (Currency == "EUR" && currency.ToUpper() == "USD")
                {
                    tempUSD = Amount * 1.19m;
                    if (tempUSD < amount || amount <= 0) throw new InvalidOperationException(nameof(amount));
                    Amount = (tempUSD - amount) / 1.19m;
                }
                if (Currency == "UAH" && currency.ToUpper() == "UAH")
                {
                    if (Amount < amount || amount <= 0) throw new InvalidOperationException(nameof(amount));
                    Amount -= amount;
                }
                if (Currency == "EUR" && currency.ToUpper() == "EUR") 
                {
                    if (Amount < amount || amount <= 0) throw new InvalidOperationException(nameof(amount));
                    Amount -= amount;
                }
                if (Currency == "USD" && currency.ToUpper() == "USD") 
                {
                    if (Amount < amount || amount <= 0) throw new InvalidOperationException(nameof(amount));
                    Amount -= amount;
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

        public decimal GetBalance(string currency)
        {
            try
            {
                if (currency.ToUpper() != "EUR" && currency.ToUpper() != "UAH" && currency.ToUpper() != "USD") throw new NotSupportedException(nameof(currency));
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"Current account currency {Currency} with this dep: ");
            }
          
            if (Currency == "UAH" && currency.ToUpper() == "USD") return Amount * 28.36m;
            if (Currency == "USD" && currency.ToUpper() == "UAH") return Amount / 28.36m;
            if (Currency == "UAH" && currency.ToUpper() == "EUR") return Amount * 33.63m;
            if (Currency == "EUR" && currency.ToUpper() == "UAH") return Amount / 33.63m;
            if (Currency == "USD" && currency.ToUpper() == "EUR") return Amount * 1.19m;
            if (Currency == "EUR" && currency.ToUpper() == "USD") return Amount / 1.19m;
            if (Currency == "UAH" && currency.ToUpper() == "UAH") return Amount;
            if (Currency == "EUR" && currency.ToUpper() == "EUR") return Amount;
            if (Currency == "USD" && currency.ToUpper() == "USD") return Amount;
            return -1m;
        }

       

    }
}
