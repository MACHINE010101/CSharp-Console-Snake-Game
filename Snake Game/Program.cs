using System;
using System.Threading;
using System.Diagnostics;
using static System.Console;

namespace SnakeGame
{
    class Program   
    {
        private const int MapWidth = 30;
        private const int MapHeight = 20;

        private const int ScreenWidth = MapWidth * 3;
        private const int ScreenHeight = MapHeight * 3;

        private const int FramsMs = 200;

        private const ConsoleColor BorderColor = ConsoleColor.Gray;

        private const ConsoleColor HeadColor = ConsoleColor.Green;
        private const ConsoleColor BodyColor = ConsoleColor.DarkGreen;

        private const ConsoleColor FoodColor = ConsoleColor.Red;

        private static readonly Random randomGenerator = new Random();
        static void Main()
        {
            SetWindowSize(ScreenWidth, ScreenHeight);
            SetBufferSize(ScreenWidth, ScreenHeight);
            CursorVisible = false;

            while(true)
            {
                //StartGame();
                Thread.Sleep(100);
                ReadKey();
            }           
        }

        //static void StartGame()
        //{
        //    Clear();

        //    DrawBorder();
        //    DarwWalls();

        //    Direction currentMovement = Direction.Right;

        //    var snake = new Snake(10, 5, HeadColor, BodyColor);

        //    Pixel food = GenFood(snake);
        //    food.Draw();

        //    int score = 0;

        //    int lagMs = 0;

        //    Stopwatch sw = Stopwatch.StartNew();

        //    while (true)
        //    {
        //        sw.Restart();

        //        Direction oldMovement = currentMovement;

        //        while (sw.ElapsedMilliseconds <= FramsMs - lagMs)
        //        {
        //            if (currentMovement == oldMovement)
        //            {
        //                currentMovement = ReadMovement(currentMovement);
        //            }
        //        }

        //        sw.Restart();



        //        if(snake.Head.X == food.X && snake.Head.Y == food.Y)
        //        {
        //            snake.Move(currentMovement, true);

        //            food = GenFood(snake);
        //            food.Draw();

        //            score++;

        //            Task.Run(() => Beep(1200, 200));
        //        }
        //        else
        //        {
        //            snake.Move(currentMovement);
        //        }

                

        //        if (snake.Head.X == MapWidth - 1
        //            || snake.Head.X == 0
        //            || snake.Head.Y == MapHeight - 1
        //            || snake.Head.Y == 0
        //            || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y)
        //            || CheckColisionMidWalls(snake))
        //            break;

        //         lagMs = (int)sw.ElapsedMilliseconds;
        //    }

        //    snake.Clear();
        //    food.Clear();


        //    SetCursorPosition(40, 30);
        //    WriteLine($"Game Over, score {score}");

        //    Task.Run(() => Beep(200, 600));

            
        //}

        //static Pixel GenFood(Snake snake)
        //{
        //    Pixel food;

        //    do
        //    {
        //        food = new Pixel(randomGenerator.Next(1, MapWidth - 2), randomGenerator.Next(1, MapHeight - 2), FoodColor);
        //    }while (snake.Head.X == food.X && snake.Head.Y == food.Y
        //        || snake.Body.Any(b => b.X == food.X && b.Y == food.Y));

        //    return food;
        //}   


        //static Direction ReadMovement(Direction currentDirection)
        //{
        //    if (!KeyAvailable)
        //        return currentDirection;

        //    ConsoleKey key = ReadKey(true).Key;

        //    currentDirection = key switch
        //    {
        //        ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
        //        ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
        //        ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
        //        ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
        //        _ => currentDirection
        //    };

        //    return currentDirection;
        //}

        //static void DrawBorder()
        //{            
        //    for(int i = 0; i < MapWidth; i++)
        //    {
        //        new Pixel(i, 0, BorderColor).Draw();
        //        new Pixel(i, MapHeight - 1, BorderColor).Draw();
        //    }

        //    for (int i = 0; i < MapHeight; i++)
        //    {
        //        new Pixel(0, i, BorderColor).Draw();
        //        new Pixel(MapWidth - 1, i, BorderColor).Draw();
        //    }
        //}

        //static void DarwWalls()
        //{
        //    for (int i = 2; i < 9; i++)
        //    {
        //        new Pixel(MapWidth - 15, MapHeight - i, ConsoleColor.Blue).Draw();
        //    }

        //    for (int i = 1; i < 9; i++)
        //    {
        //        new Pixel(MapWidth - 15, i, ConsoleColor.Blue).Draw();
        //    }

        //    for (int i = 1; i < 13; i++)
        //    {
        //        new Pixel(i, MapHeight - 10, ConsoleColor.Blue).Draw();
        //    }

        //    for (int i = 2; i < 13; i++)
        //    {
        //        new Pixel(MapWidth - i, MapHeight - 10, ConsoleColor.Blue).Draw();
        //    }
        //}

        //static private bool CheckColisionMidWalls(Snake snake)
        //{
        //    for (int i = 2; i < 9; i++)
        //    {
        //        if (snake.Head.X == MapWidth - 15 || snake.Head.Y == MapHeight - i)
        //            return false;
        //    }

        //    for (int i = 1; i < 9; i++)
        //    {
        //        if (snake.Head.X == MapWidth - 15 || snake.Head.Y == i)
        //            return false;
        //    }

        //    for (int i = 1; i < 13; i++)
        //    {
        //        if(snake.Head.X == i || snake.Head.Y == MapHeight - 10)
        //            return false;
        //    }

        //    for (int i = 2; i < 13; i++)
        //    {
        //        if (snake.Head.X == MapWidth - i || snake.Head.Y == MapHeight - 10)
        //            return false;
        //    }

        //    return true;
        //}

        public void Functie()
        {
            Snake sarpelemeu1 = new Snake(ConsoleColor.DarkBlue, ConsoleColor.DarkCyan);
        }
    }
}

