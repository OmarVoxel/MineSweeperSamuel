namespace MineSweeperSamuel
{
    public struct Cell
    {
        public object Value { get; }
        public Cell(char value) => Value = value;
    }
}