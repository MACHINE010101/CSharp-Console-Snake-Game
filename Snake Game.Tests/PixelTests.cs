using System;
using Xunit;
using SnakeGame;

namespace Snake_Game.Tests
{
    /// <summary>
    /// Unit tests for the Pixel struct.
    /// </summary>
    public class PixelTests
    {
        [Fact]
        public void Pixel_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            var pixel = new Pixel(5, 10, ConsoleColor.Red, 3);

            // Assert
            Assert.Equal(5, pixel.X);
            Assert.Equal(10, pixel.Y);
            Assert.Equal(ConsoleColor.Red, pixel.Color);
            Assert.Equal(3, pixel.PixelSize);
        }

        [Fact]
        public void Pixel_DefaultPixelSize_IsThree()
        {
            // Arrange & Act
            var pixel = new Pixel(0, 0, ConsoleColor.White);

            // Assert
            Assert.Equal(3, pixel.PixelSize);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 20)]
        [InlineData(-5, -10)]
        public void Pixel_CanBeCreatedWithVariousCoordinates(int x, int y)
        {
            // Arrange & Act
            var pixel = new Pixel(x, y, ConsoleColor.Blue);

            // Assert
            Assert.Equal(x, pixel.X);
            Assert.Equal(y, pixel.Y);
        }
    }
}
