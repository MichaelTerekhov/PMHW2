using System;
using Library;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            BetService bet = new BetService();

            Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
            Console.WriteLine();
            bet.GetOdds();
            Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
            Console.WriteLine();
            bet.GetOdds();
            Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
            Console.WriteLine();
            bet.GetOdds();
            Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
            Console.WriteLine();
            bet.GetOdds();
            Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
            Console.WriteLine();
            bet.GetOdds();
            Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
            Console.WriteLine();
            bet.GetOdds();
            Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
            Console.WriteLine();
            bet.GetOdds();
            Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
            Console.WriteLine();
            bet.GetOdds();
            Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
            Console.WriteLine();
            bet.GetOdds();
            Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
            Console.WriteLine();
            bet.GetOdds();
            int counter = 0;
            while (counter < 3)
            {
                if (bet.Odd > 12)
                {
                    Console.WriteLine($"I have bet 100 USD with the odd {bet.Odd} and i have earned {bet.Bet(100m)}");
                    counter++;
                    bet.GetOdds();
                }
                else bet.GetOdds();
            }
            decimal MyMoney = 10000m;
            MyMoney = Game(MyMoney);
            Console.ReadKey();
        }
        static decimal Game(decimal my)
        {
            BetService bet = new BetService();
            decimal temp;
            decimal res = my;
            while (true)
            {
                if (res >= 150000m || res == 0m)
                {
                    break;
                }
                Console.Write("Please enter amount of bet: ");
                bool isDec = Decimal.TryParse(Console.ReadLine(), out temp);
                if (!isDec) continue;
                if (temp > res) continue;
                else
                {
                    while (true)
                    {
                        int ch;
                        Console.WriteLine($"Do you like this odd {bet.Odd}() :");
                        Console.WriteLine("If yes write: 1\n" +
                            "If no write: 0\n");
                        Console.Write("Action-> ");
                        bool IsCh = int.TryParse(Console.ReadLine(), out ch);
                        if (!IsCh) continue;
                        if (ch != 0 && ch != 1) continue;
                        if (ch == 0)
                        {
                            bet.GetOdds();
                            continue;
                        }
                        if (ch == 1)
                        {
                            res -= temp;
                            res += bet.Bet(temp);
                            bet.GetOdds();
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"Game Over! My balance is {res}");
            return res;
        }
    }
}
