using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectStructure
{
    internal class Card
    {
        private bool _ifRepack;
        private readonly IList<Segment> _segments = new List<Segment>();

        public void AddPage()
        {
            //var lastSegment = _segments.LastOrDefault();
            //Page lastPage;
            //if (lastSegment != null)
            //    lastPage = lastSegment.
            //        var
            //segment = new Segment(layout, cells);
        }

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