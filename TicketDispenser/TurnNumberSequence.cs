namespace Ticket
{
    public class TurnNumberSequence
    {
        private static int _turnNumber;

        public TurnNumberSequence(int firstNumber)
        {
            _turnNumber = firstNumber;
        }

        public virtual int GetNextTurnNumber()
        {
            return _turnNumber++;
        }
    }
}