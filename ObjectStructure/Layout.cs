namespace ObjectStructure
{
    internal class Layout
    {
        public int Row { get; protected set; }
        public int Col { get; protected set; }
    }

    internal class LeafLayout : Layout
    {
        public LeafLayout(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }

    internal class NestLayout : Layout
    {
        public NestLayout(int row, int col)
        {
        }
    }
}