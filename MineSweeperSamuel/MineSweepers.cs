using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MineSweeperSamuel
{
    public class MineSweepers
    {
        private readonly Matrix _matrix;
        

        public MineSweepers(Matrix matrix)
        {
            _matrix = matrix;
        }

        public bool HasLose { get; private set; }
        public bool HasWin { get; private set; }

        public string Print()
        {
            StringBuilder matrixString = new();
            
            for (int x = 0; x < _matrix.Width; x++)
            {
                for (int y = 0; y < _matrix.Height; y++)
                {
                    if (HasWin)
                    {
                        matrixString.Append(_matrix.At(new Coordinate(x,y)).Value);
                    }
                    else
                    {
                        if (_matrix.At(new(x, y)).Value == '*' && !HasLose)
                            matrixString.Append('.');
                        else
                            matrixString.Append(_matrix.At(new Coordinate(x,y)).Value);
                    }
                }
                matrixString.Append('\n');
            }
            
            return matrixString.Remove(matrixString.Length-1,1).ToString();
        }

        public void Open(Coordinate coord)
        {
            if (_matrix.At((coord)).Value == '*')
            {
                HasLose = true;
            }
            else
            {
                int countNeighbors = CountNeighbors(coord);
                _matrix.ChangeValue(coord, countNeighbors);
                HasWin = HasWinner();
            }
        }

        private bool HasWinner()
        {
            return _matrix.CountDots() <= 0;
        }
        
        private int CountNeighbors(Coordinate coord)
        {
            List<Coordinate> coordinates = new List<Coordinate>()
            {
                new Coordinate(coord.X -1 , coord.Y -1),
                new Coordinate(coord.X, coord.Y -1 ),
                new Coordinate(coord.X+1, coord.Y-1),
                new Coordinate(coord.X+1, coord.Y),
                new Coordinate(coord.X +1, coord.Y +1),
                new Coordinate(coord.X, coord.Y + 1),
                new Coordinate(coord.X -1 , coord.Y +1),
                new Coordinate(coord.X -1, coord.Y)
            };

            return coordinates.Count(coord 
                => IsValid(coord) && _matrix.At(coord).Value == '*');
        }

        private bool IsValid(Coordinate coord)
            => 0 <= coord.X && coord.X < _matrix.Width && 
               0 <= coord.Y && coord.Y <_matrix.Height;
    }
}