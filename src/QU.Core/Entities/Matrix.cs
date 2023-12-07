namespace QU.Core.Entities;

public class Matrix
{
    char[,] _data;
    const int MAX_DIMENSION = 64;
    
    public Matrix(char[,] data)
    {
        var xDimension = data.GetLength(0);
        var yDimension = data.GetLength(1);
        if (xDimension > MAX_DIMENSION || yDimension > MAX_DIMENSION)
        {
            throw new ArgumentException("Any dimension should not exceed 64");
        }
        _data = data;
    }

    public int XDimension { get => _data.GetLength(0); }
    public int YDimension { get => _data.GetLength(1); }
}
