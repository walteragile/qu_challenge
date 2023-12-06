namespace QU.Core.Entities;

public class Matrix
{
    char[,] _data;

    public Matrix(int xDimension, int yDimension)
    {
        if (xDimension > 64 || yDimension > 64)
        {
            throw new ArgumentException("Any dimension should not exceed 64");
        }
        _data = new char[xDimension, yDimension];        
    }

    public int XDimension { get => _data.GetLength(0); }
    public int YDimension { get => _data.GetLength(1); }
}
