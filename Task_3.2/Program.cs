using System;
using Library;
namespace Task_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentService p = new PaymentService();
            p.StartDeposit(50,"USD");

            p.StartWithdrawal(50, "USD");

            p.StartWithdrawal(50, "USD");

            p.StartDeposit(50, "USD");

            p.StartWithdrawal(50, "USD");


            Console.ReadKey();
        }
    }
}
