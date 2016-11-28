using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ObjectStructure
{
    internal interface ISelectRange<T> where T : class, ISelect
    {
        T Focus { get; set; }
        IEnumerable<T> Elements { get; }
        void SelectRangeFromFocusTo(T e, bool isSelected);
        void SelectOnly(T e);
    }

    internal class RangeSelecter<T> where T : class, ISelect
    {
        private readonly ISelectRange<T> _range;

        private RangeSelecter(ISelectRange<T> range)
        {
            _range = range;
            RegisterElementEvents();
        }

        ~RangeSelecter()
        {
            foreach (var element in _range.Elements)
            {
                element.Clicked -= ElementOnClicked;
            }
        }

        private void RegisterElementEvents()
        {
            foreach (var element in _range.Elements)
            {
                element.Clicked -= ElementOnClicked;
                element.Clicked += ElementOnClicked;
            }
        }

        private void ElementOnClicked(object sender, ClickStatusEventArgs clickStatusEventArgs)
        {
            var operationElement = sender as T;
            Debug.Assert(operationElement != null);
            var clickStatus = clickStatusEventArgs.ClickStatus;

            // 0. Focus

            // 1. only right mouse clicked
            if (clickStatus.IsRightMouseButtonClicked && !clickStatus.IsLeftMouseButtonClicked)
            {
                if (clickStatus.IsCtrlPressed && !clickStatus.IsShiftPressed) return; // modifier key, only ctrl pressed
                if (operationElement.IsSelected) return; // click on selected element

                SelectOnlyAndFocusAt(operationElement);
                return;
            }

            // 2. left mouse clicked

            // 2.1 ctrl & shift pressed
            if (clickStatus.IsShiftPressed && clickStatus.IsCtrlPressed)
            {
                ChangeSelectStatusBasedOnFocusFromFocusTo(operationElement);
            }
            // 2.2 only shift pressed
            else if (clickStatus.IsShiftPressed)
            {
                SelectOnlyFromFocusTo(operationElement);
            }
            // 2.3 only ctrl pressed
            else if (clickStatus.IsCtrlPressed)
            {
                ChangeSelectStatusAndFocusAt(operationElement);
            }
            // 2.4 no modifier key pressed
            else
            {
                SelectOnlyAndFocusAt(operationElement);
            }
        }

        private void ChangeSelectStatusBasedOnFocusFromFocusTo(T operationElement)
        {
            _range.SelectRangeFromFocusTo(operationElement, _range.Focus != null && _range.Focus.IsSelected);
        }

        private void SelectOnlyFromFocusTo(T operationElement)
        {
            _range.Elements.ToList().ForEach(e => e.IsSelected = false);
            _range.SelectRangeFromFocusTo(operationElement, true);
        }

        private void ChangeSelectStatusAndFocusAt(T operationElement)
        {
            operationElement.IsSelected = !operationElement.IsSelected;
            _range.Focus = operationElement;
        }

        private void SelectOnlyAndFocusAt(T operationElement)
        {
            _range.SelectOnly(operationElement);
            _range.Focus = operationElement;
        }
    }

    internal class RangeSelection
    {
    }
}