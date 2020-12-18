using System;
using Library;
namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard card = new CreditCard();

            card.StartDeposit(50, "USD");

            card.StartWithdrawal(50, "USD");

            Privet48 privet48 = new Privet48();

            privet48.StartDeposit(50, "USD");

            Stereobank stereo = new Stereobank();
            stereo.StartWithdrawal(50,"USD");

            GiftVoucher gift = new GiftVoucher();

            gift.StartDeposit(500, "USD");

            Console.ReadKey();
        }
    }
}
