using QU.Core.Entities;
using QU.Core.Contracts;

namespace QU.Logic.Data;

public class MatrixRepository : IRepository
{
    public Matrix BuildMatrix(IEnumerable<string> sourceData)
    {
        var dataList = sourceData.ToList();
        var xDimension = dataList.Count;
        var yDimension = dataList[0].Length;
        var data = new char[xDimension,yDimension];
        for (var xIndex = 0; xIndex < xDimension; xIndex++)
        {
            for (int yIndex = 0; yIndex < yDimension; yIndex++)
            {
                data[xIndex, yIndex] = dataList[xIndex][yIndex];
            }
        }
        return new Matrix(data);
    }
}
