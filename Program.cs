using Pong;

var game = new Game(new ConsoleRenderer());

#pragma warning disable CA1416
game.OnCollision += () => Console.Beep(100, 100);
#pragma warning restore CA1416

game.Start();
game.Update();
// Console.ReadKey();
