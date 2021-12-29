using Xunit;
using FluentAssertions;
using MineSweeperSamuel;

namespace MineSweeper.Tests
{
    public class CellTests
    {
        [Fact]
        public void CellContainsAnAsterisk()
        {
            Cell cell = new Cell('*');
            cell.Value.Should().Be('*');
        }
        
        [Fact]
        public void CellContainsADot()
        {
            Cell cell = new Cell('.');
            cell.Value.Should().Be('.');
        }
    }
}