internal class Creature
{
    public string Symbol { get; }
    public ConsoleColor Color { get; set; } = ConsoleColor.Green;
    public Cell Cell { get; }
    public Creature(Cell cell, string symbol)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(symbol);
        Cell = cell ?? throw new ArgumentNullException(nameof(cell));
        Symbol = symbol;
    }
}