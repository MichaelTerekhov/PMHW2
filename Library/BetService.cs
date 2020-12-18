using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BetService
    {
        public decimal Odd { get; private set; }
        public BetService()
        {
            Random rand = new Random();
            Odd = Math.Round((rand.Next(10,248)/9.9m),2);
            
        }
        public float GetOdds()
        {
            Random rand = new Random();
            Odd = Math.Round((rand.Next(10, 248) / 9.9m), 2);
            return (float)Odd;
        }
        private bool IsWon()
        {
            double Chance = (1d / (double)Odd) * 100d;

            Random rand = new Random();
            if (Chance < 4d) Chance = 4d;
            int randomizer = rand.Next(1, 101);
            if (randomizer >= 1 && randomizer <= (int)Chance) return true;
            return false;
        }

       public decimal Bet(decimal amount)
        {
            decimal res = 0;

            if (IsWon()) res = amount * Odd;

            return res;
        }
    }
}
