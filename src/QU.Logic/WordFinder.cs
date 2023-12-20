using QU.Core.Contracts;
using QU.Core.Entities;
using QU.Core.Services;

namespace QU.Logic;

public class WordFinder : IWordFinder
{
    private int _maxRanking;
    private IMatrixService _matrixService;
    private IRepository _matrixRepository;
    private Matrix _matrix;
    private IDictionary<string, int> _dataDictionary;

    public WordFinder(
        int maxRanking,
        IEnumerable<string> matrix,
        IMatrixService matrixService, 
        IRepository matrixRepository
    )
    {
        _maxRanking = maxRanking;
        _matrixService = matrixService;
        _matrixRepository = matrixRepository;
        _matrix = _matrixRepository.BuildMatrix(matrix);
        _dataDictionary = new Dictionary<string, int>();
    }

    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        if (wordStream.Count() == 0) return new List<string>();
        wordStream.ToList().ForEach(word => _dataDictionary.Add(word, 0));
        var xDimension = _matrix.XDimension;
        var yDimension = _matrix.YDimension;
        for (var xIndex = 0; xIndex < xDimension; xIndex++)
        {
            for (int yIndex = 0; yIndex < yDimension; yIndex++)
            {
                var wordSet = wordStream.Where(w => w[0] == _matrix[xIndex, yIndex]);
                wordSet = wordSet.Where(w => _matrixService.IsFeasibleByLength(_matrix, xIndex, yIndex, w));
                wordSet.Where(w => _matrixService.IsFoundX(_matrix, xIndex, yIndex, w)).ToList().ForEach(w => _dataDictionary[w]++);
                wordSet.Where(w => _matrixService.IsFoundY(_matrix, xIndex, yIndex, w)).ToList().ForEach(w => _dataDictionary[w]++);
            }
        }
        return GetTopNMostRepeated();
    }

    private IEnumerable<string> GetTopNMostRepeated()
    {
        var result =
            from entry in _dataDictionary
            orderby entry.Value descending
            where entry.Value > 0
            select entry.Key;
        return result.Take(_maxRanking);

    }
}
