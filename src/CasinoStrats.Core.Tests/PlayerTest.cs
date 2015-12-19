using Xunit;

namespace CasinoStrats.Core.Tests
{
    public class PlayerTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(2.5)]
        [InlineData(5)]
        public void TryDeduct_EnoughMoney(decimal amount)
        {
            var player = new Player(5);

            var result = player.TryDeduct(amount);

            Assert.True(result);
        }

        [Fact]
        public void TryDeduct_NotEnoughMoney()
        {
            var player = new Player(5);

            var result = player.TryDeduct(5.01m);

            Assert.False(result);
        }

        [Theory]
        [InlineData(-0)]
        [InlineData(-2.5)]
        [InlineData(-5)]
        public void TryDeduct_InvalidDeduction(decimal amount)
        {
            var player = new Player(5);

            var result = player.TryDeduct(amount);

            Assert.True(result);
        }
    }
}
