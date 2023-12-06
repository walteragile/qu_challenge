using QU.Core.Entities;

namespace QU.Core.Test.Entities;

public class MatrixTests
{
    Matrix _target;

    [Fact]
    public void OnInvalidDimensions_ThrowsAnException()
    {
        // Arrange
        var dimension = 65;

        Assert.Throws<ArgumentException>(() => _target = new Matrix(dimension, dimension));
    }
}
