using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ObjectStructure
{
    internal class Card
    {
        private Board _board;
        private SelectableList<ImageCell> _cells;
        private bool _ifRepack;
        private SelectableList<Page> _pages;
        private readonly List<Segment> _segments = new List<Segment>();
        // Called When Initialized
        public void AddPage()
        {
            var layout = GetNewPageLayout();

            _segments.Add(new Segment(layout));

            RebuildLink();
        }

        private void RebuildLink()
        {
            var pages = _segments.SelectMany(s => s.Pages).ToList();
            _pages = new SelectableList<Page>(pages);
            var cells = _pages.SelectMany(p => p.Cells).SelectMany(c => c.ImageCells);
            _cells = new SelectableList<ImageCell>(cells);

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
            var lastSegment = _segments.LastOrDefault();
            Debug.Assert(lastSegment != null);
        }

        public Board BuildBoard()
        {
            _board = new Board();
        }

        public void Repack()
        {
            _segments.ForEach(s => s.Repack());

            RebuildLink();
        }
    }
}