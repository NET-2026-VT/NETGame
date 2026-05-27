internal class Map
{
    private Cell[,] _cells;
    private int _height;
    private int _width;

    public Map(int height, int width)
    {
        _height = height;
        _width = width;

        _cells = new Cell[height, width]; 
    }
}