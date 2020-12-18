using System;
using Library;
namespace Task_1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("John Doe","Betman","john777@gmail.com","TheP@$$w0rd","USD");

            Console.WriteLine($"Login with login {player.Email} and password 'TheP@$$w0rd' is {player.IsPasswordValid("TheP@$$w0rd")}");

            Console.WriteLine($"Login with login {player.Email} and password 'TheP@$$w0rd' is {player.IsPasswordValid("TheP@$$w0r")}");

            player.Deposit(100, "USD");

            player.Withdraw(50,"EUR");

            player.Withdraw(1000,"USD");

            Player playerFa = new Player("Bob", "Betman", "john777@gmail.com", "TheP@$$w0rd", "PLN");

            Console.ReadKey();
        }
    }
}
