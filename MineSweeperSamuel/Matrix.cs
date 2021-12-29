using System.Linq;

namespace MineSweeperSamuel
{
    public struct Coordinate
    {
        public int X;
        public int Y;
        public Coordinate(int x, int y)
            => (X, Y) = (x, y);
    }

    public class Matrix
    {
        public int Width { get; }
        public int Height { get; }
        private Cell[,] _matrix;

        public Matrix(int width, int height)
        {
            (Width, Height) = (width, height);
            _matrix = new Cell[Width, Height];

            Initialize();
        }

        private void Initialize()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Width; y++)
                    _matrix[x, y] = new Cell('.');
        }
        
        public Cell At(Coordinate coordinate) 
            => _matrix[coordinate.X, coordinate.Y];

        public void SetMines(Coordinate coordinate) 
            => _matrix[coordinate.X, coordinate.Y] = new Cell('*');
        
        public override bool Equals(object other) 
            => CellAsString().Equals((other as Matrix)?.CellAsString());
        private string CellAsString() 
            => string.Concat(_matrix.OfType<Cell>().Select(c => c.Value));
        public override int GetHashCode()
            => CellAsString().GetHashCode();
        public void ChangeValue(Coordinate coord, int countNeighbors) 
            => _matrix[coord.X, coord.Y] = new Cell(char.Parse(countNeighbors.ToString()));

        public int CountDots()
        {
            return _matrix.OfType<Cell>().Count(x => x.Value == '.');
        }
    }
}