using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectStructure
{
    abstract class Cell
    {
        public abstract IEnumerable<ImageCell> ImageCells { get; } 
    }

    internal abstract class ImageCell : Cell, ISelect
    {
        #region [--Implemented From ISelect--]

        public bool IsSelected
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsFocused
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public event EventHandler<ClickStatusEventArgs> Clicked;

        #endregion [--Implemented From ISelect--]

        #region Overrides of Cell

        public override IEnumerable<ImageCell> ImageCells
        {
            get { return new List<ImageCell> {this}; }
        }

        #endregion
    }

    class AppCell : ImageCell
    {
    }

    class LocalCell : ImageCell
    {
    }

    class MultiformatCell : Cell
    {
        private Layout _layout;
        private List<ImageCell> _cells;

        public MultiformatCell(Layout layout, IEnumerable<ImageCell> cells)
        {
            _layout = layout;
            _cells = cells.ToList();
        }

        #region Overrides of Cell

        public override IEnumerable<ImageCell> ImageCells
        {
            get { return _cells; }
        }

        #endregion
    }
}