using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ObjectStructure;

namespace ObjectStructure_UT
{
    [TestClass]
    public class SelectableListTest
    {
        private const int ListSize = 7;
        private List<SelectableStub> _elements;
        private SelectableList<SelectableStub> _selectableList;
        private readonly Mock<IClickStatus> _clickStatusMock = new Mock<IClickStatus>();
        private readonly Random _random = new Random();

        [TestInitialize]
        public void SetUp()
        {
            _elements = new List<SelectableStub>();
            for (var i = 0; i < ListSize; i++)
            {
                _elements.Add(new SelectableStub());
            }
            CreateARandomSelectableList();
        }

        [TestMethod]
        public void When_Left_click_on_an_element_Then_focus_on_it_And_only_select_it() // Method_Scenario_Result
        {
            // Arrange


            // Act

            var clickStatus = Click(true, null, false, false);
            var clickIndex = RandomClickIndex();

            var expectedSelectStatus = 1 << clickIndex;
            var expectedFocusStatus = 1 << clickIndex;


            _elements[clickIndex].Click(clickStatus);

            // Assert
            Assert.AreEqual(expectedSelectStatus, GetSelectStatus());
            Assert.AreEqual(expectedFocusStatus, GetFocusStatus());
            Assert.AreSame(_elements[clickIndex], _selectableList.Focus);
        }

        [TestMethod]
        public void When_Left_click_on_an_element_With_Ctrl_pressed_Then_focus_on_it_And_change_its_select_state()
        {
            // Arrange


            // Act
            var clickStatus = Click(true, null, true, false);
            var clickIndex = RandomClickIndex();

            var expectedSelectStatus = GetSelectStatus() ^ (1 << clickIndex);
            var expectedFocusStatus = 1 << clickIndex;

            _elements[clickIndex].Click(clickStatus);

            // Assert
            Assert.AreEqual(expectedSelectStatus, GetSelectStatus());
            Assert.AreEqual(expectedFocusStatus, GetFocusStatus());
            Assert.AreSame(_elements[clickIndex], _selectableList.Focus);
        }

        [TestMethod]
        public void
            When_Left_click_on_an_element_With_Shift_pressed_Then_Focus_not_changed_And_Select_only_from_focus_to_operation_element
            ()
        {
            //Arrage


            //Act
            var clickStatus = Click(true, null, false, true);
            var clickIndex = RandomClickIndex();

            var expectedSelectStatus = All1FromFocusTo(clickIndex);
            var expectedFocus = _selectableList.Focus;
            var expectedFocusStatus = GetFocusStatus();


            _elements[clickIndex].Click(clickStatus);


            //Assert
            Assert.AreEqual(expectedSelectStatus, GetSelectStatus());
            Assert.AreEqual(expectedFocusStatus, GetFocusStatus());
            Assert.AreSame(expectedFocus, _selectableList.Focus);
        }

        [TestMethod]
        public void
            When_Left_Click_on_an_element_With_CtrlShift_pressed_Then_Focus_not_changed_And_Select_or_UnSelect_from_focus_to_operation_element_Based_on_its_select_status
            ()
        {
            // Arrange


            // Act
            var clickStatus = Click(true, null, true, true);
            var clickIndex = RandomClickIndex();

            var mask = All1FromFocusTo(clickIndex);
            var selectStatus = GetSelectStatus();

            var expectedSelectStatus = _selectableList.Focus.IsSelected ? (selectStatus | mask) : (selectStatus & ~mask);
            var expectedFocusStatus = GetFocusStatus();
            var expectedFocus = _selectableList.Focus;

            Console.WriteLine("Pre ClickIndex: {0}, FocusIndex: {1}, mask: {2}, status: {3}", clickIndex,
                _elements.IndexOf(_selectableList.Focus), mask, selectStatus);
            _elements[clickIndex].Click(clickStatus);

            // Assert

            Assert.AreEqual(expectedSelectStatus, GetSelectStatus());
            Assert.AreEqual(expectedFocusStatus, GetFocusStatus());
            Assert.AreSame(expectedFocus, _selectableList.Focus);
        }

        [TestMethod]
        public void When_Right_Click_on_an_element_With_CtrlShift_Pressed_Then_Select_it_But_Not_change_Focus()
        {
            // Arrange


            // Act
            var clickStatus = Click(false, true, true, true);
            var clickIndex = RandomClickIndex();

            var selectStatusOfClickIndex = _elements[clickIndex].IsSelected;

            var expectedSelectStatus = selectStatusOfClickIndex ? GetSelectStatus() : (1 << clickIndex);
            var expectedFocusStatus = selectStatusOfClickIndex ? GetFocusStatus() : (1 << clickIndex);
            var expectedFocs = selectStatusOfClickIndex ? _selectableList.Focus : _elements[clickIndex];

            _elements[clickIndex].Click(clickStatus);

            // Assert
            Assert.AreEqual(expectedSelectStatus, GetSelectStatus());
            Assert.AreEqual(expectedFocusStatus, GetFocusStatus());
            Assert.AreSame(expectedFocs, _selectableList.Focus);
        }

