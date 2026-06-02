using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame.Extensions;

internal static class MapExtensions
{
    public static IDrawable? CreatureAt<T>(this IEnumerable<T> creatures, Cell cell) where T : Creature
    {
        IDrawable? result = null;

        foreach (var creature in creatures)
        {
            if (creature.Cell == cell)
            {
                result = creature;
                break;
            }
        }
        return result;
    }
}
