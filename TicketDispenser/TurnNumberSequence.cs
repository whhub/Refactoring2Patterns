namespace Ticket
{
    public class TurnNumberSequence
    {
        private static int _turnNumber;

        public TurnNumberSequence(int firstNumber)
        {
            _turnNumber = firstNumber;
        }

        public TurnNumberSequence() : this(0)
        {
        }

        public virtual int GetNextTurnNumber()
        {
            return _turnNumber++;
        }

        public const int VIPCustomerFirstNumber = 1001;
        public const int RegularCustomerFirstNumber = 2001;
    }
}