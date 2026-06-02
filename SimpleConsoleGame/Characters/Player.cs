using SimpleConsoleGame.GameWorld;
using SimpleConsoleGame.LimitedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame
{
    internal class Player : Creature
    {
        public LimitedList<Item> BackPack { get; }
        public Player(Cell cell) : base(cell, "P ")
        {
            Color = ConsoleColor.White;
            BackPack = new LimitedList<Item>(3);
        }
    }
}
