using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleConsoleGame.Characters.Enemies;

internal class Troll : Creature
{
    public Troll(Cell cell) : base(cell, "T ", 60)
    {
        Color = ConsoleColor.DarkCyan;
        Damage = 45;
    }
}
