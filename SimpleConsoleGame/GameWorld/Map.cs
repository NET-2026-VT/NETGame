using Microsoft.Extensions.Configuration;
using SimpleConsoleGame.Characters.Enemies;
using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.GameWorld;
using SimpleConsoleGame.Services;
using SimpleConsoleGame.Settings;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

internal class Map : IMap
{
    private Cell[,] _cells;
    public int Height { get; }
    public int Width { get; }

    public List<Creature> Creatures { get; } = [];

   // public Map(IConfiguration config)
    //public Map(IMapSettings settings)
    public Map(IGetMapService service)
    {
        //Height = config.GetMapSizeFor("y");
        //Width = config.GetMapSizeFor("x");
        //Height = settings.Y;
        //Width = settings.X;
        //Height = service.GetMapSize().height;
        //Width =  service.GetMapSize().width;

        (Height, Width) = service.GetMapSize();

        _cells = new Cell[Height, Width];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                _cells[y, x] = new Cell(new Position(y, x));
            }
        }
    }

    //[return: MaybeNull]
    public Cell? GetCell(int y, int x)
    {
        return (y < 0 || y >= Height || x < 0 || x >= Width) ? null : _cells[y, x];
    }

    public Cell? GetCell(Position newPosition)
    {
        return GetCell(newPosition.Y, newPosition.X);
    }

    public IDrawable? CreatureAt(Cell cell)
    {
        return Creatures.FirstOrDefault(c => c.Cell == cell);
    }

    public void Place(Creature creature)
    {
        if(CreatureAt(creature.Cell) is null)
             Creatures.Add(creature);
    }
}