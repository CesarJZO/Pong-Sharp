using Pong;

try
{
    var renderer = new ConsoleRenderer();
    var game = new Game(renderer);
    game.OnCollision += renderer.Beep;
    game.Start();
    game.Update();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
