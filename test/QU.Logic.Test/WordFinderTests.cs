using Moq;
using QU.Core.Contracts;
using QU.Core.Entities;
using QU.Core.Services;

namespace QU.Logic.Test;

public class WordFinderTests
{
    private Mock<IMatrixService> _matrixServiceMock;
    private Mock<IRepository> _matrixRepositoryMock;
    IWordFinder _target;

    const int MAX_RANKING = 2;
    private IEnumerable<string> _matrixAsList;

    public WordFinderTests()
    {
        _matrixServiceMock = new Mock<IMatrixService>();
        _matrixRepositoryMock = new Mock<IRepository>();
    }

    [Fact]
    public void OnFindEmpty_ReturnsEmptyList()
    {
        // Arrange
        _matrixAsList = new List<string>() { "abcdc" };
        _target = new WordFinder(
            MAX_RANKING, _matrixAsList, _matrixServiceMock.Object, _matrixRepositoryMock.Object);

        // Act 
        var result = _target.Find(new List<string>());

        // Assert
        Assert.True(result.Count() == 0);
    }

    [Fact]
    public void OnFindOne_ReturnsOne()
    {
        // Arrange
        _matrixAsList = new List<string>() { "abcdc", "chill" };
        var wordStream = new List<string>() { "chill" };
        var _matrix = new Matrix(new char[,] {
            { 'a', 'b', 'c', 'd', 'c' },
            { 'c', 'h', 'i', 'l', 'l' }
        });
        _matrixRepositoryMock.Setup(x => x.BuildMatrix(_matrixAsList))
            .Returns(_matrix);
        _matrixServiceMock.Setup(y => y.IsFeasibleByLength(_matrix, 1, 0, "chill"))
            .Returns(true);
        _matrixServiceMock.Setup(y => y.IsFoundX(_matrix, 1, 0, "chill"))
            .Returns(true);
        _target = new WordFinder(
            MAX_RANKING, _matrixAsList, _matrixServiceMock.Object, _matrixRepositoryMock.Object);

        // Act 
        var result = _target.Find(wordStream);

        // Assert
        Assert.True(result.Count() == 1);
    }

    [Fact]
    public void OnSameWordHorizontalVertical_ReturnsWordFirstPlace()
    {
        // Arrange
        _matrixAsList = new List<string>() { "abbad", "chill", "hhbxd", "ihbxd" };
        var wordStream = new List<string>() { "chi", "bad" };
        var _matrix = new Matrix(new char[,] {
            { 'a', 'b', 'b', 'a', 'd' },
            { 'c', 'h', 'i', 'l', 'l' },
            { 'h', 'h', 'b', 'x', 'd' },
            { 'i', 'h', 'b', 'x', 'd' }
        });
        _matrixRepositoryMock.Setup(x => x.BuildMatrix(_matrixAsList))
            .Returns(_matrix);
        _matrixServiceMock.Setup(y => y.IsFeasibleByLength(_matrix, 1, 0, "chi"))
            .Returns(true);
        _matrixServiceMock.Setup(y => y.IsFeasibleByLength(_matrix, 0, 2, "bad"))
            .Returns(true);
        _matrixServiceMock.Setup(y => y.IsFoundX(_matrix, 0, 2, "bad"))
            .Returns(true);
        _matrixServiceMock.Setup(y => y.IsFoundX(_matrix, 1, 0, "chi"))
            .Returns(true);
        _matrixServiceMock.Setup(y => y.IsFoundY(_matrix, 1, 0, "chi"))
            .Returns(true);
        _target = new WordFinder(
            MAX_RANKING, _matrixAsList, _matrixServiceMock.Object, _matrixRepositoryMock.Object);

        // Act 
        var result = _target.Find(wordStream).ToList();

        // Assert
        Assert.True(result[0] == "chi");
    }
}
