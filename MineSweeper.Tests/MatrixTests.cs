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
                matrix.At(new Coordinate(0, 0)).Value.Should().Be('.');
            }
            
            [Fact]
            public void MatrixAtZeroZeroContainsAnAsterisk()
            {
                Matrix matrix = new Matrix(3,3);

                matrix.SetMines(new Coordinate(0,0));
                
                matrix.At(new Coordinate(0, 0)).Value.Should().Be('*');
            }

            [Fact]
            public void Matrix1ShouldBeEqualToMatrix2()
            {
                Matrix matrix = new Matrix(3,3);
                Matrix matrix2 = new Matrix(3, 3);
                
                matrix.Should().Be(matrix2);
            }

        }
    }
}