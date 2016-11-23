using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectStructure
{
    internal class Card
    {
        private IEnumerable<Cell> _cells = new List<Cell>();
        private bool _ifRepack;
        private IEnumerable<Page> _pages = new List<Page>();
        private readonly List<Segment> _segments = new List<Segment>();

        public void AddPage()
        {
            var layout = GetNewPageLayout();

            _segments.Add(new Segment(layout));

            RebuildLink();
        }

        private void RebuildLink()
        {
            _pages = _segments.SelectMany(s => s.Pages);
            _cells = _pages.SelectMany(p => p.Cells);

            BuildBoard();
        }

        private Layout GetNewPageLayout()
        {
            var lastPage = _pages.LastOrDefault();
            return lastPage == null ? LayoutFactory.Instance.DefaultLayout() : lastPage.Layout;
        }

        public void InsertCells(IEnumerable<Cell> cells, int pageIndex, int cellIndex)
        {
        }

        public void AppendCells(IEnumerable<Cell> cells)
        {
        }

        public Board BuildBoard()
        {
            throw new NotImplementedException();
        }

        public void Repack()
        {
            _segments.ForEach(s => s.Repack());

            RebuildLink();
        }
    }
}