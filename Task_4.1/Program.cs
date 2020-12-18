using System;
using Library;

namespace Task_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new LimitExceededException("This is custom exception!");
            }
            catch (InsufficientFundsException ex1)
            {
                Console.WriteLine(ex1);
            }
            catch (LimitExceededException ex2)
            {
                Console.WriteLine(ex2);
            }
            catch (PaymentServiceException ex3)
            {
                Console.WriteLine(ex3);
            }
            catch (Exception ex4)
            {
                Console.WriteLine(ex4);
            }

            Console.ReadKey();
        }
    }
}
