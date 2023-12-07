using QU.Core.Entities;

namespace QU.Core.Services;

public interface IMatrixService
{
    bool IsFeasibleByLength(Matrix matrix, int x, int y, string word);
    bool IsFound(Matrix matrix, int x, int y, string word);
}
