using Pong;

var renderer = new ConsoleRenderer();
var game = new Game(renderer);

game.OnCollision += GameOnCollision;

game.Start();
game.Update();
// Console.ReadKey();

static async void GameOnCollision()
{
    await Task.Run(Console.Beep);
}
