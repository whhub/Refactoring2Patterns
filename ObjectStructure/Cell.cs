using System;

namespace ObjectStructure
{
    internal class Cell : ISelect
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
    }
}