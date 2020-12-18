using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    interface ISupportDeposit
    {
        void StartDeposit(decimal amount, string currency);
    }

    interface ISupportWithdrawal
    {
        void StartWithdrawal(decimal amount, string currency);
    }
    public abstract class PaymentMethods
    {
        public abstract string Name { get; set; }
        public abstract void StartDeposit(decimal amount, string currency);
        public abstract void StartWithdrawal(decimal amount, string currency);
    }

    public class CreditCard : PaymentMethods, ISupportDeposit, ISupportWithdrawal
    {
        public override string Name { get; set; }
        public static decimal TransactionLimit { get; private set; }
        public CreditCard()
        {
            Name = "CreditCard";
        }

        public override void StartDeposit(decimal amount, string currency)
        {
            try
            {
                Random rand = new Random();
                int SuddenlyException = rand.Next(1,100);
                if (SuddenlyException <= 2) throw new PaymentServiceException(nameof(SuddenlyException));
                string CardNumber = "";
                string ExpiryDate = "";
                string CVV = "";

                while (true)
                {
                    bool checker = true;
                    Console.WriteLine($"Please, enter card number(Visa or Mastercard): ");
                    CardNumber = Console.ReadLine().Replace(" ", "");
                    if (CardNumber == "") continue;
                    for (var i = 0; i < CardNumber.Length; i++)
                    {
                        bool containsNums = int.TryParse(Convert.ToString(CardNumber[i]), out int m);
                        if (!containsNums)
                        {
                            checker = false;
                            continue;
                        }
                    }
                    if (checker == false)
                    {
                        Console.WriteLine($"Wrong input!!!");
                        continue;
                    }
                    if (CardNumber[0] != '4' && CardNumber[0] != '5')
                    {
                        Console.WriteLine($"This type of card is unsupported");
                        continue;
                    }
                    if (CardNumber.Length != 16)
                    {
                        Console.WriteLine($"Wrong Number!!!");
                        continue;
                    }
                    while (true)
                    {
                        checker = true;
                        Console.WriteLine($"Please, enter Expiry Date(Example 04/22): ");
                        ExpiryDate = Console.ReadLine().Replace(" ", "");
                        if (ExpiryDate == "") continue;
                        for (var i = 0; i < ExpiryDate.Length; i++)
                        {
                            if (ExpiryDate[i] == '/')
                                continue;

                            bool containsNums = int.TryParse(Convert.ToString(ExpiryDate[i]), out int m);
                            if (!containsNums)
                            {
                                checker = false;
                                continue;
                            }
                        }
                        if (checker == false)
                        {
                            Console.WriteLine($"Wrong input!!!");
                            continue;
                        }
                        if (ExpiryDate[2] != '/')
                        {
                            Console.WriteLine($"Wrong ExpiryDate");
                            continue;
                        }
                        if (ExpiryDate.Length != 5)
                        {
                            Console.WriteLine($"Wrong Number!!!");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        checker = true;
                        Console.WriteLine($"Please, enter CVV: ");
                        CVV = Console.ReadLine().Replace(" ", "");
                        if (CVV == "") continue;
                        for (var i = 0; i < CVV.Length; i++)
                        {
                            bool containsNums = int.TryParse(Convert.ToString(CVV[i]), out int m);
                            if (!containsNums)
                            {
                                checker = false;
                                continue;
                            }
                        }
                        if (checker == false)
                        {
                            Console.WriteLine($"Wrong input!!!");
                            continue;
                        }
                        if (CVV.Length != 3)
                        {
                            Console.WriteLine($"Wrong CVV!!!");
                            continue;
                        }
                        break;
                    }

                    break;
                }
                Console.WriteLine($"Your Deposit'{amount}' {currency} Processed on {CardNumber}");
            }
            catch (PaymentServiceException)
            {
                Console.WriteLine("Ooops, smth went wrong! Try again later...");
            }
        }
        public override void StartWithdrawal(decimal amount, string currency)
        {
            try
            {
                    Random rand = new Random();
                    int SuddenlyException = rand.Next(1, 100);
                    if (SuddenlyException <= 2) throw new PaymentServiceException(nameof(SuddenlyException));
                    string CardNumber = "";
                while (true)
                {
                    bool checker = true;
                    Console.WriteLine($"Please, enter card number(Visa or Mastercard): ");
                    CardNumber = Console.ReadLine().Replace(" ", "");
                    if (CardNumber == "") continue;
                    for (var i = 0; i < CardNumber.Length; i++)
                    {
                        bool containsNums = int.TryParse(Convert.ToString(CardNumber[i]), out int m);
                        if (!containsNums)
                        {
                            checker = false;
                            continue;
                        }
                    }
                    if (checker == false)
                    {
                        Console.WriteLine($"Wrong input!!!");
                        continue;
                    }
                    if (CardNumber[0] != '4' && CardNumber[0] != '5')
                    {
                        Console.WriteLine($"This type of card is unsupported");
                        continue;
                    }
                    if (CardNumber.Length != 16)
                    {
                        Console.WriteLine($"Wrong Number!!!");
                        continue;
                    }
                    if(currency.ToUpper() == "UAH")TransactionLimit += amount;
                    if (currency.ToUpper() == "EUR") TransactionLimit += amount*33.63m; 
                    if (currency.ToUpper() == "USD") TransactionLimit += amount*28.36m;
                    if (TransactionLimit > 3000) throw new LimitExceededException(nameof(TransactionLimit));
                    break;
                }
                Console.WriteLine($"Your Withdraw '{amount}' {currency} Processed on {CardNumber}");
            }
            catch (LimitExceededException)
            {
                Console.WriteLine("Sum of transactions on your credit card is exceeded limit! Please try again!");
            }
            catch (PaymentServiceException)
            {
                Console.WriteLine("Ooops, smth went wrong! Try again later...");
            }
        }

    }
    public  class Bank : PaymentMethods, ISupportDeposit, ISupportWithdrawal
    {
        public override string Name { get; set; }
        public string[] AvailableCards { get; private set; } = new string[5] ;
        public static decimal TransactionLimit { get; private set; }
        public static decimal TransactionLimit2 { get; private set; }
        public Bank()
        {
            Name = "Bro!";
        }
        public Bank(string[] acc)
        {
            for (var i = 0; i < acc.Length; i++)
                AvailableCards[i] = acc[i];
        }
        public override void StartDeposit(decimal amount, string currency)
        {
            try
            {
                Random rand = new Random();
                int SuddenlyException = rand.Next(1, 100);
                if (SuddenlyException <= 2) throw new PaymentServiceException(nameof(SuddenlyException));
                var login = "";
                var password = "";
                Console.WriteLine($"Welcome, dear client, to the online bank{Name}\n");
                while (true)
                {
                    Console.Write("Please, enter your login(email adress): ");
                    login = Console.ReadLine().Replace(" ", "");
                    if (login == "") continue;
                    Console.Write("Please, enter your password: ");
                    password = Console.ReadLine().Replace(" ", "");
                    if (password == "") continue;
                    break;
                }
                Console.WriteLine($"Hello Mr {login}, Pick a card from your available cards:");
                for (var i = 0; i < AvailableCards.Length; i++)
                {
                    if (AvailableCards[i] == null)
                        break;
                    Console.WriteLine($"{i + 1}. {AvailableCards[i]}");

                }
                int choose;
                int NullCount = 0;
                for (var i = 0; i < AvailableCards.Length; i++)
                {
                    if (AvailableCards[i] == null)
                        NullCount++;
                }
                while (true)
                {
                    Console.Write("Pick -> ");
                    bool isNum = int.TryParse(Console.ReadLine(), out choose);
                    if (!isNum) continue;
                    if (choose == 0)
                        continue;
                    if (choose > AvailableCards.Length - NullCount)
                        continue;

                    if (currency.ToUpper() == "UAH" && Name == "Privet48") TransactionLimit += amount;
                    if (currency.ToUpper() == "EUR" && Name == "Privet48") TransactionLimit += amount * 33.63m;
                    if (currency.ToUpper() == "USD" && Name == "Privet48") TransactionLimit += amount * 28.36m;
                    if (TransactionLimit > 10000) throw new LimitExceededException(nameof(TransactionLimit));
                    if (currency.ToUpper() == "UAH" && Name == "Stereobank") TransactionLimit2 += amount;
                    if (currency.ToUpper() == "EUR" && Name == "Stereobank") TransactionLimit2 += amount * 33.63m;
                    if (currency.ToUpper() == "USD" && Name == "Stereobank") TransactionLimit2 += amount * 28.36m;
                    if (TransactionLimit > 7000) throw new LimitExceededException(nameof(TransactionLimit2));
                    break;
                }

                Console.WriteLine($"Your withdraw'{amount}' {currency} Processed from {AvailableCards[choose - 1]} successfully");
            }
            catch (LimitExceededException)
            {
                Console.WriteLine("Sum of transactions on your credit card is exceeded limit! Please try again!");
            }
            catch (PaymentServiceException)
            {
                Console.WriteLine("Ooops, smth went wrong! Try again later...");
            }
        }
        public override void StartWithdrawal(decimal amount, string currency)
        {
            try
            {
                Random rand = new Random();
                int SuddenlyException = rand.Next(1, 100);
                if (SuddenlyException <= 2) throw new PaymentServiceException(nameof(SuddenlyException));
                var login = "";
                var password = "";
                Console.WriteLine($"Welcome, dear client, to the online bank{Name}\n");
                while (true)
                {
                    Console.Write("Please, enter your login(email adress): ");
                    login = Console.ReadLine().Replace(" ", "");
                    if (login == "") continue;
                    Console.Write("Please, enter your password: ");
                    password = Console.ReadLine().Replace(" ", "");
                    if (password == "") continue;
                    break;
                }
                Console.WriteLine($"Hello Mr {login}, Pick a card from your available cards:");
                for (var i = 0; i < AvailableCards.Length; i++)
                {
                    if (AvailableCards[i] == null) break;
                    Console.WriteLine($"{i + 1}. {AvailableCards[i]}");
                }
                int choose;
                int NullCount = 0;
                for (var i = 0; i < AvailableCards.Length; i++)
                {
                    if (AvailableCards[i] == null)
                        NullCount++;
                }
                while (true)
                {
                    Console.Write("Pick -> ");
                    bool isNum = int.TryParse(Console.ReadLine(), out choose);
                    if (!isNum) continue;
                    if (choose == 0)
                        continue;
                    if (choose > AvailableCards.Length - NullCount)
                        continue;

                    break;
                }

                Console.WriteLine($"Your have deposit'{amount}' {currency} Processed from {AvailableCards[choose - 1]} successfully");
            }
            catch (PaymentServiceException)
            {
                Console.WriteLine("Ooops, smth went wrong! Try again later...");
            }
        }

    }

    public class Privet48 : Bank
    {
        public override string Name { get; set; }
        public static string[] AvailableCards { get; private set; } = new string[] { "Gold", "Platinum" };

    public Privet48():base(AvailableCards)
        {
            Name = "Privet48";
        }

    }

    public class Stereobank : Bank
    {
        public override string Name { get; set; }
        public static string[] AvailableCards { get; private set; } = new string[] { "Black", "White", "Iron" };
        public Stereobank() : base(AvailableCards)
        {
            Name = "Stereobank";
        }
    }

    public class GiftVoucher : PaymentMethods,ISupportDeposit
    {
        public override string Name { get; set; }

        private static List<string> container = new List<string> { };
        private bool IsEmpty => container.Count == 0;
        private bool IsFull => container.Count == 99900000;
        public GiftVoucher()
        {
            Name = "GiftVoucher";
        }
        public override void StartDeposit(decimal amount, string currency)
        {
            try
            {
                Random rand = new Random();
                int SuddenlyException = rand.Next(1, 100);
                if (SuddenlyException <= 2) throw new PaymentServiceException(nameof(SuddenlyException));
                string CardNum = "";
                if (amount != 100m && amount != 500m && amount != 1000m)
                {
                    while (true)
                    {
                        Console.WriteLine("GiftVouchers can be only 100,500,1000");
                        bool containsNums = decimal.TryParse(Console.ReadLine(), out amount);
                        if (!containsNums)
                        {
                            continue;
                        }
                        if (amount != 100m && amount != 500m && amount != 1000m) continue;
                        while (true)
                        {
                            bool checker = true;
                            Console.WriteLine($"Please, enter CardNum: ");
                            CardNum = Console.ReadLine().Replace(" ", "");

                            if (IsEmpty)
                            {
                                container.Add(CardNum);
                            }
                            else
                            {
                                for (var i = 0; i < container.Count; i++)
                                {
                                    if (CardNum == container[i])
                                    {
                                        throw new InsufficientFundsException(nameof(CardNum));
                                    }
                                }
                                container.Add(CardNum);
                            }

                            if (CardNum == "") continue;
                            for (var i = 0; i < CardNum.Length; i++)
                            {
                                bool containsNums2 = int.TryParse(Convert.ToString(CardNum[i]), out int m);
                                if (!containsNums2)
                                {
                                    checker = false;
                                    continue;
                                }
                            }
                            if (checker == false)
                            {
                                Console.WriteLine($"Wrong input!!!");
                                continue;
                            }
                            if (CardNum.Length != 10)
                            {
                                Console.WriteLine($"Wrong CardNum!!!");
                                continue;
                            }
                            break;
                        }

                        break;
                    }
                }
                else
                {
                    while (true)
                    {
                        bool checker = true;
                        Console.WriteLine($"Please, enter CardNum: ");
                        CardNum = Console.ReadLine().Replace(" ", "");

                        if (IsEmpty)
                        {
                            container.Add(CardNum);
                        }
                        else
                        {
                            for (var i = 0; i < container.Count; i++)
                            {
                                if (CardNum == container[i])
                                {
                                    throw new InsufficientFundsException(nameof(CardNum));
                                }
                            }
                            container.Add(CardNum);
                        }

                        if (CardNum == "") continue;
                        for (var i = 0; i < CardNum.Length; i++)
                        {
                            bool containsNums2 = int.TryParse(Convert.ToString(CardNum[i]), out int m);
                            if (!containsNums2)
                            {
                                checker = false;
                                continue;
                            }
                        }
                        if (checker == false)
                        {
                            Console.WriteLine($"Wrong input!!!");
                            continue;
                        }
                        if (CardNum.Length != 10)
                        {
                            Console.WriteLine($"Wrong CardNum!!!");
                            continue;
                        }
                        break;
                    }
                }
                Console.WriteLine($"Your deposit'{amount}' {currency} processed from {Name}: {CardNum} successfully");
            }
            catch (InsufficientFundsException)
            {
                Console.WriteLine("There are no money on this voucher\n" +
                    "Please check vouchers CardNum. And try to rewrite");
            }
            catch (PaymentServiceException)
            {
                Console.WriteLine("Ooops, smth went wrong! Try again later...");
            }
        }
        public override void StartWithdrawal(decimal amount, string currency)
        {
            return;
        }
    }

}
