using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PaymentService
    {
        public PaymentMethods[] AvailablePaymentMethods { get; private set; }

        public PaymentService()
        {
            AvailablePaymentMethods = new PaymentMethods[] {new CreditCard(), new Privet48(), new Stereobank() , new GiftVoucher()};
        }

        public void StartDeposit(decimal amount, string currency)
        {
            for (var i = 0; i < AvailablePaymentMethods.Length; i++)
                Console.WriteLine($"{i+1} {AvailablePaymentMethods[i].Name}");
            int choose;
            while (true)
            {
                Console.Write("Pick -> ");
                bool isNum = int.TryParse(Console.ReadLine(), out choose);
                if (!isNum) continue;
                if (choose == 0)
                    continue;
                if (choose > AvailablePaymentMethods.Length)
                    continue;
                break;
            }
            AvailablePaymentMethods[choose - 1].StartDeposit(amount,currency);
        }
        public void StartWithdrawal(decimal amount, string currency)
        {
            for (var i = 0; i < AvailablePaymentMethods.Length - 1; i++)
                Console.WriteLine($"{i + 1} {AvailablePaymentMethods[i].Name}");
            int choose;
            while (true)
            {
                Console.Write("Pick -> ");
                bool isNum = int.TryParse(Console.ReadLine(), out choose);
                if (!isNum) continue;
                if (choose == 0)
                    continue;
                if (choose > AvailablePaymentMethods.Length)
                    continue;
                break;
            }
            AvailablePaymentMethods[choose - 1].StartWithdrawal(amount, currency);
        }
    }
}
