using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame.Extensions;

//internal static class ConfigurationExtensions
//{
//    public static int GetMapSizeFor(this IConfiguration config, string key)
//    {
//        var section = config.GetSection("game:mapsettings");
//        return int.TryParse(section[key], out int result) ? result : throw new ArgumentException();
//    }
//}

public static class GetMapSizeForWrapper
{
    public static IGetMapSize Implementation { private get; set; } = new GetMapSize();
    public static int GetMapSizeFor(this IConfiguration config, string key)
    {
        return Implementation.GetMapSizeFor(config, key);
    }

}

public interface IGetMapSize
{
    int GetMapSizeFor(IConfiguration config, string key);
}

public class GetMapSize : IGetMapSize
{
    public int GetMapSizeFor(IConfiguration config, string key)
    {
        var section = config.GetSection("game:mapsettings");
        return int.TryParse(section[key], out int result) ? result : throw new ArgumentException();
    }
}



