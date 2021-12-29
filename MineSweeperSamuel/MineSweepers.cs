using System.Text;

namespace MineSweeperSamuel
{
    public class MineSweepers
    {
        private readonly Matrix _matrix;

        public MineSweepers(Matrix matrix)
        {
            _matrix = matrix;
        }

        public string Print()
        {
            StringBuilder matrixString = new();

            for (int x = 0; x < _matrix.Width; x++)
            {
                for (int y = 0; y < _matrix.Height; y++)
                {
                    matrixString.Append(_matrix.At(new Coordinate(x,y)).Value);
                }
                matrixString.Append('\n');
            }
            
            return matrixString.Remove(matrixString.Length-1,1).ToString();
        }
    }
}