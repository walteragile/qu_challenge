using QU.Core.Entities;

namespace QU.Core.Services;

public interface IMatrixService
{
    bool IsFeasibleByLength(Matrix matrix, int x, int y, string word);
    bool IsFoundX(Matrix matrix, int x, int y, string word);
    bool IsFoundY(Matrix matrix, int x, int y, string word);
}
