using FluentAssertions;
using MineSweeperSamuel;
using Xunit;

namespace MineSweeper.Tests
{
    public class MineSweeperTests
    {
        [Fact]
        public void t()
        {
            Matrix matrix = new Matrix(3,3);

            MineSweepers mineSweeper = new(matrix);
            mineSweeper.Print().Should().Be("...\n...\n...");
            
        }
    }
}