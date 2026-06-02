using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame.GameWorld;

internal class Item : IDrawable
{
    private readonly string _name;
    public ConsoleColor Color { get; }
    public string Symbol { get; }

    public Item(string symbol, ConsoleColor color, string name)
    {
        Symbol = symbol;
        Color = color;
        _name = name;
    }

    public override string ToString() => _name;

    public static Item Coin() => new Item("c ", ConsoleColor.Yellow, "coin");
    public static Item Stone() => new Item("s ", ConsoleColor.Gray, "stone");

}
