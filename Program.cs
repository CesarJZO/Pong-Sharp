using Pong;

var game = new Game(new ConsoleRenderer());

game.OnCollision += () => Console.Beep(100, 100);

game.Start();
game.Update();
// Console.ReadKey();
