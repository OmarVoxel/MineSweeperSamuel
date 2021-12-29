using FluentAssertions;
using MineSweeperSamuel;
using Xunit;

namespace MineSweeper.Tests
{
    public class MineSweeperTests
    {
        [Fact]
        public void MatrixIsPrintedWithDefaultMatrix()
        {
            Matrix matrix = new Matrix(3,3);

            MineSweepers mineSweeper = new(matrix);
            mineSweeper.Print().Should().Be("...\n...\n...");
            
        }
        
        public void MineSweeperCanOpen()
        {
            Matrix matrix = new Matrix(3,3);

            MineSweepers mineSweeper = new(matrix);
            mineSweeper.Open(new(1, 1));
            
            mineSweeper.Print().Should().Be("...\n.0.\n...");
        }
        
        [Fact]
        public void MinesSweeperAtOneOneWithTwoMines()
        {
            Matrix matrix = new Matrix(3,3);
            matrix.SetMines(new(0,0));
            matrix.SetMines(new(0,1));

            MineSweepers mineSweeper = new(matrix);
            mineSweeper.Open(new(1, 1));
            
            mineSweeper.Print().Should().Be("...\n.2.\n...");
        }
        
        [Fact]
        public void MineSweeperCantExceedFromBones()
        {
            Matrix matrix = new Matrix(3,3);

            MineSweepers mineSweeper = new(matrix);
            mineSweeper.Open(new(0, 0));
            
            mineSweeper.Print().Should().Be("0..\n...\n...");
        }
        
        [Fact]
        public void MineSweeperWillEndWhenFallsInAnAsterisk()
        {
            Matrix matrix = new Matrix(3,3);

            MineSweepers mineSweeper = new(matrix);
            matrix.SetMines(new(0,0));
            matrix.SetMines(new(1,1));
            
            mineSweeper.Open(new(0, 0));
            
            mineSweeper.HasLose.Should().Be(true);
            mineSweeper.Print().Should().Be("*..\n.*.\n...");
        }

        [Fact]
        public void MineSweeperWillEndWhenFallsInAnAsteriskForTwoAttempts()
        {
            Matrix matrix = new Matrix(3,3);

            MineSweepers mineSweeper = new(matrix);
            matrix.SetMines(new(0,0));
            matrix.SetMines(new(1,1));
            
            mineSweeper.Open(new(1, 0));
            mineSweeper.Open(new(0, 0));
            
            mineSweeper.HasLose.Should().Be(true);
            mineSweeper.Print().Should().Be("*..\n2*.\n...");
        }
        
        [Fact]
        public void MineSweeperWillEndWhenWins()
        {
            Matrix matrix = new Matrix(3,3);

            MineSweepers mineSweeper = new(matrix);
            matrix.SetMines(new(0,1));   
            matrix.SetMines(new(0,2));   
            matrix.SetMines(new(1,0));   
            matrix.SetMines(new(1,1)); 
            matrix.SetMines(new(1,2));  
            matrix.SetMines(new(2,0));  
            matrix.SetMines(new(2,1));          
            matrix.SetMines(new(2,2));
            
            mineSweeper.Open(new(0, 0));
            
            mineSweeper.HasWin.Should().Be(true);
            mineSweeper.Print().Should().Be("3**\n***\n***");
        }
    }
}