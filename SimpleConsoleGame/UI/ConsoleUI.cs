using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.LimitedList;

internal class ConsoleUI : IConsoleUI
{

    private MessageLog<string> _log = new(6);
    private readonly IMap _map;

    public ConsoleUI(IMap map)
    {
       _map  = map;
    }

    public void AddMessage(string message) => _log.Add(message);

    public void PrintLog()
    {
        _log.Print(m => Console.WriteLine(m + new string(' ', Console.WindowWidth - m.Length)));
        // _log.Print(HowToPrint);
    }

    public void Draw()
    {
        for (int y = 0; y < _map.Height; y++)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                Cell? cell = _map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                IDrawable drawable = _map.CreatureAt(cell)
                                        ?? cell.Items.FirstOrDefault() as IDrawable
                                        ?? cell;

                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);
            }
            Console.WriteLine();
        }
        Console.ResetColor();

    }

    public ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;

    public void Clear()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
    }

    public void PrintStats(string stats)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(stats);
        Console.ResetColor();
    }
}