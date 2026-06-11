using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.LimitedList;

namespace SimpleConsoleGame.BenchMarks;

public class LinqBenchMarks
{
    private MockUI _ui = new();
    public LimitedList<string> BackPack { get; }

    public LinqBenchMarks(int capacity) => BackPack = new LimitedList<string>(capacity);

    public void Inventory_ForLoop()
    {
        for (int i = 0; i < BackPack.Count; i++)
        {
            _ui.AddMessage($"{i + 1}: {BackPack[i]}");
        }
    }

    public void Inventory_Linq()
    {
        foreach (var msg in BackPack.Select((x, i) => $"{i + 1}: {x}"))
        {
            _ui.AddMessage(msg);
        }
    }

    public void Inventory_Linq_With_ToList()
    {
        BackPack
            .Select((x, i) => $"{i + 1}: {x}")
            .ToList()
            .ForEach(_ui.AddMessage);
    }

    public void Inventory_Linq_ForEachExtension()
    {
        BackPack
            .Select((x, i) => $"{i + 1}: {x}")
            .ForEach(_ui.AddMessage);
    }

    public void Inventory_Foreach_From_Backpack()
    {
        BackPack.ForEach((item, index) =>
        _ui.AddMessage($"{index + 1}: {item}"));
    }
}