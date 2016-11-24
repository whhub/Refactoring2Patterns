using System;

namespace ObjectStructure
{
    public interface ISelect
    {
        bool IsSelected { get; set; }
        bool IsFocused { get; set; }
        event EventHandler<ClickStatusEventArgs> Clicked;
    }
}