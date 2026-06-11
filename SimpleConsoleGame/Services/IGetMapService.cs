using System.Runtime.CompilerServices;

//Correct syntax...
//[assembly: InternalsVisibleTo("SimpleConsoleGame.Tests")]

namespace SimpleConsoleGame.Services;

internal interface IGetMapService
{
    (int width, int height) GetMapSize();
}