        [TestMethod]
        public void When_Right_Click_on_an_element_Then_Select_it_But_Not_change_Focus()
        {
            // Arrange


            // Act
            var clickStatus = Click(false, true, false, false);
            var clickIndex = RandomClickIndex();

            var selectStatusOfClickIndex = _elements[clickIndex].IsSelected;

            var expectedSelectStatus = selectStatusOfClickIndex ? GetSelectStatus() : (1 << clickIndex);
            var expectedFocusStatus = selectStatusOfClickIndex ? GetFocusStatus() : (1 << clickIndex);
            var expectedFocs = selectStatusOfClickIndex ? _selectableList.Focus : _elements[clickIndex];

            _elements[clickIndex].Click(clickStatus);

            // Assert
            Assert.AreEqual(expectedSelectStatus, GetSelectStatus());
            Assert.AreEqual(expectedFocusStatus, GetFocusStatus());
            Assert.AreSame(expectedFocs, _selectableList.Focus);
        }

        [TestMethod]
        public void When_Right_Click_on_an_element_With_Only_Ctrl_pressed_Then_nothing_changed()
        {
            // Arrange


            // Act
            var clickStatus = Click(false, true, true, false);
            var clickIndex = RandomClickIndex();

            var expectedSelectStatus = GetSelectStatus();
            var expectedFocusStatus = GetFocusStatus();
            var expectedFocs = _selectableList.Focus;

            _elements[clickIndex].Click(clickStatus);

            // Assert
            Assert.AreEqual(expectedSelectStatus, GetSelectStatus());
            Assert.AreEqual(expectedFocusStatus, GetFocusStatus());
            Assert.AreSame(expectedFocs, _selectableList.Focus);
        }

        [TestMethod]
        public void When_Right_Click_on_an_element_With_Shift_pressed_Then_Select_it_But_Not_change_Focus()
        {
            // Arrange


            // Act
            var clickStatus = Click(false, true, false, true);
            var clickIndex = RandomClickIndex();

            var selectStatusOfClickIndex = _elements[clickIndex].IsSelected;

            var expectedSelectStatus = selectStatusOfClickIndex ? GetSelectStatus() : (1 << clickIndex);
            var expectedFocusStatus = selectStatusOfClickIndex ? GetFocusStatus() : (1 << clickIndex);
            var expectedFocs = selectStatusOfClickIndex ? _selectableList.Focus : _elements[clickIndex];

            _elements[clickIndex].Click(clickStatus);

            // Assert
            Assert.AreEqual(expectedSelectStatus, GetSelectStatus());
            Assert.AreEqual(expectedFocusStatus, GetFocusStatus());
            Assert.AreSame(expectedFocs, _selectableList.Focus);
        }

        private int GetSelectStatus()
        {
            var result = 0;
            for (var index = _elements.Count - 1; index >= 0; index--)
            {
                var t = _elements[index];
                result <<= 1;
                result ^= t.IsSelected ? 1 : 0;
            }
            return result;
        }

        private int GetFocusStatus()
        {
            var result = 0;
            for (var index = _elements.Count - 1; index >= 0; index--)
            {
                var t = _elements[index];
                result <<= 1;
                result ^= t.IsFocused ? 1 : 0;
            }
            return result;
        }

        private int RandomClickIndex()
        {
            return _random.Next()%_elements.Count;
        }

        private IClickStatus Click(bool left, bool? right, bool ctrl, bool shift)
        {
            _clickStatusMock.Setup(cs => cs.IsLeftMouseButtonClicked).Returns(left);
            _clickStatusMock.Setup(cs => cs.IsRightMouseButtonClicked).Returns(right ?? _random.Next()%2 == 0);
            _clickStatusMock.Setup(cs => cs.IsCtrlPressed).Returns(ctrl);
            _clickStatusMock.Setup(cs => cs.IsShiftPressed).Returns(shift);
            return _clickStatusMock.Object;
        }

        private void CreateARandomSelectableList()
        {
            for (var i = 0; i < _elements.Count; i++)
            {
                _elements[i].IsSelected = _random.Next()%2 == 0;
            }
            var randomFocusIndex = _random.Next()%(_elements.Count + 1) - 1; // From -1 to _elements.Count-1
            if (randomFocusIndex != -1)
                _elements[randomFocusIndex].IsFocused = true;

            _selectableList = new SelectableList<SelectableStub>(_elements);
        }

        private int All1FromFocusTo(int clickIndex)
        {
            var focusIndex = _elements.IndexOf(_selectableList.Focus);
            var first = Math.Min(clickIndex, focusIndex);
            var last = Math.Max(clickIndex, focusIndex);
            var expectedSelectStatus = 0;
            for (var i = first; i <= last; i++)
            {
                expectedSelectStatus ^= 1 << i;
            }
            return expectedSelectStatus;
        }
    }

    internal class SelectableStub : ISelect
    {
        public void Click(IClickStatus clickStatus)
        {
            Clicked(this, new ClickStatusEventArgs(clickStatus));
        }

        #region Implementation of ISelect

        public bool IsSelected { get; set; }

        public bool IsFocused { get; set; }

        public event EventHandler<ClickStatusEventArgs> Clicked = delegate { };

        #endregion
    }
}