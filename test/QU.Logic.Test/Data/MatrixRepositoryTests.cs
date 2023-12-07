using QU.Logic.Data;

namespace QU.Logic.Test.Data;

public class MatrixRepositoryTests
{
    MatrixRepository _target;

    public MatrixRepositoryTests()
    {
        _target = new MatrixRepository();
    }

    [Fact]
    public void OnHappyPath_Success()
    {
        // Arrange
        var sourceData = new List<string> { "abcoc", "fgwio", "chill", "pqnsd", "uvdxy" };
        var expectedXDimension = 5;

        // Act
        var result = _target.BuildMatrix(sourceData);

        // Assert
        Assert.Equal(result.XDimension, expectedXDimension);
    }
}
