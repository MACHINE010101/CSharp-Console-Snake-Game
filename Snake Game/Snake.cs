using System;
using System.Collections.Generic;



namespace SnakeGame
{
    /// <summary>
    /// Represents the snake entity in the game, including its head, body, and movement logic.
    /// </summary>
    public class Snake
    {
        private readonly ConsoleColor _bodyColor;
        private readonly ConsoleColor _headColor;

        /// <summary>
        /// Initializes a new instance of the Snake class.
        /// </summary>
        /// <param name="initialX">The initial X coordinate of the snake's head.</param>
        /// <param name="initialY">The initial Y coordinate of the snake's head.</param>
        /// <param name="headColor">The color of the snake's head.</param>
        /// <param name="bodyColor">The color of the snake's body segments.</param>
        /// <param name="bodyLength">The initial length of the snake's body (default is 3).</param>
        public Snake(int initialX, int initialY, ConsoleColor headColor, ConsoleColor bodyColor, int bodyLength = 3)
        {
            _headColor = headColor;
            _bodyColor = bodyColor;

            Head = new Pixel(initialX, initialY, _headColor);

            for (int i = bodyLength; i >= 0; i--)
            {
                Body.Enqueue(new Pixel(Head.X - i - 1, initialY, _bodyColor));
            }

            Draw();
        }

        /// <summary>
        /// Gets the current head position of the snake.
        /// </summary>
        public Pixel Head { get; private set; }

        /// <summary>
        /// Gets the queue of body segments that make up the snake's body.
        /// </summary>
        public Queue<Pixel> Body { get; } = new Queue<Pixel>();

        /// <summary>
        /// Moves the snake in the specified direction.
        /// </summary>
        /// <param name="direction">The direction to move the snake.</param>
        /// <param name="eat">If true, the snake grows by one segment. If false, maintains current length.</param>
        public void Move(Direction direction, bool eat = false)
        {
            Clear();

            Body.Enqueue(new Pixel(Head.X, Head.Y, _bodyColor));

            if (!eat)
                Body.Dequeue();

            Head = direction switch
            {
                Direction.Right => new Pixel(Head.X + 1, Head.Y, _headColor),
                Direction.Left => new Pixel(Head.X - 1, Head.Y, _headColor),
                Direction.Up => new Pixel(Head.X, Head.Y - 1, _headColor),
                Direction.Down => new Pixel(Head.X, Head.Y + 1, _headColor),
                _ => Head
            };

            Draw();
        }

        /// <summary>
        /// Draws the entire snake (head and body) on the console.
        /// </summary>
        public void Draw()
        {
            Head.Draw();

            foreach (Pixel pixel in Body)
            {
                pixel.Draw();
            }
        }

        /// <summary>
        /// Clears the entire snake (head and body) from the console.
        /// </summary>
        public void Clear()
        {
            Head.Clear();

            foreach (Pixel pixel in Body)
            {
                pixel.Clear();
            }
        }
    }
}
