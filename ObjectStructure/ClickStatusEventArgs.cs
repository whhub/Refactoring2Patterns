using System;

namespace ObjectStructure
{
    internal class ClickStatusEventArgs : EventArgs
    {
        public ClickStatusEventArgs(IClickStatus clickStatus)
        {
            ClickStatus = clickStatus;
        }

        public IClickStatus ClickStatus { get; private set; }
    }
}