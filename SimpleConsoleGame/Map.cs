using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

internal class Map
{
    private Cell[,] _cells;
    public int Height { get; }
    public int Width { get;}

    public Map(int height, int width)
    {
        Height = height;
        Width = width;

        _cells = new Cell[height, width]; 
    }

    //[return: MaybeNull]
    internal Cell? GetCell(int y, int x)
    {
        try
        {
            return _cells[y, x]; 
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message); 
            return null; 
        }
    }
}