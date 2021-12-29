﻿namespace MineSweeperSamuel
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
    }
}