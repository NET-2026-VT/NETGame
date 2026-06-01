using SimpleConsoleGame.LimitedList;

var li = new List<int>();
var creatureList = new List<Creature>();

var ll = new LimitedList<int>(2);
var ll2 = new LimitedList<Game>(4);


var game = new Game();

game.Run(); 