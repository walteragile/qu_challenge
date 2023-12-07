using QU.Core.Entities;

namespace QU.Core.Test.Entities;

public class MatrixTests
{
    Matrix _target;

    public MatrixTests()
    {
        var basicMatrix = new char[2, 2];
        _target = new Matrix(basicMatrix);
    }

    [Fact]
    public void OnInvalidDimensions_ThrowsAnException()
    {
        // Arrange
        var overflowDimension = 65;
        var data = new char[1, overflowDimension];

        Assert.Throws<ArgumentException>(() => _target = new Matrix(data));
    }

    [Fact]
    public void OnValidData_Success()
    {
        // Arrange
        var data = new char[,] {
            { 'a', 'b', 'c' },
            { 'd', 'e', 'f' }
        };
        var expectedXDimension = 2;

        // Act
        var result = new Matrix(data);

        // Assert
        Assert.Equal(expectedXDimension, result.XDimension);
    }
}
