using System;
using System.Collections.Generic;

namespace ObjectStructure
{
    internal class Card
    {
        private IList<Cell> _cells = new List<Cell>();
        private bool _ifRepack;
        private IList<Page> _pages = new List<Page>();
        private IList<Segment> _segments = new List<Segment>();

        public void InsertCells(IEnumerable<Cell> cells, int pageIndex, int cellIndex)
        {
        }

        public void AppendCells(IEnumerable<Cell> cells)
        {
        }

        public void BuildSegments()
        {
        }

        public Board BuildBoard()
        {
            throw new NotImplementedException();
        }

        public void BuildPages()
        {
        }
    }
}