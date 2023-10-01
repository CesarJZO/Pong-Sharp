namespace Pong;

public class ConsoleRenderer
{
    private const char Paddle = '|';
    private const char Ball = 'O';

    public readonly int top;
    public readonly int left;
    public readonly int width;
    public readonly int height;

    public Vector Center => new(width / 2, height / 2);

    public ConsoleRenderer()
    {
        if (Console.WindowHeight < 8 || Console.WindowWidth < 40)
            throw new Exception("Not enough space in terminal");

        Console.Clear();

        Console.Title = "Pong";
        Console.CursorVisible = false;

        top = Console.WindowTop;
        left = Console.WindowLeft;

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
        var message = $"{player1Score} : {player2Score}";
        Console.SetCursorPosition(width / 2 - message.Length / 2, 0);
        Console.Write(message);
    }

    public void DrawGameOver(int player1Score, int player2Score)
    {
        var winPlayer = player1Score == 10 ? "Player 1" : "Player 2";
        var message = $"Game Over! {winPlayer} won";
        Console.SetCursorPosition(width / 2 - message.Length / 2, height / 2);
        Console.Write(message);
        message = "Press any key to exit";
        Console.SetCursorPosition(width / 2 - message.Length / 2, height / 2 + 1);
        Console.Write(message);
        Console.ReadKey();
        Console.Clear();
    }

    public void Clear() => Console.Clear();

    public async void Beep() => await Task.Run(Console.Beep);
}
