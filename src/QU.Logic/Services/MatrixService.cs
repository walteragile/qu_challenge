using QU.Core.Entities;
using QU.Core.Services;

namespace QU.Logic.Services;

public class MatrixService : IMatrixService
{
    public bool IsFeasibleByLength(Matrix matrix, int x, int y, string word)
    {
        return word.Length <= (matrix.XDimension - x)
            || word.Length <= (matrix.YDimension - y);
    }

    public bool IsFound(Matrix matrix, int x, int y, string word)
    {
        return matrix.IsFound(x, y, word);
    }
}
