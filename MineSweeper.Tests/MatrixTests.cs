using Xunit;
using FluentAssertions;
using MineSweeperSamuel;

namespace MineSweeper.Tests
{
    public class MatrixTests
    {
        public class CellTests
        {
            [Fact]
            public void MatrixAtZeroZeroContainsADot()
            {
                Matrix matrix = new Matrix(3,3);
                matrix.At((new Coordinate(0, 0))).Value.Should().Be('.');
            }
        }
    }
}