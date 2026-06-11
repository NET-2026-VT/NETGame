using System.Runtime.CompilerServices;

namespace SimpleConsoleGame.Services;
//[assembly(InternalsVisebleTo(""))]

internal interface IGetMapService
{
    (int width, int height) GetMapSize();
}