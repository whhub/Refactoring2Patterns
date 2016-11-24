using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ObjectStructure
{
    public class SelectableList<T> : List<T> where T : class, ISelect
    {
        private T _focus;

        public SelectableList(IEnumerable<T> elements) : base(elements)
        {
            RegisterElementEvent();

            Focus = this.FirstOrDefault(e => e.IsFocused);
        }

        public T Focus
        {
            get { return _focus; }
            private set
            {
                if (_focus == value) return;
                if (_focus != null) _focus.IsFocused = false;
                _focus = value;
                if (_focus != null) _focus.IsFocused = true;
            }
        }

        #region [--Event Handler--]

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

                SelectOnly(operationElement);
                return;
            }

            // 2. left mouse clicked

            // 2.1 ctrl & shift pressed
            if (clickStatus.IsShiftPressed && clickStatus.IsCtrlPressed)
            {
                SelectRangeFromFocusTo(operationElement, Focus != null && Focus.IsSelected);
            }
            // 2.2 only shift pressed
            else if (clickStatus.IsShiftPressed)
            {
                ForEach(e => e.IsSelected = false);
                SelectRangeFromFocusTo(operationElement, true);
            }
            // 2.3 only ctrl pressed
            else if (clickStatus.IsCtrlPressed)
            {
                operationElement.IsSelected = !operationElement.IsSelected;
                Focus = operationElement;
            }
            // 2.4 no modifier key pressed
            else
            {
                SelectOnly(operationElement);
            }
        }

        #endregion [--Event Handler--]

        #region [--Private Methods--]

        private void SelectRangeFromFocusTo(T operationElement, bool isSelected)
        {
            if (Focus == null) return;
            var focusIndex = IndexOf(Focus);
            var operataionIndex = IndexOf(operationElement);

            SelectRange(focusIndex, operataionIndex, isSelected);
        }

        private void SelectOnly(T element)
        {
            ForEach(e => e.IsSelected = false);

            element.IsSelected = true;

            Focus = element;
        }

        private void SelectRange(int index1, int index2, bool isSelected)
        {
            var first = Math.Min(index1, index2);
            var last = Math.Max(index1, index2);

            Debug.Assert(first >= 0);
            Debug.Assert(last < Count);

            for (var i = first; i <= last; i++)
            {
                this.ElementAt(i).IsSelected = isSelected;
            }
        }

        private void RegisterElementEvent()
        {
            foreach (var element in this)
            {
                element.Clicked -= ElementOnClicked;
                element.Clicked += ElementOnClicked;
            }
        }

        #endregion [--Private Methods--]
    }
}