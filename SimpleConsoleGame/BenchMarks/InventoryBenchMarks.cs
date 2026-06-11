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
}
