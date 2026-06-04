using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleConsoleGame.Characters.Enemies;

internal class Goblin : Creature
{
    public Goblin(Cell cell) : base(cell, "G ", 20)
    {
        Color = ConsoleColor.DarkBlue;
        Damage = 60;
    }
}


