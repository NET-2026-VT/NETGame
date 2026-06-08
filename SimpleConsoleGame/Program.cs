using SimpleConsoleGame;
using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.GameWorld;
using SimpleConsoleGame.LimitedList;


var map = new Map(15, 15);
var ui = new ConsoleUI(map);
var game = new Game(ui, map);

game.Run();

Console.WriteLine("Game Over");