using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame.Extensions;

internal static class MapExtensions
{
    public static IDrawable CreatureAt<T>(this IEnumerable<T> creatures, Cell cell) where T : Creature
    {
        IDrawable result = cell;

        foreach (var creature in creatures)
        {
            if (creature.Cell == result)
            {
                result = creature;
                break;
            }

        }

        return result;
    }
}
