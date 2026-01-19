using Xunit;
using SnakeGame;

namespace Snake_Game.Tests
{
    /// <summary>
    /// Unit tests for the Direction enum.
    /// </summary>
    public class DirectionTests
    {
        [Fact]
        public void Direction_HasFourValues()
        {
            // Arrange & Act
            var directions = System.Enum.GetValues(typeof(Direction));

            // Assert
            Assert.Equal(4, directions.Length);
        }

        [Theory]
        [InlineData(Direction.Up)]
        [InlineData(Direction.Down)]
        [InlineData(Direction.Left)]
        [InlineData(Direction.Right)]
        public void Direction_AllValuesAreDefined(Direction direction)
        {
            // Assert
            Assert.True(System.Enum.IsDefined(typeof(Direction), direction));
        }
    }
}
