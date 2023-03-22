# Pong algorithm

1. Initialize variables
    - Ball `x`, `y` position at center of screen
    - Ball `x`, `y` velocity random or fixed
    - Player 1 and 2 position (`y` at center of screen, `x` at edge of screen)
    - Players' `score`
2. Setup console
    - Set cursor invisible
    - Set console `size`: buffer `width` and `height` equal to window `width` and `height`
    - Use variables to draw initial game state
        - Draw paddles
        - Draw ball
        - Draw score
3. Loop
    - Move ball `position` by current `velocity`
    - Check if ball collides with top or bottom of screen (ball `y` is equal to `0` or `height - 1`), if so, reverse `y velocity`
    - Check for collision with paddles (paddle position `x ± 1` and ball y within paddle `height`), if so, reverse `x velocity`
    - Check if ball is out of bounds (ball `x` is equal to `0` or `width - 1`), if so, increment `score` for player 1 or 2 respectively and reset ball `position` and `velocity`
    - Move player 1 paddle based on user input (if up arrow is pressed, move paddle up, if down arrow is pressed, move paddle down)
    - Move computer-controlled paddle towards ball (if ball `y` is greater than paddle `y`, move paddle down, if less, move paddle up)
    - Draw game 
        - Clear screen
        - Draw everything
    - Check for game over (`score` is equal to 10), if so, write game over `message` at center of screen and exit loop
    - Sleep for 16 milliseconds (60 FPS)

## Functions

- `DrawPaddle(x: int, y: int)`
    1. Set cursor position to x, y
    1. Write paddle character
    1. Repeat until paddle height is reached
- `DrawBall(x: int, y: int)`
    1. Set cursor position to x, y
    1. Write ball character
- `DrawScore(player1: int, player2: int)`
    1. Set cursor position to top center of screen
    1. Offset left or right for player 1 or 2 respectively
    1. Write score

# Chat-GPT example

```csharp
using Pong;

internal abstract class Program
{
    static void Main(string[] args)
    {
    }
    private static void End()
    {
        // Game variables
        int ballX = Console.WindowWidth / 2;
        int ballY = Console.WindowHeight / 2;
        int ballDirX = -1;
        int ballDirY = -1;
        int player1X = 1;
        int player1Y = Console.WindowHeight / 2 - 3;
        int player2X = Console.WindowWidth - 2;
        int player2Y = Console.WindowHeight / 2 - 3;
        int player1Score = 0;
        int player2Score = 0;

        // Set up console
        Console.CursorVisible = false;
        Console.WindowHeight = 30;
        Console.WindowWidth = 60;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;

        // Draw initial game state
        DrawPaddle(player1X, player1Y);
        DrawPaddle(player2X, player2Y);
        DrawBall(ballX, ballY);
        DrawScore(player1Score, player2Score);

        // Game loop
        while (true)
        {
            // Move ball
            ballX += ballDirX;
            ballY += ballDirY;

            // Check for collision with top or bottom of screen
            if (ballY == 0 || ballY == Console.WindowHeight - 1)
            {
                ballDirY = -ballDirY;
            }

            // Check for collision with left paddle
            if (ballX == player1X + 1 && ballY >= player1Y && ballY < player1Y + 6)
            {
                ballDirX = 1;
            }

            // Check for collision with right paddle
            if (ballX == player2X - 1 && ballY >= player2Y && ballY < player2Y + 6)
            {
                ballDirX = -1;
            }

            // Check for ball going out of bounds
            if (ballX < 0 || ballX >= Console.WindowWidth)
            {
                if (ballX < 0)
                {
                    player2Score++;
                }
                else
                {
                    player1Score++;
                }

                ballX = Console.WindowWidth / 2;
                ballY = Console.WindowHeight / 2;
                ballDirX = -ballDirX;
            }

            // Move computer-controlled paddle
            if (ballDirX == 1 && player2Y + 3 < ballY)
            {
                player2Y++;
            }
            else if (ballDirX == 1 && player2Y + 3 > ballY)
            {
                player2Y--;
            }

            // Draw game state
            Console.Clear();
            DrawPaddle(player1X, player1Y);
            DrawPaddle(player2X, player2Y);
            DrawBall(ballX, ballY);
            DrawScore(player1Score, player2Score);

            // Check for game over
            if (player1Score == 10 || player2Score == 10)
            {
                Console.Clear();
                Console.WriteLine("Game over!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            // Wait for next frame
            Thread.Sleep(50);
        }
    }

    static void DrawPaddle(int x, int y)
    {
        for (int i = 0; i < 6; i++)
        {
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("|");
            }
        }
    }

    static void DrawBall(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write("O");
    }

    static void DrawScore(int player1Score, int player2Score)
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
        Console.Write(player1Score);
        Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 0);
        Console.Write(player2Score);
    }
}
```
