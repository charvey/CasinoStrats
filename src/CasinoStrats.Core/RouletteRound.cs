using System;
using System.Collections.Generic;

namespace CasinoStrats.Core
{
    public class RouletteRound
    {
        private Dictionary<Tuple<Player, RouletteBet>, decimal> bets;
        private RoulettePocket pocket;

        public RouletteRound()
        {
            bets = new Dictionary<Tuple<Player, RouletteBet>, decimal>();
        }

        public void PlaceBet(Player player, RouletteBet rouletteBet, decimal betAmount)
        {
            if (!player.TryDeduct(betAmount))
                return;

            var key = Tuple.Create(player, rouletteBet);
            if (bets.ContainsKey(key))
                bets[key] += betAmount;
            else
                bets[key] = betAmount;
        }

        public void SpinWheel()
        {
            throw new NotImplementedException();
        }

        public void MakePayouts()
        {
            throw new NotImplementedException();
        }
    }
}
