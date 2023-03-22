using Pong;

internal static class Program
{
    public static void Main()
    {
        var renderer = new ConsoleRenderer();
        var game = new Game(renderer);

        game.OnCollision += renderer.Beep;

        game.Start();
        game.Update();
    }
}
