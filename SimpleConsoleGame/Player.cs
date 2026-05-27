using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame
{
    internal class Player : Creature
    {
        public Player(Cell cell) : base(cell, "P ")
        {
            Color = ConsoleColor.White; 
        }
    }
}
