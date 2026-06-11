using Microsoft.Extensions.Configuration;
using SimpleConsoleGame.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame.Services;

internal class GetMapService(IConfiguration config) : IGetMapService
{
    public (int width, int height) GetMapSize() =>
        (width: config.GetMapSizeFor("x"), height: config.GetMapSizeFor("y"));
}
