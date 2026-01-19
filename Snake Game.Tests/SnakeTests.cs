using System;
using System.Linq;
using Xunit;
using SnakeGame;

namespace Snake_Game.Tests
{
    /// <summary>
    /// Unit tests for the Snake class.
    /// </summary>
    public class SnakeTests
    {
        [Fact]
        public void Snake_Constructor_InitializesHeadCorrectly()
        {
            // Arrange & Act
            var snake = new Snake(10, 5, ConsoleColor.Green, ConsoleColor.DarkGreen);

            // Assert
            Assert.Equal(10, snake.Head.X);
            Assert.Equal(5, snake.Head.Y);
            Assert.Equal(ConsoleColor.Green, snake.Head.Color);
        }

        [Fact]
        public void Snake_Constructor_InitializesBodyWithCorrectLength()
        {
            // Arrange
            int bodyLength = 3;

            // Act
            var snake = new Snake(10, 5, ConsoleColor.Green, ConsoleColor.DarkGreen, bodyLength);

            // Assert
            Assert.Equal(bodyLength + 1, snake.Body.Count); // bodyLength + 1 because of loop logic
        }

        [Fact]
        public void Snake_Move_UpdatesHeadPosition()
        {
            // Arrange
            var snake = new Snake(10, 5, ConsoleColor.Green, ConsoleColor.DarkGreen);
            int initialX = snake.Head.X;

            // Act
            snake.Move(Direction.Right);

            // Assert
            Assert.Equal(initialX + 1, snake.Head.X);
        }

        [Fact]
        public void Snake_MoveWithEat_IncreasesBodyLength()
        {
            // Arrange
            var snake = new Snake(10, 5, ConsoleColor.Green, ConsoleColor.DarkGreen);
            int initialBodyCount = snake.Body.Count;

            // Act
            snake.Move(Direction.Right, eat: true);

            // Assert
            Assert.Equal(initialBodyCount + 1, snake.Body.Count);
        }

        [Fact]
        public void Snake_MoveWithoutEat_MaintainsBodyLength()
        {
            // Arrange
            var snake = new Snake(10, 5, ConsoleColor.Green, ConsoleColor.DarkGreen);
            int initialBodyCount = snake.Body.Count;

            // Act
            snake.Move(Direction.Right, eat: false);

            // Assert
            Assert.Equal(initialBodyCount, snake.Body.Count);
        }

        [Theory]
        [InlineData(Direction.Up)]
        [InlineData(Direction.Down)]
        [InlineData(Direction.Left)]
        [InlineData(Direction.Right)]
        public void Snake_Move_WorksForAllDirections(Direction direction)
        {
            // Arrange
            var snake = new Snake(10, 10, ConsoleColor.Green, ConsoleColor.DarkGreen);
            int initialX = snake.Head.X;
            int initialY = snake.Head.Y;

            // Act
            snake.Move(direction);

            // Assert
            bool positionChanged = snake.Head.X != initialX || snake.Head.Y != initialY;
            Assert.True(positionChanged);
        }
    }
}
