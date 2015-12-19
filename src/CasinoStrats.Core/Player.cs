using System;

namespace CasinoStrats.Core
{
    public class Player
    {
        private decimal bankroll;

        public Player(decimal bankroll)
        {
            this.bankroll = bankroll;
        }

        public bool TryDeduct(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Deductions must be positive", nameof(amount));

            if (bankroll < amount)
                return false;

            bankroll -= amount;
            return true;
        }
    }
}