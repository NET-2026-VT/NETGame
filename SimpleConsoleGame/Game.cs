using SimpleConsoleGame;
using SimpleConsoleGame.Characters.Enemies;
using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.GameWorld;

internal class Game
{
    private Map _map = null!;
    private Player _player = null!;
    private readonly ConsoleUI _ui;
    private readonly Dictionary<ConsoleKey, Action> _actionMeny;

    public Game()
    {
        _ui = new ConsoleUI();
        _actionMeny = new Dictionary<ConsoleKey, Action>()
                {
                    { ConsoleKey.P , PickUp },
                    { ConsoleKey.I , Inventory },
                    { ConsoleKey.D , Drop },

                };

    }

    private void Drop()
    {
        Item? item = _player.BackPack.FirstOrDefault();
        if (item != null && _player.BackPack.Remove(item))
        {
            _player.Cell.Items.Add(item);
            _ui.AddMessage($"Player dropped the {item}");
        }
        else
            _ui.AddMessage("Backpack is empty");
    }

    internal void Run()
    {
        Init();
        Play();
    }

    private void Play()
    {
        bool gameInProgress = true;
        do
        {
            //DrawMap
            DrawMap();

            //GetCommand
            GetCommand();
            //Act

            //DrawMap

            //EnemyAction

            //DrawMap


        } while (gameInProgress);
    }

    private void GetCommand()
    {
        ConsoleKey keyPressed = _ui.GetKey();

        switch (keyPressed)
        {
            case ConsoleKey.UpArrow:
                Move(Direction.North);
                break;
            case ConsoleKey.DownArrow:
                Move(Direction.South);
                break;
            case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break;
            case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
                //case ConsoleKey.P:
                //    PickUp();
                //    break;
                //case ConsoleKey.I:
                //    Inventory();
                //    break;

        }

        if (_actionMeny.ContainsKey(keyPressed))
        {
            _actionMeny[keyPressed]?.Invoke();
        }

    }

    private void Inventory()
    {
        for (int i = 0; i < _player.BackPack.Count; i++)
        {
            _ui.AddMessage($"{i + 1}: {_player.BackPack[i]}");
        }

        //_player.BackPack
        //   .Select((x, i) => $"{i + 1}: {x}")
        //   .ToList()
        //   .ForEach(ConsoleUI.AddMessage);


        //_player.BackPack
        //   .Select((x, i) => $"{i + 1}: {x}")
        //   .ForEach(ConsoleUI.AddMessage);

        //foreach (var msg in _player.BackPack.Select((x, i) => $"{i + 1}: {x}"))
        //{
        //    ConsoleUI.AddMessage(msg);
        //}

    }

    private void PickUp()
    {
        if (_player.BackPack.IsFull)
        {
            _ui.AddMessage("Backpack is full");
            return;
        }

        List<Item> items = _player.Cell.Items;
        Item? item = items.FirstOrDefault();

        if (item is null) return;

        if (_player.BackPack.Add(item))
        {
            _ui.AddMessage($"Player pick up the {item}");
            items.Remove(item);
        }
    }

    private void Move(Position movement)
    {
        Position newPosition = _player.Cell.Position + movement;
        //new Position(_player.Cell.Position.Y + movement.Y, _player.Cell.Position.X + movement.X);

        Cell? newCell = _map.GetCell(newPosition);
        if (newCell is not null) _player.Cell = newCell;

    }

    private void DrawMap()
    {
        _ui.Clear();
        _ui.Draw(_map);
        _ui.PrintStats($"Health: {_player.Health}");
        _ui.PrintLog();
    }

    private void Init()
    {
        //ToDo: Read from config
        _map = new Map(height: 15, width: 15);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell!);
        _map.Creatures.Add(_player);

        var r = new Random();

        RCell().Items.Add(Item.Stone());
        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Stone());
        RCell().Items.Add(Item.Coin());

        _map.Place(new Orc(RCell()));
        _map.Place(new Orc(RCell()));
        _map.Place(new Orc(RCell()));
        _map.Place(new Orc(RCell()));
        _map.Place(new Troll(RCell()));
        _map.Place(new Troll(RCell()));
        _map.Place(new Troll(RCell()));
        _map.Place(new Troll(RCell()));
        _map.Place(new Goblin(RCell()));
        _map.Place(new Goblin(RCell()));
        _map.Place(new Goblin(RCell()));
        _map.Place(new Goblin(RCell()));
        _map.Place(new Goblin(RCell()));
 


        Cell RCell()
        {
            var width = r.Next(0, _map.Width);
            var height = r.Next(0, _map.Height);

            Cell? cell = _map.GetCell(height, width);
            ArgumentNullException.ThrowIfNull(cell);

            return cell;
        }
    }
}