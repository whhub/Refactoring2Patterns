namespace ObjectStructure
{
    internal class SimpleLayout : Layout
    {
        private readonly int _col;
        private readonly int _row;

        public SimpleLayout(int col, int row)
        {
            _col = col;
            _row = row;
            Capacity = _row*_col;
        }

        public override sealed int Capacity { get; protected set; }
    }
}