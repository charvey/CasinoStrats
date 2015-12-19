using System;
using Xunit;

namespace CasinoStrats.Core.Tests
{
    public class PlayerTest
    {
        private const decimal STARTING_BANKROLL = 5m;

        [Theory]
        [InlineData(0)]
        [InlineData(2.5)]
        [InlineData(5)]
        public void TryDeduct_EnoughMoney(decimal amount)
        {
            var player = new Player(STARTING_BANKROLL);

            var result = player.TryDeduct(amount);

            Assert.True(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2.5)]
        [InlineData(5)]
        public void TryDeduct_EnoughMoney_BankrollChanges(decimal amount)
        {
            var player = new Player(STARTING_BANKROLL);

            player.TryDeduct(amount);

            Assert.Equal(STARTING_BANKROLL - amount, player.Bankroll);
        }

        [Fact]
        public void TryDeduct_NotEnoughMoney()
        {
            var player = new Player(STARTING_BANKROLL);

            var result = player.TryDeduct(STARTING_BANKROLL + .01m);

            Assert.False(result);
        }

        [Fact]
        public void TryDeduct_NotEnoughMoney_NoBankrollChange()
        {
            var player = new Player(STARTING_BANKROLL);

            player.TryDeduct(STARTING_BANKROLL + .01m);

            Assert.Equal(STARTING_BANKROLL, player.Bankroll);
        }

        [Theory]
        [InlineData(-2.5)]
        [InlineData(-5)]
        public void TryDeduct_InvalidDeduction(decimal amount)
        {
            var player = new Player(STARTING_BANKROLL);

            Assert.Throws<ArgumentException>(() => player.TryDeduct(amount));
        }

        [Theory]
        [InlineData(-2.5)]
        [InlineData(-5)]
        public void TryDeduct_InvalidDeduction_NoBankrollChange(decimal amount)
        {
            var player = new Player(STARTING_BANKROLL);

            try { player.TryDeduct(amount); }
            catch (ArgumentException) { }

            Assert.Equal(STARTING_BANKROLL, player.Bankroll);
        }

        [Theory]
        [InlineData(-2.5)]
        [InlineData(-5)]
        public void Pay_InvalidPayments(decimal amount)
        {
            var player = new Player(STARTING_BANKROLL);

            Assert.Throws<ArgumentException>(() => player.Pay(amount));
        }
    }
}
