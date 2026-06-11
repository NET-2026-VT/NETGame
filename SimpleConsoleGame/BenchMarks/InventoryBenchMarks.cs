using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame.BenchMarks;

[MemoryDiagnoser]
[ShortRunJob]
[BenchmarkCategory("inventory")]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class InventoryBenchMarks
{
    private LinqBenchMarks _sut = null!;

    /// <summary>Shown as a column in the results table</summary>
    [Params(100, 10_000)]
    public int ItemCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _sut = new LinqBenchMarks(ItemCount);

        for (int i = 0; i < ItemCount; i++)
        {
            if (!_sut.BackPack.Add($"Item{i}"))
                throw new InvalidOperationException($"Backpack full at {i} items (capacity {ItemCount}).");
        }
    }

    [Benchmark(Baseline = true, Description = "for-loop with index + string interpolation")]
    public void ForLoop_Indexed() => _sut.Inventory_ForLoop();

    [Benchmark(Description = "LINQ Select in ordinary foreach")]
    public void Linq_Select_Foreach() => _sut.Inventory_Linq();

    [Benchmark(Description = "LINQ Select + ToList + List.ForEach")]
    public void Linq_Select_ToList_ForEach() => _sut.Inventory_Linq_With_ToList();

    [Benchmark(Description = "LINQ Select + custom IEnumerable.ForEach extension")]
    public void Linq_Select_CustomForEach() => _sut.Inventory_Linq_ForEachExtension();

    [Benchmark(Description = "LimitedsList.ForEach(item, index)")]
    public void LimitedList_ForEach() => _sut.Inventory_Foreach_From_Backpack();
}
