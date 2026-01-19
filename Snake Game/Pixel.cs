using System;


namespace SnakeGame
{
    /// <summary>
    /// Represents a single drawable pixel on the console screen.
    /// This struct is immutable and uses value semantics.
    /// </summary>
    public readonly struct Pixel
    {
        private const char PixelChar = '█';

        /// <summary>
        /// Initializes a new instance of the Pixel struct.
        /// </summary>
        /// <param name="x">The X coordinate of the pixel.</param>
        /// <param name="y">The Y coordinate of the pixel.</param>
        /// <param name="color">The console color of the pixel.</param>
        /// <param name="pixelSize">The size multiplier for rendering (default is 3).</param>
        public Pixel(int x, int y, ConsoleColor color, int pixelSize = 3)
        {
            X = x;
            Y = y;
            Color = color;
            PixelSize = pixelSize;
        }

        /// <summary>
        /// Gets the X coordinate of the pixel.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the Y coordinate of the pixel.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Gets the console color of the pixel.
        /// </summary>
        public ConsoleColor Color { get; }

        /// <summary>
        /// Gets the size multiplier used for rendering the pixel.
        /// </summary>
        public int PixelSize { get; }

        /// <summary>
        /// Draws the pixel on the console at its specified position and color.
        /// </summary>
        public void Draw()
        {
            Console.ForegroundColor = Color;

            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition(X * PixelSize + x, Y * PixelSize + y);
                    Console.Write(PixelChar);
                }
            }
        }

        /// <summary>
        /// Clears the pixel from the console by replacing it with spaces.
        /// </summary>
        public void Clear()
        {
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition(X * PixelSize + x, Y * PixelSize + y);
                    Console.Write(' ');
                }
            }
        }
    }
}
