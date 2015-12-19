using System;

namespace CasinoStrats.Core
{
    public class Player
    {
        public decimal Bankroll { get; private set; }

        public Player(decimal bankroll)
        {
            this.Bankroll = bankroll;
        }

        public bool TryDeduct(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Deductions must be positive", nameof(amount));

            if (Bankroll < amount)
                return false;

            Bankroll -= amount;
            return true;
        }

        public void Pay(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Payments must be positive", nameof(amount));

            Bankroll += amount;
        }
    }
}