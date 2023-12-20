using QU.Core.Entities;
using QU.Core.Services;
using QU.Logic.Services;

namespace QU.Logic.Test.Services;

public class MatrixServiceTests
{
    IMatrixService _target;

    public MatrixServiceTests()
    {
        _target = new MatrixService();
    }

    [Fact]
    public void OnFeasible_ReturnsTrue()
    {
        // Arrange
        var data = new char[,] {
            { 'a', 'b', 'c' },
            { 'd', 'e', 'f' },
            { 'd', 't', 'f' }
        };
        var matrix = new Matrix(data);
        var word = "bet";
        var x = 0;
        var y = 1;

        // Act
        var result = _target.IsFeasibleByLength(matrix, x, y, word);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void OnImpossible_ReturnsFalse()
    {
        // Arrange
        var data = new char[,] {
            { 'a', 'b', 'c' },
            { 'd', 'e', 'f' },
            { 'd', 't', 'f' }
        };
        var matrix = new Matrix(data);
        var word = "bet";
        var x = 1;
        var y = 1;

        // Act
        var result = _target.IsFeasibleByLength(matrix, x, y, word);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void OnFeasibleXButImpossibleY_ReturnsTrue()
    {
        // Arrange
        var data = new char[,] {
            { 'a', 'b', 'c' },
            { 'b', 'e', 't' },
            { 'd', 't', 'f' }
        };
        var matrix = new Matrix(data);
        var word = "bet";
        var x = 1;
        var y = 0;

        // Act
        var result = _target.IsFeasibleByLength(matrix, x, y, word);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsHorizontal_ReturnsTrue()
    {
        // Arrange
        var data = new char[,] {
            { 'a', 'b', 'c' },
            { 'b', 'e', 't' },
            { 'd', 'q', 'f' }
        };
        var matrix = new Matrix(data);
        var word = "bet";
        var x = 1;
        var y = 0;

        // Act
        var result = _target.IsFoundX(matrix, x, y, word);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsVertical_ReturnsTrue()
    {
        // Arrange
        var data = new char[,] {
            { 'a', 'b', 'c' },
            { 'b', 'e', 'x' },
            { 'd', 't', 'f' }
        };
        var matrix = new Matrix(data);
        var word = "bet";
        var x = 0;
        var y = 1;

        // Act
        var result = _target.IsFoundY(matrix, x, y, word);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotFound_ReturnsFalse()
    {
        // Arrange
        var data = new char[,] {
            { 'a', 'b', 'c' },
            { 'b', 'e', 'x' },
            { 'd', 'z', 'f' }
        };
        var matrix = new Matrix(data);
        var word = "bet";
        var x = 0;
        var y = 1;

        // Act
        var result = _target.IsFoundX(matrix, x, y, word);
        if (!result )
        {
            result = _target.IsFoundY(matrix, x, y, word);
        }

        // Assert
        Assert.False(result);
    }
}
