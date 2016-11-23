namespace ObjectStructure
{
    internal interface IClickStatus
    {
        bool IsLeftMouseButtonClicked { get; }
        bool IsRightMouseButtonClicked { get; }
        bool IsCtrlPressed { get; }
        bool IsShiftPressed { get; }
    }
}