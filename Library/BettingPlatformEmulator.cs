using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
   public class BettingPlatformEmulator
    {
         private static List<Player> container = new List<Player> { };
         private Player ActivePLayer;
         private Account Account;
         private BetService bet;
         private PaymentService service;

        public BettingPlatformEmulator()
        {
            Account = new Account("USD");
            bet = new BetService();
            service = new PaymentService();
        }
        public void Start()
        {

            if (container.Count == 0)
            {
                ShowListStartMenu();

                while (true)
                {
                    Console.Write("Select -> ");
                    bool input = int.TryParse(Console.ReadLine(), out int parsed);
                    if (!input)
                    {
                        Console.WriteLine("Unsupported command! Try again");
                        continue;
                    }
                    else
                    {
                        if (parsed == 1) 
                        {
                            Register();
                            continue;
                        }
                        if (parsed == 2)
                        {
                            Login();
                            if (ActivePLayer != null)
                            {
                                while (ActivePLayer != null)
                                {
                                    ShowListAccountMenu();
                                    Console.Write("Select -> ");
                                    bool accinput = int.TryParse(Console.ReadLine(), out int playeracc);
                                    if (!accinput)
                                    {
                                        Console.WriteLine("Unsupported command! Try again");
                                        continue;
                                    }
                                    else
                                    {
                                        if (playeracc == 1)
                                        {
                                            Deposit();
                                        }
                                        if (playeracc == 2)
                                        {
                                            Withdraw();
                                        }

                                        if (playeracc == 3)
                                        {
                                            GetOdds();
                                        }
                                        if (playeracc == 4)
                                        {
                                            Bet();
                                        }
                                        if (playeracc == 5)
                                        {
                                            Logout();
                                            
                                        }
                                    }
                                }
                            }
                        }
                        if (parsed == 3)
                        {
                            Exit();
                            return;
                        }
                    }
                }
            }
            
        }
        private void Register()
        {
            Console.WriteLine("!Registration Form!\n");

            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Password = "";
            string Currency = "";
            while (true)
            {
                Console.Write("Please, enter your first name: ");
                FirstName = Console.ReadLine().Replace(" ","");
                if (FirstName == "") continue;
                Console.Write("Please, enter your last name: ");
                LastName = Console.ReadLine().Replace(" ", "");
                if (LastName == "") continue;
                Console.Write("Please, enter your Email adress: ");
                Email = Console.ReadLine().Replace(" ", "");
                if (Email == "") continue;
                Console.Write("Please, enter your Password: ");
                Password = Console.ReadLine().Replace(" ", "");
                if (Password == "") continue;
                break;
            }
                while (true)
                {
                    Console.Write("Which wallet currency would you like to perform: ");
                    Currency = Console.ReadLine();
                        if (Currency.ToUpper() != "UAH" && Currency.ToUpper() != "USD" && Currency.ToUpper() != "EUR")
                         {
                            Console.WriteLine("\nWe cannot perform this operation! Unsupported currency!");
                            continue;
                          }
                        else break;
                }
            Player newPlayer = new Player(FirstName,LastName,Email,Password,Currency);
            container.Add(newPlayer);
            Console.WriteLine("Registration was successful!");
        }
        private void GetOdds()
        {
            Console.WriteLine($"\nActual odd is {bet.Odd}\n");
        }
        private void Bet()
        {
            decimal temp;
            
            while (true)
            {
                Console.Write("Please enter amount of bet\n" +
                    "(If you would like to stop game write -1): ");
                bool isDec = Decimal.TryParse(Console.ReadLine(), out temp);
                if (temp == -1)
                {
                    break;
                }
                if (!isDec) continue;
                if (temp > ActivePLayer.account.Amount)
                {
                    Console.WriteLine("You trying ti place bet more than money on your dep!!!");
                    continue;
                }
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
                            ActivePLayer.account.Withdraw(temp, ActivePLayer.account.Currency);
                            var Res = bet.Bet(temp);
                            ActivePLayer.account.Deposit(Res, ActivePLayer.account.Currency);
                            Console.WriteLine($"You won {Res}");
                            Console.WriteLine($"On you account{ActivePLayer.account.Amount}\n" );
                            bet.GetOdds();
                            break;
                        }
                    }
                }
            }
        }
        private void Login()
        {
            var counter = 0;
            string login = "";
            string password = "";
            Console.WriteLine("Try to login:\n");
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
            if (container.Count == 0)
            {
                Register();
                return;
            }
            foreach (var PlayerAcc in container)
            {
                if (PlayerAcc.Email == login && PlayerAcc.IsPasswordValid(password))
                {
                    counter++;
                    ActivePLayer = PlayerAcc;
                    break;
                }
            }
            if (counter == 0) Register();        
        }
        private void Deposit()
        {
            string Currency = "";
            decimal amount = 0;
            while (true)
            {
                Console.Write("Please enter currency to Deposit: ");
                Currency = Console.ReadLine();
                if (Currency == "") continue;
                if (Currency.ToUpper() != "UAH" && Currency.ToUpper() != "USD" && Currency.ToUpper() != "EUR")
                {
                    Console.WriteLine("\nWe cannot perform this operation! Unsupported currency!");
                    continue;
                }
                Console.Write("Please enter Amount to Deposit: ");
                bool input = decimal.TryParse(Console.ReadLine(), out amount);
                if (!input)
                {
                    Console.WriteLine("\nUnsupported command! Try again");
                    continue;
                }
                break;
            }
            service.StartDeposit(amount,Currency);
            ActivePLayer.Deposit(amount,Currency);
            Account.Deposit(amount,Currency);
        }
        private void Withdraw()
        {
            string Currency = "";
            decimal amount = 0;
            while (true)
            {
                Console.Write("Please enter currency to Withdraw: ");
                Currency = Console.ReadLine();
                if (Currency == "") continue;
                if (Currency.ToUpper() != "UAH" && Currency.ToUpper() != "USD" && Currency.ToUpper() != "EUR")
                {
                    Console.WriteLine("\nWe cannot perform this operation! Unsupported currency!");
                    continue;
                }
                Console.Write("Please enter Amount to Withdraw: ");
                bool input = decimal.TryParse(Console.ReadLine(), out amount);
                if (!input)
                {
                    Console.WriteLine("\nUnsupported command! Try again");
                    continue;
                }
                break;
            }

            if (ActivePLayer.account.Amount < amount && Currency.ToUpper() =="USD")
            {
                Console.WriteLine("There is insuffient funds on you account!");
                return;
            }
            if (ActivePLayer.account.Amount < amount / 28.36m && Currency.ToUpper() == "UAH")
            {
                Console.WriteLine("There is insuffient funds on you account!");
                return;
            }
            if (ActivePLayer.account.Amount < amount / 0.80m && Currency.ToUpper() == "EUR")
            {
                Console.WriteLine("There is insuffient funds on you account!");
                return;
            }
            if (Account.Amount < amount && Currency.ToUpper() == "USD")
            {
                Console.WriteLine("There is some problem on the platform side");
                return;
            }
            if (Account.Amount * 28.36m < amount && Currency.ToUpper() == "UAH")
            {
                Console.WriteLine("There is some problem on the platform side");
                return;
            }
            if (Account.Amount * 1.19m < amount && Currency.ToUpper() == "EUR")
            {
                Console.WriteLine("There is some problem on the platform side");
                return;
            }
            else
            {
                service.StartWithdrawal(amount, Currency);
                ActivePLayer.Withdraw(amount, Currency);
                Account.Withdraw(amount, Currency);
            }
        }
        private void Logout()
        {
            ActivePLayer = null;
        }
        private void Exit()
        {
            return;
        }
        private void ShowListStartMenu()
        {
            Console.WriteLine("Welcome to Parimatch!\n\n" +
                "Here the list of available commands!\t(Just write a number)\n" +
                "1.\tRegister\n" +
                "2.\tLogin\n" +
                "3.\tExit\n");
           
        }
        private void ShowListAccountMenu()
        {
            Console.WriteLine("\nThis actions you can perform\n\n" +
                "Here the list of available commands!\t(Just write a number)\n" +
                "1.\tDeposit\n" +
                "2.\tWithdraw\n" +
                "3.\tGetOdds\n" +
                "4.\tBet\n" +
                "3.\tLogout\n");
            
        }
    }
}
