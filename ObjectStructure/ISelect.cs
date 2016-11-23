using System;

namespace ObjectStructure
{
    internal interface ISelect
    {
        bool IsSelected { get; set; }
        bool IsFocused { get; set; }
        event EventHandler<ClickStatusEventArgs> Clicked;
    }
}