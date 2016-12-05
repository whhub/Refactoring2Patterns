namespace Ticket
{
    public class TurnNumberSequence
    {
        private static int _turnNumber;

        public virtual int GetNextTurnNumber()
        {
            return _turnNumber++;
        }
    }
}