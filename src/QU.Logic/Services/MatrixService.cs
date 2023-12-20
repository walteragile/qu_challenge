using QU.Core.Entities;
using QU.Core.Services;
using System;

namespace QU.Logic.Services;

public class MatrixService : IMatrixService
{
    public bool IsFeasibleByLength(Matrix matrix, int x, int y, string word)
    {
        return word.Length <= (matrix.XDimension - x)
            || word.Length <= (matrix.YDimension - y);
    }

    public bool IsFoundX(Matrix matrix, int x, int y, string word)
    {
        var found = true;
        var xIndex = x;
        var yIndex = y;
        var posIndex = 0;
        var yLength = matrix.YDimension;
        while (found
            && yIndex < yLength
            && posIndex < word.Length)
        {
            found = matrix[xIndex, yIndex] == word[posIndex];
            posIndex++;
            yIndex++;
        }
        return found;
    }

    public bool IsFoundY(Matrix matrix, int x, int y, string word)
    {
        var found = true;
        var xLength = matrix.XDimension;
        var xIndex = x;
        var yIndex = y;
        var posIndex = 0;
        while (found
            && xIndex < xLength
            && posIndex < word.Length)
        {
            found = matrix[xIndex, yIndex] == word[posIndex];
            posIndex++;
            xIndex++;
        }
        return found;
    }
}
