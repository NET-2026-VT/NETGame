using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame.Characters.Enemies;

internal class Orc : Creature
{
    public Orc(Cell cell) : base(cell, "O "){}
}
