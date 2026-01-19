using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Console;

namespace SnakeGame
{
    /// <summary>
    /// Main program class for the Snake console game.
    /// Implements classic Snake gameplay with collision detection and scoring.
    /// </summary>
    class Program   
    {
        private const int MapWidth = 30;
        private const int MapHeight = 20;

        private const int ScreenWidth = MapWidth * 3;
        private const int ScreenHeight = MapHeight * 3;

        private const int FrameMs = 200;

        private const ConsoleColor BorderColor = ConsoleColor.Gray;
        private const ConsoleColor WallColor = ConsoleColor.Blue;

        private const ConsoleColor HeadColor = ConsoleColor.Green;
        private const ConsoleColor BodyColor = ConsoleColor.DarkGreen;

        private const ConsoleColor FoodColor = ConsoleColor.Red;

        private static readonly Random randomGenerator = new Random();

        /// <summary>
        /// Entry point of the application. Initializes the console window and starts the game loop.
        /// </summary>
        static void Main()
        {
            try
            {
                SetWindowSize(ScreenWidth, ScreenHeight);
                SetBufferSize(ScreenWidth, ScreenHeight);
                CursorVisible = false;

                while (true)
                {
                    StartGame();
                    SetCursorPosition(ScreenWidth / 2 - 10, ScreenHeight / 2);
                    WriteLine("Press any key to play again or ESC to exit...");
                    
                    if (ReadKey(true).Key == ConsoleKey.Escape)
                        break;
                }
            }
            catch (Exception ex)
            {
                Clear();
                WriteLine($"An error occurred: {ex.Message}");
                WriteLine("Press any key to exit...");
                ReadKey();
            }
        }

        /// <summary>
        /// Starts a new game session. Handles game loop, collision detection, and scoring.
        /// </summary>
        static void StartGame()
        {
            Clear();

            DrawBorder();
            DrawWalls();

            Direction currentMovement = Direction.Right;

            var snake = new Snake(10, 5, HeadColor, BodyColor);

            Pixel food = GenerateFood(snake);
            food.Draw();

            int score = 0;
            int lagMs = 0;

            Stopwatch sw = Stopwatch.StartNew();

            while (true)
            {
                sw.Restart();

                Direction oldMovement = currentMovement;

                // Input handling phase
                while (sw.ElapsedMilliseconds <= FrameMs - lagMs)
                {
                    if (currentMovement == oldMovement)
                    {
                        currentMovement = ReadMovement(currentMovement);
                    }
                }

                sw.Restart();

                // Check if snake ate food
                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(currentMovement, true);

                    food = GenerateFood(snake);
                    food.Draw();

                    score++;

                    Task.Run(() => Beep(1200, 200));
                }
                else
                {
                    snake.Move(currentMovement);
                }

                // Collision detection
                if (snake.Head.X == MapWidth - 1
                    || snake.Head.X == 0
                    || snake.Head.Y == MapHeight - 1
                    || snake.Head.Y == 0
                    || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y)
                    || CheckCollisionWithWalls(snake))
                    break;

                lagMs = (int)sw.ElapsedMilliseconds;
            }

            snake.Clear();
            food.Clear();

            SetCursorPosition(ScreenWidth / 2 - 10, ScreenHeight / 2);
            WriteLine($"Game Over! Final Score: {score}");

            Task.Run(() => Beep(200, 600));
        }

        /// <summary>
        /// Generates a new food pixel at a random location that doesn't overlap with the snake.
        /// </summary>
        /// <param name="snake">The snake to avoid when placing food.</param>
        /// <returns>A new food pixel at a valid location.</returns>
        static Pixel GenerateFood(Snake snake)
        {
            Pixel food;

            do
            {
                food = new Pixel(randomGenerator.Next(1, MapWidth - 2), randomGenerator.Next(1, MapHeight - 2), FoodColor);
            } while (snake.Head.X == food.X && snake.Head.Y == food.Y
                || snake.Body.Any(b => b.X == food.X && b.Y == food.Y));

            return food;
        }


        /// <summary>
        /// Reads player input and returns the new direction, preventing reverse movement.
        /// </summary>
        /// <param name="currentDirection">The current movement direction.</param>
        /// <returns>The new direction based on player input.</returns>
        static Direction ReadMovement(Direction currentDirection)
        {
            if (!KeyAvailable)
                return currentDirection;

            ConsoleKey key = ReadKey(true).Key;

            currentDirection = key switch
            {
                ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
                _ => currentDirection
            };

            return currentDirection;
        }

        /// <summary>
        /// Draws the game border around the play area.
        /// </summary>
        static void DrawBorder()
        {            
            for (int i = 0; i < MapWidth; i++)
            {
                new Pixel(i, 0, BorderColor).Draw();
                new Pixel(i, MapHeight - 1, BorderColor).Draw();
            }

            for (int i = 0; i < MapHeight; i++)
            {
                new Pixel(0, i, BorderColor).Draw();
                new Pixel(MapWidth - 1, i, BorderColor).Draw();
            }
        }

        /// <summary>
        /// Draws obstacles (walls) within the play area to increase difficulty.
        /// </summary>
        static void DrawWalls()
        {
            // Right vertical wall
            for (int i = 2; i < 9; i++)
            {
                new Pixel(MapWidth - 15, MapHeight - i, WallColor).Draw();
            }

            // Left vertical wall
            for (int i = 1; i < 9; i++)
            {
                new Pixel(MapWidth - 15, i, WallColor).Draw();
            }

            // Bottom horizontal wall
            for (int i = 1; i < 13; i++)
            {
                new Pixel(i, MapHeight - 10, WallColor).Draw();
            }

            // Top horizontal wall
            for (int i = 2; i < 13; i++)
            {
                new Pixel(MapWidth - i, MapHeight - 10, WallColor).Draw();
            }
        }

        /// <summary>
        /// Checks if the snake's head has collided with any of the interior walls.
        /// </summary>
        /// <param name="snake">The snake to check for collisions.</param>
        /// <returns>True if the snake has collided with a wall, false otherwise.</returns>
        static bool CheckCollisionWithWalls(Snake snake)
        {
            int headX = snake.Head.X;
            int headY = snake.Head.Y;

            // Check collision with right vertical wall
            for (int i = 2; i < 9; i++)
            {
                if (headX == MapWidth - 15 && headY == MapHeight - i)
                    return true;
            }

            // Check collision with left vertical wall
            for (int i = 1; i < 9; i++)
            {
                if (headX == MapWidth - 15 && headY == i)
                    return true;
            }

            // Check collision with bottom horizontal wall
            for (int i = 1; i < 13; i++)
            {
                if (headX == i && headY == MapHeight - 10)
                    return true;
            }

            // Check collision with top horizontal wall
            for (int i = 2; i < 13; i++)
            {
                if (headX == MapWidth - i && headY == MapHeight - 10)
                    return true;
            }

            return false;
        }
    }
}

