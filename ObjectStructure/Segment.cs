using System.Collections.Generic;

namespace ObjectStructure
{
    internal class Segment
    {
        private readonly IList<Cell> _cells = new List<Cell>();

        public Segment(Layout layout)
        {
            Pages = new List<Page>();
            for (var i = 0; i < layout.Capacity; i++)
            {
                _cells.Add(new Cell());
            }
            var page = new Page(layout, _cells);
            Pages.Add(page);
        }

        public IList<Page> Pages { get; private set; }

        public void Repack()
        {
            throw new System.NotImplementedException();
        }
    }
}