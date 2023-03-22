namespace Pong;

public class ConsoleRenderer
{
    private const char Paddle = '|';
    private const char Ball = 'O';

    public readonly int width;
    public readonly int height;

    public Vector Center => new(width / 2, height / 2);

    public ConsoleRenderer()
    {
        Console.Clear();
        Console.Title = "Pong";
        Console.CursorVisible = false;
#pragma warning disable CA1416
        Console.BufferWidth = width = Console.WindowWidth;
        Console.BufferHeight = height = Console.WindowHeight;
#pragma warning restore CA1416
    }

    public void DrawPaddle(Vector position, int paddleHeight)
    {
        for (var i = 0; i < paddleHeight; i++)
        {
            Console.SetCursorPosition(position.x, position.y + i);
            Console.Write(Paddle);
        }
    }

    public void DrawBall(Vector position)
    {
        Console.SetCursorPosition(position.x, position.y);
        Console.Write(Ball);
    }

    public void DrawScore(int player1Score, int player2Score)
    {
        var message = $"{player1Score,2} : {player2Score,2}";
        Console.SetCursorPosition(width / 2 - message.Length / 2, 0);
        Console.Write(message);
    }

    public void Clear() => Console.Clear();
}
