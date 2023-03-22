namespace Pong;

public class ConsoleRenderer
{
    private const char Paddle = '|';
    private const char Ball = 'O';

    public readonly int width;
    public readonly int height;

    public ConsoleRenderer()
    {
        Console.Title = "Pong";
        Console.CursorVisible = false;
        width = Console.WindowWidth;
        height = Console.WindowHeight;
    }

    public void DrawPaddle(Vector position, Vector size)
    {
        for (var i = 0; i < size.y; i++)
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
}
