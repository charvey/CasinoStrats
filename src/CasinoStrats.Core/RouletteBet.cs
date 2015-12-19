namespace CasinoStrats.Core
{
    public abstract class RouletteBet
    {
        public abstract decimal Payout { get; }
        public abstract bool Matches(RoulettePocket pocket);
    }
}