using System;
using Library;
namespace Task_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentService service = new PaymentService();
            //Voucher CardNum = 1234567890
            service.StartDeposit(500, "UAH");
            
            //Voucher CardNum = 1234567890
            service.StartDeposit(500, "UAH");
           
            Console.ReadKey();
        }
    }
}
