using System;
using System.Collections.Generic;

namespace ObjectStructure
{
    internal class Page : ISelect
    {
        public IEnumerable<Cell> Cells { get; private set; }

        public Page(Layout layout, IEnumerable<Cell> cells)
        {
            Layout = layout;
            Cells = cells;
        }


        public Layout Layout { get; set; }

        #region [--Implementation of ISelect--]

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

        #endregion[--Implementation of ISelect--]
    }
}