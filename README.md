# Console Snake Game

<div align="center">

![.NET](https://img.shields.io/badge/.NET-6.0-blue)
![C#](https://img.shields.io/badge/C%23-10.0-purple)
![License](https://img.shields.io/badge/license-MIT-green)

A classic Snake game implementation in C# that runs entirely in the console. Built with clean code principles, comprehensive XML documentation, and unit tests.

[Features](#features) • [Getting Started](#getting-started) • [How to Play](#how-to-play) • [Architecture](#architecture) • [Testing](#testing)

</div>

---

## Features

- **Classic Gameplay**: Navigate the snake to collect food and grow longer
- **Collision Detection**: Realistic collision with walls, obstacles, and self
- **Score Tracking**: Track your performance with real-time scoring
- **Obstacle System**: Interior walls add challenge and variety
- **Smooth Controls**: Responsive arrow key input with movement buffering
- **Visual Feedback**: Color-coded game elements and audio cues
- **Error Handling**: Robust exception handling for stable gameplay

## Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or higher
- A terminal/console that supports ANSI colors
- Windows, macOS, or Linux operating system

### Installation

1. Clone the repository:
```bash
git clone https://github.com/your-username/console-snake-game.git
cd console-snake-game
```

2. Build the project:
```bash
dotnet build
```

3. Run the game:
```bash
dotnet run --project "Snake Game"
```

## How to Play

### Controls

| Key | Action |
|-----|--------|
| **↑ Arrow** | Move Up |
| **↓ Arrow** | Move Down |
| **← Arrow** | Move Left |
| **→ Arrow** | Move Right |
| **ESC** | Exit Game |

### Rules

1. Control the snake using arrow keys
2. Eat the red food items to grow longer and increase your score
3. Avoid hitting:
   - The border walls (gray)
   - Interior obstacles (blue)
   - Your own body
4. Try to achieve the highest score possible!

### Gameplay Tips

- Plan your path ahead to avoid trapping yourself
- Use the interior walls strategically
- The snake moves continuously, so react quickly!

## Architecture

### Project Structure

```
console-snake-game/
├── Snake Game/               # Main game project
│   ├── Program.cs           # Entry point and game loop
│   ├── Snake.cs             # Snake entity and movement logic
│   ├── Pixel.cs             # Rendering primitive
│   ├── Direction.cs         # Movement direction enum
│   └── Snake Game.csproj    # Project configuration
├── Snake Game.Tests/         # Unit test project
│   ├── SnakeTests.cs        # Snake class tests
│   ├── PixelTests.cs        # Pixel struct tests
│   └── DirectionTests.cs    # Direction enum tests
├── .gitignore               # Git ignore rules
├── README.md                # Project documentation
└── Snake Game.sln           # Solution file
```

### Design Highlights

- **Immutable Value Types**: `Pixel` is a readonly struct for performance and safety
- **Separation of Concerns**: Game logic, rendering, and input handling are decoupled
- **Modern C# Features**: Pattern matching, switch expressions, nullable reference types
- **Comprehensive Documentation**: XML documentation on all public APIs
- **Test Coverage**: Unit tests for core game components

### Key Classes

#### `Snake`
Manages the snake entity, including head position, body segments, movement, and collision detection.

#### `Pixel`
An immutable value type representing a single drawable unit on the console screen with position, color, and size.

#### `Direction`
Enum defining the four possible movement directions with clear semantics.

## Testing

The project includes a comprehensive test suite using xUnit.

### Running Tests

```bash
# Run all tests
dotnet test

# Run with detailed output
dotnet test --logger "console;verbosity=detailed"

# Generate code coverage report
dotnet test /p:CollectCoverage=true
```

### Test Coverage

- **PixelTests**: Constructor validation and property tests
- **SnakeTests**: Movement logic, growth mechanics, and state management
- **DirectionTests**: Enum validation and completeness checks

## Code Quality

This project demonstrates:

- ✅ Clean, readable code with meaningful names
- ✅ Comprehensive XML documentation
- ✅ Unit test coverage for core components
- ✅ Modern C# language features and idioms
- ✅ Proper error handling and validation
- ✅ SOLID principles and design patterns
- ✅ Version control best practices

## Future Enhancements

Potential improvements for future versions:

- [ ] Difficulty levels (speed adjustment)
- [ ] High score persistence
- [ ] Multiple snake skins/themes
- [ ] Power-ups and special items
- [ ] Multiplayer mode
- [ ] Custom map editor
- [ ] Leaderboard system

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

**Eduard Pascale**

- Demonstrated skills: C#, .NET, Object-Oriented Programming, Unit Testing, Game Development
- GitHub: [@your-username](https://github.com/your-username)

## Acknowledgments

- Inspired by the classic Snake game
- Built as a demonstration of C# and software engineering best practices

---

<div align="center">

**⭐ Star this repository if you found it helpful!**

</div>
