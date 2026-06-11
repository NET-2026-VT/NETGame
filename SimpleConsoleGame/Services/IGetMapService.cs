namespace SimpleConsoleGame.Services;

internal interface IGetMapService
{
    (int width, int height) GetMapSize();
}