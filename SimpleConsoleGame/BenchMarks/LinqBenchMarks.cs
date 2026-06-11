using SimpleConsoleGame.LimitedList;

namespace SimpleConsoleGame.BenchMarks;

public class LinqBenchMarks
{
    private MockUI _ui = new();
    public LimitedList<string> BackPack { get; }

    public LinqBenchMarks(int capacity) => BackPack = new LimitedList<string>(capacity);
}