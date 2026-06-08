using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame.Extensions;

internal static class ConfigurationExtensions
{
    public static int GetMapSizeFor(this IConfiguration config, string key)
    {
        var section = config.GetSection("game:mapsettings");
        return int.TryParse(section[key], out int result) ? result : throw new ArgumentException();
    }
}
